namespace Project_SHOE.View
{
    partial class ResetPass
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            txt_sdt = new TextBox();
            txt_newpass = new TextBox();
            txt_confirmpass = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label2.Location = new Point(41, 95);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 1;
            label2.Text = "Số Điện Thoại";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(41, 196);
            label3.Name = "label3";
            label3.Size = new Size(133, 25);
            label3.TabIndex = 2;
            label3.Text = "Mật Khẩu Mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label4.Location = new Point(41, 252);
            label4.Name = "label4";
            label4.Size = new Size(182, 25);
            label4.TabIndex = 3;
            label4.Text = "Xác Nhận Mật Khẩu";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            button1.Location = new Point(219, 324);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Lưu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txt_sdt
            // 
            txt_sdt.Location = new Point(248, 96);
            txt_sdt.Name = "txt_sdt";
            txt_sdt.Size = new Size(242, 27);
            txt_sdt.TabIndex = 5;
            // 
            // txt_newpass
            // 
            txt_newpass.Location = new Point(246, 194);
            txt_newpass.Name = "txt_newpass";
            txt_newpass.Size = new Size(242, 27);
            txt_newpass.TabIndex = 6;
            // 
            // txt_confirmpass
            // 
            txt_confirmpass.Location = new Point(248, 253);
            txt_confirmpass.Name = "txt_confirmpass";
            txt_confirmpass.Size = new Size(242, 27);
            txt_confirmpass.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(133, 19);
            label1.Name = "label1";
            label1.Size = new Size(269, 46);
            label1.TabIndex = 22;
            label1.Text = "Quên Mật Khẩu";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(246, 145);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(242, 27);
            textBox1.TabIndex = 24;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label5.Location = new Point(39, 144);
            label5.Name = "label5";
            label5.Size = new Size(122, 25);
            label5.TabIndex = 23;
            label5.Text = "Mật Khẩu Cũ";
            // 
            // ResetPass
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 365);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(txt_confirmpass);
            Controls.Add(txt_newpass);
            Controls.Add(txt_sdt);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "ResetPass";
            Text = "ResetPass";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private TextBox txt_sdt;
        private TextBox txt_newpass;
        private TextBox txt_confirmpass;
        private Label label1;
        private TextBox textBox1;
        private Label label5;
    }
}