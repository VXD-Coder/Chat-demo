using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Security;

namespace Client
{
    public partial class Client : Form
    {
        private TcpClient _client;
        private SslStream _sslStream;

        public Client()
        {
            InitializeComponent();
        }

        // Gửi tin nhắn
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (_client == null || !_client.Connected)
            {
                MessageBox.Show("Chưa kết nối tới server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = txt_Message.Text;
            // Kiểm tra khung tin nhắn đã có nội dung hay chưa
            if (!string.IsNullOrEmpty(message))
            {
                ShowMessage($"Tôi gửi: {message}");
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                try
                {
                    _sslStream.Write(buffer, 0, buffer.Length);
                    txt_Message.Clear();
                }
                catch (Exception ex)
                {
                    showStatus($"Gửi tin nhắn thất bại: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn trước khi gửi", "Thông báo *_*", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kết nối tới server
        private async void btn_connect_Click(object sender, EventArgs e)
        {
            await Connect();
            txt_Message.Enabled = true;
            btn_Send.Enabled = true;
            btn_disconnect.Enabled = true;
            btn_connect.Enabled = false;
        }

        // Ngắt kết nối khỏi server
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            txt_Message.Enabled = false;
            btn_Send.Enabled = false;
            btn_disconnect.Enabled = false;
            btn_connect.Enabled = true;

            this.Close();
        }

        // Xử lý kết nối tới server
        private async Task Connect()
        {
            IPAddress ip;
            int port;
            string username;

            try
            {
                if (string.IsNullOrEmpty(txt_IPAddress.Text) || string.IsNullOrEmpty(txt_Port.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ IP và Port lớn hơn 1000 trở lên !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IPAddress.TryParse(txt_IPAddress.Text, out ip))
                {
                    MessageBox.Show("Vui lòng nhập đúng địa chỉ IP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txt_Port.Text, out port) || port <= 1000)
                {
                    MessageBox.Show("Vui lòng nhập Port có giá trị lớn hơn 1000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(txt_username.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên người dùng *_*", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _client = new TcpClient();
                await _client.ConnectAsync(ip, port);

                showStatus("Đã kết nối đến server");

                NetworkStream networkStream = _client.GetStream();
                _sslStream = new SslStream(networkStream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

                // Xác thực máy chủ
                try
                {
                    // Thay đổi tên máy chủ thành tên máy chủ hoặc địa chỉ IP của server
                    await _sslStream.AuthenticateAsClientAsync(ip.ToString());
                }
                catch (Exception ex)
                {
                    showStatus($"Xác thực thất bại: {ex.Message}");
                    return;
                }

                // Gửi tên người dùng ngay khi kết nối
                username = txt_username.Text;
                byte[] byte_user = Encoding.UTF8.GetBytes(username);
                await _sslStream.WriteAsync(byte_user, 0, byte_user.Length);

                // Bắt đầu nhận tin nhắn
                _ = Task.Run(() => ReceiveMessagesAsync(_sslStream));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ngắt kết nối khỏi server
        private void Disconnect()
        {
            if (_client != null)
            {
                try
                {
                    _sslStream?.Close();
                    _client?.Close();
                }
                catch (Exception ex)
                {
                    ShowMessage($"Lỗi khi ngắt kết nối: {ex.Message}");
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _client = null;
                    _sslStream = null;
                    showStatus("Đã ngắt kết nối khỏi server");
                }
            }
        }

        // Nhận dữ liệu từ server
        // Nhận dữ liệu từ server
        private async Task ReceiveMessagesAsync(SslStream sslStream)
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = await sslStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                    // Xử lý thông điệp danh sách người dùng
                    if (message.StartsWith("/ClientList"))
                    {
                        string userList = message.Substring("/ClientList".Length).Trim();
                        // Tách danh sách người dùng
                        string[] users = userList.Split(new[] { ", " }, StringSplitOptions.None);
                        UpdateUserList(users);
                    }
                    else
                    {
                        ShowMessage(message);
                    }
                }
            }
            catch (Exception ex)
            {
                showStatus($"Mất kết nối: {ex.Message}");
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Xác thực chứng chỉ máy chủ
        public static bool ValidateServerCertificate(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            // Ở đây bạn có thể xác thực chứng chỉ server theo nhu cầu của bạn.
            // Để đơn giản, chúng ta sẽ chấp nhận mọi chứng chỉ.
            return true;
        }

        // Đưa dữ liệu tin nhắn lên Message Box
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



        // Cập nhật danh sách người dùng trên giao diện người dùng
        void UpdateUserList(string[] users)
        {
            if (listbox_User.InvokeRequired)
            {
                // Sử dụng Invoke để cập nhật giao diện người dùng từ luồng khác
                listbox_User.Invoke(new Action(() =>
                {
                    // Xóa toàn bộ danh sách hiện tại
                    listbox_User.Items.Clear();

                    // Thêm các người dùng mới vào ListBox
                    foreach (string user in users)
                    {
                        if (!string.IsNullOrWhiteSpace(user))
                        {
                            listbox_User.Items.Add(user);
                        }
                    }
                }));
            }
            else
            {
                // Cập nhật giao diện người dùng trực tiếp nếu đang ở luồng chính
                listbox_User.Items.Clear();
                foreach (string user in users)
                {
                    if (!string.IsNullOrWhiteSpace(user))
                    {
                        listbox_User.Items.Add(user);
                    }
                }
            }
        }



        public void showStatus(string message)
        {
            if (txt_status.InvokeRequired)
            {
                txt_status.Invoke(new Action(() => showStatus(message)));
            }
            else
            {
                txt_status.Text = message + Environment.NewLine + txt_status.Text;
            }
        }
    }
}
