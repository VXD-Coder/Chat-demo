namespace Server
{
    partial class Server
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
            txt_Message = new TextBox();
            panel1 = new Panel();
            label6 = new Label();
            btn_StartServer = new Button();
            label3 = new Label();
            label1 = new Label();
            txt_Port = new TextBox();
            txt_IPAddress = new TextBox();
            listbox_User = new ListBox();
            listbox_result = new ListBox();
            label4 = new Label();
            txt_status = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            btn_Send = new Button();
            btn_StopServer = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txt_Message
            // 
            txt_Message.Location = new Point(322, 518);
            txt_Message.Multiline = true;
            txt_Message.Name = "txt_Message";
            txt_Message.Size = new Size(462, 49);
            txt_Message.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(btn_StopServer);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btn_StartServer);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_Port);
            panel1.Controls.Add(txt_IPAddress);
            panel1.Controls.Add(listbox_User);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 555);
            panel1.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(97, 382);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 11;
            label6.Text = "IP Address";
            // 
            // btn_StartServer
            // 
            btn_StartServer.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btn_StartServer.Location = new Point(15, 499);
            btn_StartServer.Name = "btn_StartServer";
            btn_StartServer.Size = new Size(120, 34);
            btn_StartServer.TabIndex = 8;
            btn_StartServer.Text = "Start Server";
            btn_StartServer.UseVisualStyleBackColor = true;
            btn_StartServer.Click += btn_StartServer_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 457);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 5;
            label3.Text = "Port :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 18);
            label1.Name = "label1";
            label1.Size = new Size(161, 23);
            label1.TabIndex = 3;
            label1.Text = "Connected User";
            // 
            // txt_Port
            // 
            txt_Port.Enabled = false;
            txt_Port.Location = new Point(97, 453);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(187, 27);
            txt_Port.TabIndex = 2;
            txt_Port.Tag = "";
            txt_Port.Text = "9999";
            // 
            // txt_IPAddress
            // 
            txt_IPAddress.Enabled = false;
            txt_IPAddress.Location = new Point(15, 405);
            txt_IPAddress.Multiline = true;
            txt_IPAddress.Name = "txt_IPAddress";
            txt_IPAddress.Size = new Size(269, 28);
            txt_IPAddress.TabIndex = 1;
            // 
            // listbox_User
            // 
            listbox_User.BackColor = SystemColors.InactiveCaption;
            listbox_User.FormattingEnabled = true;
            listbox_User.Location = new Point(15, 54);
            listbox_User.Name = "listbox_User";
            listbox_User.Size = new Size(269, 304);
            listbox_User.TabIndex = 0;
            // 
            // listbox_result
            // 
            listbox_result.FormattingEnabled = true;
            listbox_result.Location = new Point(319, 125);
            listbox_result.Name = "listbox_result";
            listbox_result.Size = new Size(562, 384);
            listbox_result.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 18);
            label4.Name = "label4";
            label4.Size = new Size(108, 29);
            label4.TabIndex = 8;
            label4.Text = "Status :";
            // 
            // txt_status
            // 
            txt_status.Location = new Point(126, 18);
            txt_status.Multiline = true;
            txt_status.Name = "txt_status";
            txt_status.Size = new Size(418, 27);
            txt_status.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txt_status);
            panel2.Location = new Point(322, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(562, 59);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(label5);
            panel3.Location = new Point(482, 77);
            panel3.Name = "panel3";
            panel3.Size = new Size(227, 47);
            panel3.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(37, 10);
            label5.Name = "label5";
            label5.Size = new Size(166, 29);
            label5.TabIndex = 8;
            label5.Text = "MESSAGE BOX";
            // 
            // btn_Send
            // 
            btn_Send.BackColor = SystemColors.MenuHighlight;
            btn_Send.Enabled = false;
            btn_Send.Font = new Font("Stencil", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Send.Location = new Point(790, 526);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(94, 41);
            btn_Send.TabIndex = 13;
            btn_Send.Text = "Send";
            btn_Send.UseVisualStyleBackColor = false;
            btn_Send.Click += btn_Send_Click;
            // 
            // btn_StopServer
            // 
            btn_StopServer.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btn_StopServer.Location = new Point(164, 502);
            btn_StopServer.Name = "btn_StopServer";
            btn_StopServer.Size = new Size(120, 34);
            btn_StopServer.TabIndex = 12;
            btn_StopServer.Text = "Stop Server";
            btn_StopServer.UseVisualStyleBackColor = true;
            btn_StopServer.Click += btn_StopServer_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(896, 579);
            Controls.Add(btn_Send);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(listbox_result);
            Controls.Add(panel1);
            Controls.Add(txt_Message);
            Name = "Server";
            Text = "Server";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_Message;
        private Panel panel1;
        private ListBox listbox_User;
        private Label label3;
        private Label label1;
        private TextBox txt_Port;
        private TextBox txt_IPAddress;
        private ListBox listbox_result;
        private Button btn_StartServer;
        private Label label4;
        private TextBox txt_status;
        private Panel panel2;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private Button btn_Send;
        private Button btn_StopServer;
    }
}
