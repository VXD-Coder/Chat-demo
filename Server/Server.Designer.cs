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
            btn_Send = new Button();
            panel1 = new Panel();
            btn_StopServer = new Button();
            btn_StartServer = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txt_Port = new TextBox();
            txt_IPAddress = new TextBox();
            listbox_User = new ListBox();
            listbox_result = new ListBox();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txt_Message
            // 
            txt_Message.Enabled = false;
            txt_Message.Location = new Point(319, 515);
            txt_Message.Multiline = true;
            txt_Message.Name = "txt_Message";
            txt_Message.Size = new Size(462, 52);
            txt_Message.TabIndex = 2;
            txt_Message.TextChanged += textBox3_TextChanged;
            // 
            // btn_Send
            // 
            btn_Send.BackColor = SystemColors.MenuHighlight;
            btn_Send.Enabled = false;
            btn_Send.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Send.Location = new Point(790, 525);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(94, 42);
            btn_Send.TabIndex = 3;
            btn_Send.Text = "Send";
            btn_Send.UseVisualStyleBackColor = false;
            btn_Send.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(btn_StopServer);
            panel1.Controls.Add(btn_StartServer);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_Port);
            panel1.Controls.Add(txt_IPAddress);
            panel1.Controls.Add(listbox_User);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 555);
            panel1.TabIndex = 5;
            // 
            // btn_StopServer
            // 
            btn_StopServer.Enabled = false;
            btn_StopServer.Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_StopServer.Location = new Point(168, 476);
            btn_StopServer.Name = "btn_StopServer";
            btn_StopServer.Size = new Size(116, 34);
            btn_StopServer.TabIndex = 9;
            btn_StopServer.Text = "Stop Server";
            btn_StopServer.UseVisualStyleBackColor = true;
            btn_StopServer.Click += button3_Click;
            // 
            // btn_StartServer
            // 
            btn_StartServer.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btn_StartServer.Location = new Point(15, 476);
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
            label3.Location = new Point(118, 374);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 5;
            label3.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Stencil", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(97, 310);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 4;
            label2.Text = "IP Address";
            label2.Click += label2_Click;
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
            txt_Port.Location = new Point(15, 397);
            txt_Port.Name = "txt_Port";
            txt_Port.Size = new Size(269, 27);
            txt_Port.TabIndex = 2;
            // 
            // txt_IPAddress
            // 
            txt_IPAddress.Location = new Point(15, 333);
            txt_IPAddress.Name = "txt_IPAddress";
            txt_IPAddress.Size = new Size(269, 27);
            txt_IPAddress.TabIndex = 1;
            // 
            // listbox_User
            // 
            listbox_User.BackColor = SystemColors.InactiveCaption;
            listbox_User.FormattingEnabled = true;
            listbox_User.Location = new Point(15, 54);
            listbox_User.Name = "listbox_User";
            listbox_User.Size = new Size(269, 244);
            listbox_User.TabIndex = 0;
            // 
            // listbox_result
            // 
            listbox_result.FormattingEnabled = true;
            listbox_result.Location = new Point(319, 58);
            listbox_result.Name = "listbox_result";
            listbox_result.Size = new Size(562, 444);
            listbox_result.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Showcard Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(525, 12);
            label5.Name = "label5";
            label5.Size = new Size(166, 29);
            label5.TabIndex = 7;
            label5.Text = "MESSAGE BOX";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(896, 579);
            Controls.Add(label5);
            Controls.Add(listbox_result);
            Controls.Add(panel1);
            Controls.Add(btn_Send);
            Controls.Add(txt_Message);
            Name = "Server";
            Text = "Server";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_Message;
        private Button btn_Send;
        private Panel panel1;
        private ListBox listbox_User;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txt_Port;
        private TextBox txt_IPAddress;
        private ListBox listbox_result;
        private Button btn_StopServer;
        private Button btn_StartServer;
        private Label label5;
    }
}
