using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        private static ConcurrentBag<ClientInfo> clients = new ConcurrentBag<ClientInfo>();
        private TcpListener server;
        private byte[] message;

        public Server()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Placeholder for textBox3 functionality if needed
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Placeholder for label2 functionality if needed
        }

        // Disconnect-Click
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Stop_Server();
        }

        // Send-Click
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Message.Text))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BroadcastAsync("Server : " + txt_Message.Text, null);
            ShowMessage("Tôi gửi: " + txt_Message.Text);
            txt_Message.Clear();
        }

        // Start -Click
        private async void btn_StartServer_Click(object sender, EventArgs e)
        {
            await Start_Server();
        }

         void ShowLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(var ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    showIP(ip.ToString());
                }
            }
        }

        // Khởi tạo hàm khởi động Server (không đồng bộ)
        public async Task Start_Server()
        {
            int port = 9999;

            server = new TcpListener(IPAddress.Any, port);
            server.Start();

            ShowLocalIPAddress();

            ShowMessage("Server đã khởi động.....");
            txt_Message.Enabled = true;
            btn_Send.Enabled = true;
            btn_StopServer.Enabled = true;
            btn_StartServer.Enabled = false;

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                NetworkStream networkStream = client.GetStream();
                SslStream sslStream = new SslStream(networkStream, false);

                //đường dẫn và pass của file chứng chỉ

                string certPath = "server.pfx";
                string certPass = "abc@123";

                // Tải chứng chỉ máy chủ
                X509Certificate serverCertificate = new X509Certificate(certPath, certPass);
                await sslStream.AuthenticateAsServerAsync(serverCertificate, false, System.Security.Authentication.SslProtocols.Tls12, true);

                // Nhận tên người dùng từ client
                byte[] data_user = new byte[1024];
                int byte_read = await sslStream.ReadAsync(data_user, 0, data_user.Length);
                string username = Encoding.UTF8.GetString(data_user, 0, byte_read).Trim();

                // Thêm client và username vào danh sách
                var clientInfo = new ClientInfo { TcpClient = client, SslStream = sslStream, Username = username };
                clients.Add(clientInfo);

                // Hiển thị thông tin người dùng lên listbox_User
                ShowUser("User name : " + username);
                // Thông báo người dùng đã kết nối lên khung chat 
                ShowMessage(username + " Connected!");

                // Gọi hàm xử lý từng client
                _ = Handle_Client_Async(clientInfo);
            }
        }

        // Hàm xử lý từng client
        private async Task Handle_Client_Async(ClientInfo clientInfo)
        {
            SslStream sslStream = clientInfo.SslStream;
            message = new byte[1024];
            string messRead;
            try
            {
                while (true)
                {
                    int byteRead = await sslStream.ReadAsync(message, 0, message.Length);
                    if (byteRead == 0) break;

                    messRead = Encoding.UTF8.GetString(message, 0, byteRead);
                    ShowMessage(clientInfo.Username + ": " + messRead);

                    await BroadcastAsync(clientInfo.Username + ": " + messRead, clientInfo.TcpClient);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error: " + ex.Message);
            }
            finally
            {
                clients = new ConcurrentBag<ClientInfo>(clients.Where(c => c != clientInfo));
                clientInfo.TcpClient.Close();
                ShowMessage(clientInfo.Username + " disconnected!");
                RemoveUser("User name : " + clientInfo.Username);
            }
        }

        // Gửi tin nhắn đến các Client khác trong danh sách kết nối
        private async Task BroadcastAsync(string message, TcpClient excludeClient)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(message);
            var tasks = clients
                .Where(c => c.TcpClient != excludeClient)
                .Select(async clientInfo =>
                {
                    try
                    {
                        SslStream sslStream = clientInfo.SslStream;
                        await sslStream.WriteAsync(dataByte, 0, dataByte.Length);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage("Client Disconnected: " + ex.Message);
                        clientInfo.TcpClient.Close();
                        clients = new ConcurrentBag<ClientInfo>(clients.Where(c => c != clientInfo));
                    }
                }).ToList();

            await Task.WhenAll(tasks);
        }
        //đóng server 
        private void Stop_Server()
        {
            if (server != null)
            {
                foreach (var clientInfo in clients)
                {
                    clientInfo.SslStream.Close();
                    clientInfo.TcpClient.Close();
                }
                server.Stop();
                clients = new ConcurrentBag<ClientInfo>();
                ShowMessage("Server đã ngắt kết nối.");

                txt_Message.Enabled = false;
                btn_Send.Enabled = false;
                btn_StopServer.Enabled = false;
                btn_StartServer.Enabled = true;
            }
        }
        // đưa danh sach user(Client) kết nối tới server lên Ô Connect user
        void ShowUser(string username)
        {
            if (listbox_User.InvokeRequired)
            {
                listbox_User.Invoke(new Action(() => listbox_User.Items.Add(username)));
            }
            else
            {
                listbox_User.Items.Add(username);
            }
        }
        //xóa người dùng (Client ) đã ngắt kết nối với user
        void RemoveUser(string username)
        {
            if (listbox_User.InvokeRequired)
            {
                listbox_User.Invoke(new Action(() => listbox_User.Items.Remove(username)));
            }
            else
            {
                listbox_User.Items.Remove(username);
            }
        }
        //đưa tin nhắn lên Ô Message 
        void ShowMessage(string message)
        {
            if (listbox_result.InvokeRequired)
            {
                listbox_result.Invoke(new Action(() => listbox_result.Items.Add(message)));
            }
            else
            {
                listbox_result.Items.Add(message);
            }
        }
        //đưa thông tin IP server lên ô địa chỉ server
        public void showIP(string message)
        {
            if (txt_IPAddress.InvokeRequired)
            {
                txt_IPAddress.Invoke(new Action(() => showIP(message)));
            }
            else
            {
                txt_IPAddress.Text = message + Environment.NewLine + txt_IPAddress.Text;
            }
        }

    }



    // Định nghĩa lớp ClientInfo để lưu trữ thông tin của mỗi client
    public class ClientInfo
    {
        public TcpClient TcpClient { get; set; }
        public SslStream SslStream { get; set; }
        public string Username { get; set; }
    }
}
