# Ứng Dụng Chat

### Sử Dụng TCPClient & Async cho Hiệu Suất Tối Ưu
### Bảo Mật với SSL Stream và Xác Thực qua AuthenticatedStream
### Phát Tán Tin Nhắn Qua Mạng với Broadcast
### Mô Hình Multi Client- Server

## Chức Năng Server

### 1. Xử Lý Client
**Chức năng:** Xử lý kết nối và dữ liệu từ client sử dụng `TCPClient` và Async để cải thiện hiệu suất.  
**Phương thức:** `HandleClientAsync(TcpClient client)`  
**Chi tiết:**  
- Xác thực client qua `SslStream` và đọc tên người dùng.
- Thêm client vào danh sách clients.
- Cập nhật danh sách người dùng cho tất cả các client.
- Xử lý tin nhắn từ client và phát đi tin nhắn đó đến tất cả các client khác.

### 2. Xử Lý Tin Nhắn
**Chức năng:** Xử lý và phát tán tin nhắn từ client.  
**Phương thức:** `HandleMessagesAsync(ClientInfo clientInfo)`  
**Chi tiết:**  
- Đọc tin nhắn từ `SslStream` của client.
- Hiển thị tin nhắn trên giao diện và gửi tin nhắn đến tất cả client khác (trừ client gửi).

### 3. Gửi Tin Nhắn
**Chức năng:** Gửi tin nhắn từ server đến tất cả client kết nối.  
**Phương thức:** `BroadcastAsync(string message, TcpClient excludeClient)`  
**Chi tiết:**  
- Chuyển tiếp tin nhắn đến tất cả client ngoại trừ client gửi.

### 4. Gửi Danh Sách Người Dùng
**Chức năng:** Cập nhật danh sách người dùng cho tất cả client.  
**Phương thức:** `SendClientListToAllAsync()`  
**Chi tiết:**  
- Tạo tin nhắn chứa danh sách tên người dùng và gửi đến tất cả client.

### 5. Hiển Thị Tin Nhắn
**Chức năng:** Hiển thị tin nhắn trên giao diện người dùng.  
**Phương thức:** `ShowMessage(string message)`  
**Chi tiết:**  
- Thêm tin nhắn vào `listbox_result` trên giao diện người dùng.

### 6. Cập Nhật Trạng Thái
**Chức năng:** Hiển thị trạng thái của server trên giao diện người dùng.  
**Phương thức:** `showStatus(string message)`  
**Chi tiết:**  
- Cập nhật `txt_status` để hiển thị các thông báo trạng thái của server.

### 7. Gửi Tin Nhắn Từ Server
**Chức năng:** Gửi tin nhắn từ server đến tất cả các client.  
**Phương thức:** `btn_Send_Click`  
**Chi tiết:**  
- Gửi tin nhắn với tiền tố "Server: " đến tất cả các client kết nối.
- Hiển thị tin nhắn đã gửi trên giao diện người dùng (Broadcast).

## Chức Năng Client

### 1. Xác Thực Dữ Liệu Đầu Vào
**Chức năng:** Xác thực các thông tin nhập vào như địa chỉ IP, cổng, và tên người dùng.  
**Phương thức:** `ValidateInputs(out IPAddress ip, out int port, out string username)`  
**Chi tiết:**  
- Kiểm tra xem địa chỉ IP và cổng có hợp lệ không.
- Kiểm tra cổng có lớn hơn 1000 và tên người dùng không rỗng.
- Hiển thị thông báo lỗi nếu dữ liệu đầu vào không hợp lệ.

### 2. Kết Nối Đến Server
**Chức năng:** Kết nối đến server qua TCP và thiết lập kết nối SSL.  
**Phương thức:** `Connect()`  
**Chi tiết:**  
- Kiểm tra dữ liệu đầu vào bằng phương thức `ValidateInputs()`.
- Kết nối đến server sử dụng `TcpClient`.
- Thiết lập `SslStream` và thực hiện xác thực SSL với server.
- Gửi tên người dùng đến server.
- Bắt đầu nhận tin nhắn từ server.

### 3. Ngắt Kết Nối
**Chức năng:** Ngắt kết nối với server và đóng các tài nguyên.  
**Phương thức:** `Disconnect()`  
**Chi tiết:**  
- Đóng `SslStream` và `TcpClient`.
- Cập nhật trạng thái kết nối và xử lý lỗi nếu có.

### 4. Nhận Tin Nhắn
**Chức năng:** Nhận và xử lý tin nhắn từ server.  
**Phương thức:** `ReceiveMessagesAsync(SslStream sslStream)`  
**Chi tiết:**  
- Đọc tin nhắn từ `SslStream`.
- Cập nhật danh sách người dùng nếu tin nhắn bắt đầu bằng "/ClientList".
- Hiển thị tin nhắn trên giao diện người dùng.

### 5. Xác Thực Chứng Chỉ SSL
**Chức năng:** Xác thực chứng chỉ SSL của server.  
**Phương thức:** `ValidateServerCertificate()`  
**Chi tiết:**  
- Hiện tại, chấp nhận tất cả chứng chỉ. Bạn có thể tùy chỉnh phương thức này để kiểm tra chứng chỉ cụ thể.

### 6. Cập Nhật Danh Sách Người Dùng
**Chức năng:** Cập nhật danh sách người dùng kết nối với server.  
**Phương thức:** `UpdateUserList(string[] users)`  
**Chi tiết:**  
- Xóa danh sách người dùng hiện tại và thêm danh sách mới vào `listbox_User`.

### 7. Hiển Thị Tin Nhắn
**Chức năng:** Hiển thị tin nhắn trên giao diện người dùng.  
**Phương thức:** `ShowMessage(string message)`  
**Chi tiết:**  
- Thêm tin nhắn vào `listbox_result`.

### 8. Cập Nhật Trạng Thái
**Chức năng:** Cập nhật trạng thái của client trên giao diện người dùng.  
**Phương thức:** `showStatus(string message)`  
**Chi tiết:**  
- Hiển thị trạng thái hiện tại trong `txt_status`.

### 9. Gửi Tin Nhắn
**Chức năng:** Gửi tin nhắn từ client đến server.  
**Phương thức:** `btn_Send_Click`  
**Chi tiết:**  
- Kiểm tra kết nối và `SslStream` có sẵn không.
- Gửi tin nhắn đến server qua `SslStream`.
- Hiển thị tin nhắn đã gửi và xử lý lỗi nếu có.
