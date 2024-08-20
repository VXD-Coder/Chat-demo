namespace Client
{
    partial class Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            listbox_result = new ListBox();
            txt_Message = new TextBox();
            btn_Send = new Button();
            panel1 = new Panel();
            label4 = new Label();
            btn_disconnect = new Button();
            btn_connect = new Button();
            listbox_User = new ListBox();
            label3 = new Label();
            txt_Port = new TextBox();
            label1 = new Label();
            txt_IPAddress = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            txt_username = new TextBox();
            label5 = new Label();
            panel2 = new Panel();
            label6 = new Label();
            txt_status = new TextBox();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // listbox_result
            // 
            listbox_result.FormattingEnabled = true;
            listbox_result.Location = new Point(303, 144);
            listbox_result.Name = "listbox_result";
            listbox_result.Size = new Size(520, 484);
            listbox_result.TabIndex = 0;
            // 
            // txt_Message
            // 
            txt_Message.Location = new Point(303, 634);
            txt_Message.Multiline = true;
            txt_Message.Name = "txt_Message";
            txt_Message.Size = new Size(406, 58);
            txt_Message.TabIndex = 11;
            // 
            // btn_Send
            // 
            btn_Send.BackColor = SystemColors.MenuHighlight;
            btn_Send.Font = new Font("Stencil", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Send.Location = new Point(715, 651);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(108, 41);
            btn_Send.TabIndex = 2;
            btn_Send.Text = "Send";
            btn_Send.UseVisualStyleBackColor = false;
            btn_Send.Click += btn_Send_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btn_disconnect);
            panel1.Controls.Add(btn_connect);
            panel1.Controls.Add(listbox_User);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txt_Port);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_IPAddress);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txt_username);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(285, 680);
            panel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(59, 326);
            label4.Name = "label4";
            label4.Size = new Size(153, 29);
            label4.TabIndex = 11;
            label4.Text = "user online";
            // 
            // btn_disconnect
            // 
            btn_disconnect.BackColor = SystemColors.Window;
            btn_disconnect.Enabled = false;
            btn_disconnect.Font = new Font("Stencil", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_disconnect.Location = new Point(174, 615);
            btn_disconnect.Name = "btn_disconnect";
            btn_disconnect.Size = new Size(94, 42);
            btn_disconnect.TabIndex = 5;
            btn_disconnect.Text = "DisConnect";
            btn_disconnect.UseVisualStyleBackColor = false;
            btn_disconnect.Click += btn_disconnect_Click;
            // 
            // btn_connect
            // 
            btn_connect.BackColor = SystemColors.Window;
            btn_connect.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_connect.Location = new Point(24, 615);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(96, 42);
            btn_connect.TabIndex = 4;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = false;
            btn_connect.Click += btn_connect_Click;
            // 
            // listbox_User
            // 
            listbox_User.FormattingEnabled = true;
            listbox_User.Location = new Point(24, 367);
            listbox_User.Name = "listbox_User";
            listbox_User.Size = new Size(244, 204);
            listbox_User.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 285);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 8;
            label3.Text = "Port";
            // 
            // txt_Port
            // 
            txt_Port.BackColor = SystemColors.InactiveCaption;
            txt_Port.Location = new Point(92, 281);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(176, 27);
            txt_Port.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(91, 147);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 6;
            label1.Text = "USER NAME";
            // 
            // txt_IPAddress
            // 
            txt_IPAddress.BackColor = SystemColors.InactiveCaption;
            txt_IPAddress.Location = new Point(24, 229);
            txt_IPAddress.Name = "txt_IPAddress";
            txt_IPAddress.Size = new Size(244, 27);
            txt_IPAddress.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(85, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 115);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(85, 206);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 7;
            label2.Text = "IP Address";
            // 
            // txt_username
            // 
            txt_username.BackColor = SystemColors.InactiveCaption;
            txt_username.Location = new Point(24, 170);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(244, 27);
            txt_username.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 9);
            label5.Name = "label5";
            label5.Size = new Size(166, 29);
            label5.TabIndex = 8;
            label5.Text = "MESSAGE BOX";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txt_status);
            panel2.Location = new Point(303, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 61);
            panel2.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(10, 16);
            label6.Name = "label6";
            label6.Size = new Size(108, 29);
            label6.TabIndex = 10;
            label6.Text = "Status :";
            // 
            // txt_status
            // 
            txt_status.Location = new Point(124, 18);
            txt_status.Multiline = true;
            txt_status.Name = "txt_status";
            txt_status.Size = new Size(375, 27);
            txt_status.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(label5);
            panel3.Location = new Point(445, 79);
            panel3.Name = "panel3";
            panel3.Size = new Size(227, 47);
            panel3.TabIndex = 10;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(837, 704);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btn_Send);
            Controls.Add(txt_Message);
            Controls.Add(listbox_result);
            Name = "Client";
            Text = "Client";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listbox_result;
        private TextBox txt_Message;
        private Button btn_Send;
        private Panel panel1;
        private TextBox txt_Port;
        private TextBox txt_IPAddress;
        private TextBox txt_username;
        private PictureBox pictureBox1;
        private Button btn_disconnect;
        private Button btn_connect;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private ListBox listbox_User;
        private TextBox txt_status;
        private Panel panel3;
        private Label label4;
        private Label label6;
    }
}
