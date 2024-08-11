﻿using System;
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
        //Gửi tin nhắn
        private void btn_Send_Click(object sender, EventArgs e)
        {
            if (_client == null || !_client.Connected)
            {
                MessageBox.Show("Chưa kết nối tới server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = txt_Message.Text;
            //kiểm tra khung tin nhắn đã có nọi dung hay chưa
            if (!string.IsNullOrEmpty(message))
            {
                ShowMessage($"Tôi gửi: {txt_Message.Text}");
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                try
                {
                    _sslStream.Write(buffer, 0, buffer.Length);
                    txt_Message.Clear();
                }
                catch (Exception ex)
                {
                    ShowMessage($"Gửi tin nhắn thất bại: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tin nhắn trước khi gửi", "Thông báo *_*", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Connect server
        private async void btn_connect_Click(object sender, EventArgs e)
        {
            await Connect();
            txt_Message.Enabled = true;
            btn_Send.Enabled = true;
            btn_disconnect.Enabled = true;
            btn_connect.Enabled = false;
        }
        //Disconnect server
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            txt_Message.Enabled = false;
            btn_Send.Enabled = false;
            btn_disconnect.Enabled = false;
            btn_connect.Enabled = true;

            this.Close();
        }
        //xử lý kết nối tới server

        private async Task Connect()
        {
            IPAddress IP;
            int port;
            string username;
            try
            {
                if (string.IsNullOrEmpty(txt_IPAddress.Text) || string.IsNullOrEmpty(txt_Port.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ IP và Port lớn hơn 1000 trở lên !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IPAddress.TryParse(txt_IPAddress.Text, out IP))
                {
                    MessageBox.Show("Vui lòng nhập đúng địa chỉ IP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txt_Port.Text, out port))
                {
                    MessageBox.Show("Vui lòng nhập Port có giá trị lớn hơn 1000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrEmpty(txt_Message.Text))
                {
                    MessageBox.Show("Vui lòng nhâp tên người dùng *_*", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                _client = new TcpClient();
                await _client.ConnectAsync(IP, port);

                ShowMessage("Đã kết nối đến server");
                //khỏi tạo lớp Sslstream để mã hóa dữ liệu khi gửi
                NetworkStream networkStream = _client.GetStream();
                _sslStream = new SslStream(networkStream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);

                // Xác thực máy chủ
                try
                {
                    await _sslStream.AuthenticateAsClientAsync(txt_IPAddress.Text);
                }
                catch (Exception ex)
                {
                    ShowMessage($"Xác thực thất bại: {ex.Message}");
                    return;
                }

                // Gửi tên người dùng ngay khi kết nối
                username = txt_username.Text;
                byte[] byte_user = Encoding.UTF8.GetBytes(username);
                await _sslStream.WriteAsync(byte_user, 0, byte_user.Length);

                _ = Task.Run(() => ReceiveMessagesAsync(_sslStream));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Ngắt kết nối tới Server
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
                    ShowMessage("Đã ngắt kết nối khỏi server");
                }
            }
        }

        //Nhận dữ liệu từ server
        private async Task ReceiveMessagesAsync(SslStream sslStream)
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = await sslStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ShowMessage(message);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Mất kết nối: {ex.Message}");
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
        //đưa dữ liệu tin nhắn lên Message Box
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
    }
}

