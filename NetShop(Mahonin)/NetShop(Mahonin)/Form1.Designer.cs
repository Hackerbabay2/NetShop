
namespace NetShop_Mahonin_
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SiginUp = new System.Windows.Forms.Button();
            this.LogingroupBox = new System.Windows.Forms.GroupBox();
            this.RegistrationgroupBox = new System.Windows.Forms.GroupBox();
            this.userLoginBox = new System.Windows.Forms.TextBox();
            this.userPasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SiginUpButton = new System.Windows.Forms.Button();
            this.LogIn = new System.Windows.Forms.Button();
            this.LogingroupBox.SuspendLayout();
            this.RegistrationgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(70, 21);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(157, 22);
            this.LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(70, 49);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(157, 22);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Войти как админ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.LoginAdminbutton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(216, 44);
            this.button3.TabIndex = 4;
            this.button3.Text = "Войти как гость";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.UserLoginbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // SiginUp
            // 
            this.SiginUp.Location = new System.Drawing.Point(438, 12);
            this.SiginUp.Name = "SiginUp";
            this.SiginUp.Size = new System.Drawing.Size(157, 44);
            this.SiginUp.TabIndex = 7;
            this.SiginUp.Text = "Регистрация";
            this.SiginUp.UseVisualStyleBackColor = true;
            this.SiginUp.Click += new System.EventHandler(this.button2_Click);
            // 
            // LogingroupBox
            // 
            this.LogingroupBox.Controls.Add(this.LoginTextBox);
            this.LogingroupBox.Controls.Add(this.PasswordTextBox);
            this.LogingroupBox.Controls.Add(this.label2);
            this.LogingroupBox.Controls.Add(this.button1);
            this.LogingroupBox.Controls.Add(this.label1);
            this.LogingroupBox.Controls.Add(this.button3);
            this.LogingroupBox.Location = new System.Drawing.Point(199, 12);
            this.LogingroupBox.Name = "LogingroupBox";
            this.LogingroupBox.Size = new System.Drawing.Size(233, 207);
            this.LogingroupBox.TabIndex = 8;
            this.LogingroupBox.TabStop = false;
            this.LogingroupBox.Text = "Вход";
            // 
            // RegistrationgroupBox
            // 
            this.RegistrationgroupBox.Controls.Add(this.userLoginBox);
            this.RegistrationgroupBox.Controls.Add(this.userPasswordBox);
            this.RegistrationgroupBox.Controls.Add(this.label3);
            this.RegistrationgroupBox.Controls.Add(this.label4);
            this.RegistrationgroupBox.Controls.Add(this.SiginUpButton);
            this.RegistrationgroupBox.Location = new System.Drawing.Point(199, 12);
            this.RegistrationgroupBox.Name = "RegistrationgroupBox";
            this.RegistrationgroupBox.Size = new System.Drawing.Size(233, 207);
            this.RegistrationgroupBox.TabIndex = 9;
            this.RegistrationgroupBox.TabStop = false;
            this.RegistrationgroupBox.Text = "Регистрация";
            // 
            // userLoginBox
            // 
            this.userLoginBox.Location = new System.Drawing.Point(70, 21);
            this.userLoginBox.Name = "userLoginBox";
            this.userLoginBox.Size = new System.Drawing.Size(157, 22);
            this.userLoginBox.TabIndex = 0;
            // 
            // userPasswordBox
            // 
            this.userPasswordBox.Location = new System.Drawing.Point(70, 49);
            this.userPasswordBox.Name = "userPasswordBox";
            this.userPasswordBox.Size = new System.Drawing.Size(157, 22);
            this.userPasswordBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Логин";
            // 
            // SiginUpButton
            // 
            this.SiginUpButton.Location = new System.Drawing.Point(11, 78);
            this.SiginUpButton.Name = "SiginUpButton";
            this.SiginUpButton.Size = new System.Drawing.Size(216, 44);
            this.SiginUpButton.TabIndex = 4;
            this.SiginUpButton.Text = "Зарегестрироваться";
            this.SiginUpButton.UseVisualStyleBackColor = true;
            this.SiginUpButton.Click += new System.EventHandler(this.SiginUpbutton_Click);
            // 
            // LogIn
            // 
            this.LogIn.Location = new System.Drawing.Point(438, 12);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(157, 44);
            this.LogIn.TabIndex = 10;
            this.LogIn.Text = "Вход";
            this.LogIn.UseVisualStyleBackColor = true;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 404);
            this.Controls.Add(this.RegistrationgroupBox);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.SiginUp);
            this.Controls.Add(this.LogingroupBox);
            this.MaximizeBox = false;
            this.Name = "Authorization";
            this.ShowIcon = false;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LogingroupBox.ResumeLayout(false);
            this.LogingroupBox.PerformLayout();
            this.RegistrationgroupBox.ResumeLayout(false);
            this.RegistrationgroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SiginUp;
        private System.Windows.Forms.GroupBox LogingroupBox;
        private System.Windows.Forms.GroupBox RegistrationgroupBox;
        private System.Windows.Forms.TextBox userLoginBox;
        private System.Windows.Forms.TextBox userPasswordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SiginUpButton;
        private System.Windows.Forms.Button LogIn;
    }
}

