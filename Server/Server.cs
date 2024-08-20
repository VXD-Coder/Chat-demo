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
        // Sử dụng lại ConcurrentBag thay vì ConcurrentDictionary
        private static ConcurrentBag<ClientInfo> clients = new ConcurrentBag<ClientInfo>();
        private TcpListener server;
        private byte[] message;

        public Server()
        {
            InitializeComponent();
        }

        // Hiển thị thông tin địa chỉ IP của server
        private void ShowLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (txt_IPAddress.InvokeRequired)
                    {
                        txt_IPAddress.Invoke(new Action(() =>
                            txt_IPAddress.Text = ip.ToString() + Environment.NewLine + txt_IPAddress.Text));
                    }
                    else
                    {
                        txt_IPAddress.Text = ip.ToString() + Environment.NewLine + txt_IPAddress.Text;
                    }
                }
            }
        }

        // Khởi động server (không đồng bộ)
        public async Task Start_Server()
        {
            int port = 9999;

            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            ShowLocalIPAddress();
            showStatus("Server đã khởi động...");

            txt_Message.Enabled = true;
            btn_Send.Enabled = true;
            btn_StopServer.Enabled = true;
            btn_StartServer.Enabled = false;

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        // Xử lý từng client (không đồng bộ)
        private async Task HandleClientAsync(TcpClient client)
        {
            string username = null;
            try
            {
                using (var networkStream = client.GetStream())
                using (var sslStream = new SslStream(networkStream, false))
                {
                    // Đường dẫn và pass của file chứng chỉ
                    string certPath = "server.pfx";
                    string certPass = "abc@123";
                    var serverCertificate = new X509Certificate(certPath, certPass);
                    await sslStream.AuthenticateAsServerAsync(serverCertificate, false, System.Security.Authentication.SslProtocols.Tls12, true);

                    // Nhận tên người dùng từ client
                    byte[] buffer = new byte[1024];
                    int byteCount = await sslStream.ReadAsync(buffer, 0, buffer.Length);
                    username = Encoding.UTF8.GetString(buffer, 0, byteCount).Trim();

                    // Thêm client vào danh sách
                    var clientInfo = new ClientInfo { TcpClient = client, SslStream = sslStream, Username = username };
                    clients.Add(clientInfo);
                    ShowUser("User name : " + username);
                    showStatus(username + " đã kết nối!");

                    // Gửi danh sách người dùng cho tất cả các client
                    await SendClientListToAllAsync();

                    // Xử lý tin nhắn từ client
                    await HandleMessagesAsync(clientInfo);
                }
            }
            catch (Exception ex)
            {
                showStatus("Error: " + ex.Message);
            }
            finally
            {
                if (username != null)
                {
                    // Loại bỏ client ra khỏi danh sách
                    clients = new ConcurrentBag<ClientInfo>(clients.Where(c => c.Username != username));
                    RemoveUser("User name : " + username);
                    await SendClientListToAllAsync();
                    showStatus(username + " đã ngắt kết nối.");
                }

                client.Close();
            }
        }

        // Xử lý tin nhắn từ client
        private async Task HandleMessagesAsync(ClientInfo clientInfo)
        {
            try
            {
                var sslStream = clientInfo.SslStream;
                message = new byte[1024];

                while (true)
                {
                    int byteRead = await sslStream.ReadAsync(message, 0, message.Length);
                    if (byteRead == 0) break;

                    string receivedMessage = Encoding.UTF8.GetString(message, 0, byteRead);
                    ShowMessage(clientInfo.Username + ": " + receivedMessage);

                    await BroadcastAsync(clientInfo.Username + ": " + receivedMessage, clientInfo.TcpClient);
                }
            }
            catch (Exception ex)
            {
                showStatus("Error: " + ex.Message);
            }
        }

        // Gửi tin nhắn đến tất cả các client ngoại trừ client gửi
        private async Task BroadcastAsync(string message, TcpClient excludeClient)
        {
            byte[] dataByte = Encoding.UTF8.GetBytes(message);

            var tasks = clients
                .Where(c => c.TcpClient != excludeClient)
                .Select(async clientInfo =>
                {
                    try
                    {
                        await clientInfo.SslStream.WriteAsync(dataByte, 0, dataByte.Length);
                    }
                    catch (Exception ex)
                    {
                        showStatus("Client Disconnected: " + ex.Message);
                        clientInfo.TcpClient.Close();
                        clients = new ConcurrentBag<ClientInfo>(clients.Where(c => c != clientInfo));
                    }
                });

            await Task.WhenAll(tasks);
        }

        // Gửi danh sách người dùng cho tất cả các client
        private async Task SendClientListToAllAsync()
        {
            var clientListMessage = "/ClientList " + string.Join(", ", clients.Select(c => c.Username));
            byte[] dataByte = Encoding.UTF8.GetBytes(clientListMessage);

            var tasks = clients.Select(async clientInfo =>
            {
                try
                {
                    await clientInfo.SslStream.WriteAsync(dataByte, 0, dataByte.Length);
                }
                catch (Exception ex)
                {
                    showStatus("Client Disconnected: " + ex.Message);
                    clientInfo.TcpClient.Close();
                    clients = new ConcurrentBag<ClientInfo>(clients.Where(c => c != clientInfo));
                }
            });

            await Task.WhenAll(tasks);
        }

        // Dừng server
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
                showStatus("Server đã ngắt kết nối.");

                txt_Message.Enabled = false;
                btn_Send.Enabled = false;
                btn_StopServer.Enabled = false;
                btn_StartServer.Enabled = true;
            }
        }

        // Đưa danh sách user(Client) kết nối tới server lên Ô Connect user
        private void ShowUser(string username)
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

        // Xóa người dùng (Client) đã ngắt kết nối với user
        private void RemoveUser(string username)
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

        // Đưa tin nhắn lên Ô Message
        private void ShowMessage(string message)
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

        // Đưa thông tin về trạng thái của server lên ô trạng thái
        public void showStatus(string message)
        {
            if (txt_status.InvokeRequired)
            {
                txt_status.Invoke(new Action(() => txt_status.Text = message + Environment.NewLine + txt_status.Text));
            }
            else
            {
                txt_status.Text = message + Environment.NewLine + txt_status.Text;
            }
        }

        // Start server - Click
        private async void btn_StartServer_Click(object sender, EventArgs e)
        {
            await Start_Server();
        }

        // Stop server - Click
        private void btn_StopServer_Click(object sender, EventArgs e)
        {
            Stop_Server();
            this.Close();
        }

        // Send message - Click
        private async void btn_Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Message.Text))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = "Server: " + txt_Message.Text;
            await BroadcastAsync(message, null);
            ShowMessage("Tôi gửi: " + txt_Message.Text);
            txt_Message.Clear();
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
