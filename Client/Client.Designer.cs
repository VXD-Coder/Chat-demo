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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_disconnect = new Button();
            btn_connect = new Button();
            pictureBox1 = new PictureBox();
            txt_Port = new TextBox();
            txt_IPAddress = new TextBox();
            txt_username = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listbox_result
            // 
            listbox_result.FormattingEnabled = true;
            listbox_result.Location = new Point(303, 44);
            listbox_result.Name = "listbox_result";
            listbox_result.Size = new Size(520, 364);
            listbox_result.TabIndex = 0;
            // 
            // txt_Message
            // 
            txt_Message.Enabled = false;
            txt_Message.Location = new Point(303, 414);
            txt_Message.Multiline = true;
            txt_Message.Name = "txt_Message";
            txt_Message.Size = new Size(406, 57);
            txt_Message.TabIndex = 1;
            // 
            // btn_Send
            // 
            btn_Send.BackColor = SystemColors.MenuHighlight;
            btn_Send.Enabled = false;
            btn_Send.Font = new Font("Stencil", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Send.Location = new Point(715, 430);
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
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btn_disconnect);
            panel1.Controls.Add(btn_connect);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txt_Port);
            panel1.Controls.Add(txt_IPAddress);
            panel1.Controls.Add(txt_username);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(285, 459);
            panel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(119, 304);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 8;
            label3.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(95, 234);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 7;
            label2.Text = "IP Address";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(95, 164);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 6;
            label1.Text = "USER NAME";
            // 
            // btn_disconnect
            // 
            btn_disconnect.BackColor = SystemColors.Window;
            btn_disconnect.Enabled = false;
            btn_disconnect.Font = new Font("Stencil", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_disconnect.Location = new Point(174, 393);
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
            btn_connect.Location = new Point(24, 393);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(96, 42);
            btn_connect.TabIndex = 4;
            btn_connect.Text = "Connect";
            btn_connect.UseVisualStyleBackColor = false;
            btn_connect.Click += btn_connect_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(74, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 115);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // txt_Port
            // 
            txt_Port.BackColor = SystemColors.InactiveCaption;
            txt_Port.Location = new Point(24, 327);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(244, 27);
            txt_Port.TabIndex = 2;
            // 
            // txt_IPAddress
            // 
            txt_IPAddress.BackColor = SystemColors.InactiveCaption;
            txt_IPAddress.Location = new Point(24, 257);
            txt_IPAddress.Name = "txt_IPAddress";
            txt_IPAddress.Size = new Size(244, 27);
            txt_IPAddress.TabIndex = 1;
            // 
            // txt_username
            // 
            txt_username.BackColor = SystemColors.InactiveCaption;
            txt_username.Location = new Point(24, 187);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(244, 27);
            txt_username.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(476, 12);
            label5.Name = "label5";
            label5.Size = new Size(166, 29);
            label5.TabIndex = 8;
            label5.Text = "MESSAGE BOX";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(837, 486);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(btn_Send);
            Controls.Add(txt_Message);
            Controls.Add(listbox_result);
            Name = "Client";
            Text = "Client";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}
