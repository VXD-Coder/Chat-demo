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

        private bool CheckInputs(out IPAddress ip, out int port, out string username)
        {
            ip = null;
            port = 0;
            username = string.Empty;

            if (string.IsNullOrEmpty(txt_username.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng *_*", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txt_IPAddress.Text) || string.IsNullOrEmpty(txt_Port.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP và Port lớn hơn 1000 trở lên !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IPAddress.TryParse(txt_IPAddress.Text, out ip))
            {
                MessageBox.Show("Vui lòng nhập đúng địa chỉ IP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txt_Port.Text, out port) || port <= 1000)
            {
                MessageBox.Show("Vui lòng nhập Port có giá trị lớn hơn 1000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            username = txt_username.Text;
            return true;
        }

        private async Task Connect()
        {
            try
            {
                // Kiểm tra khung nhập dữ liệu
                if (!CheckInputs(out IPAddress ip, out int port, out string username)) return;

                _client = new TcpClient();
                await _client.ConnectAsync(ip, port);

                showStatus("Đã kết nối đến server");

                NetworkStream networkStream = _client.GetStream();

                _sslStream = new SslStream(networkStream, false, ValidateServerCertificate, null);

                try
                {
                    await _sslStream.AuthenticateAsClientAsync(ip.ToString());
                }
                catch (Exception ex)
                {
                    showStatus($"Xác thực thất bại: {ex.Message}");
                    return;
                }

                // Gửi tên người dùng ngay khi kết nối
                byte[] byte_user = Encoding.UTF8.GetBytes(username);
                await _sslStream.WriteAsync(byte_user, 0, byte_user.Length);

                _ = Task.Run(() => ReceiveMessagesAsync(_sslStream));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Disconnect()
        {
            if (_client != null)
            {
                try
                {
                    _sslStream?.Close();
                    _client.Close();
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

                    if (message.StartsWith("/ClientList"))
                    {
                        string userList = message.Substring("/ClientList".Length).Trim();
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

        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Chấp nhận tất cả chứng chỉ, bạn có thể thay đổi tùy theo nhu cầu
            return true;
        }

        private void UpdateUserList(string[] users)
        {
            InvokeIfRequired(listbox_User, () =>
            {
                listbox_User.Items.Clear();
                foreach (string user in users)
                {
                    if (!string.IsNullOrWhiteSpace(user))
                    {
                        listbox_User.Items.Add(user);
                    }
                }
            });
        }

        private void ShowMessage(string message)
        {
            InvokeIfRequired(listbox_result, () => listbox_result.Items.Add(message));
        }

        private void showStatus(string message)
        {
            InvokeIfRequired(txt_status, () => txt_status.Text = message + Environment.NewLine + txt_status.Text);
        }

        private void InvokeIfRequired(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            if (_client == null || !_client.Connected)
            {
                MessageBox.Show("Chưa kết nối tới server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_sslStream == null)
            {
                MessageBox.Show("SSL stream chưa được khởi tạo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = txt_Message.Text;
            if (!string.IsNullOrEmpty(message))
            {
                ShowMessage($"Tôi gửi: {message}");
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                try
                {
                    await _sslStream.WriteAsync(buffer, 0, buffer.Length);
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

        private async void btn_connect_Click(object sender, EventArgs e)
        {
            await Connect();
            txt_Message.Enabled = true;
            btn_disconnect.Enabled = true;
            btn_Send.Enabled = true;
            btn_connect.Enabled = false;
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            txt_Message.Enabled = false;
            btn_disconnect.Enabled = false;
            btn_Send.Enabled = false;
            btn_connect.Enabled = true;
        }

        private async void txt_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn tiếng "ting" khi nhấn Enter
                btn_Send_Click(sender, e);
            }
        }
    }
}
