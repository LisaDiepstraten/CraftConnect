namespace CraftConnectDeskPresent
{
    partial class LogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TBUserName = new TextBox();
            TBPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BEnterLog = new Button();
            BSignUp = new Button();
            SuspendLayout();
            // 
            // TBUserName
            // 
            TBUserName.Location = new Point(435, 184);
            TBUserName.Name = "TBUserName";
            TBUserName.Size = new Size(200, 39);
            TBUserName.TabIndex = 0;
            // 
            // TBPassword
            // 
            TBPassword.Location = new Point(435, 254);
            TBPassword.Name = "TBPassword";
            TBPassword.PasswordChar = '*';
            TBPassword.Size = new Size(200, 39);
            TBPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 184);
            label1.Name = "label1";
            label1.Size = new Size(121, 32);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(274, 261);
            label2.Name = "label2";
            label2.Size = new Size(111, 32);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // BEnterLog
            // 
            BEnterLog.Location = new Point(435, 351);
            BEnterLog.Name = "BEnterLog";
            BEnterLog.Size = new Size(150, 46);
            BEnterLog.TabIndex = 4;
            BEnterLog.Text = "enter";
            BEnterLog.UseVisualStyleBackColor = true;
            BEnterLog.Click += BEnterLog_Click;
            // 
            // BSignUp
            // 
            BSignUp.Location = new Point(620, 538);
            BSignUp.Name = "BSignUp";
            BSignUp.Size = new Size(150, 46);
            BSignUp.TabIndex = 5;
            BSignUp.Text = "sign up";
            BSignUp.UseVisualStyleBackColor = true;
            BSignUp.Click += BSignUp_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 877);
            Controls.Add(BSignUp);
            Controls.Add(BEnterLog);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TBPassword);
            Controls.Add(TBUserName);
            Name = "LogIn";
            Text = "LogIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TBUserName;
        private TextBox TBPassword;
        private Label label1;
        private Label label2;
        private Button BEnterLog;
        private Button BSignUp;
    }
}