namespace PRL.Views
{
    partial class TopSanPham
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
            groupBox1 = new GroupBox();
            dateKetThuc = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateBatDau = new Label();
            dateTimePicker1 = new DateTimePicker();
            dgrTopSP = new DataGridView();
            label1 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgrTopSP).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateKetThuc);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateBatDau);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(dgrTopSP);
            groupBox1.Location = new Point(26, 110);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(972, 544);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Top 10 bán chạy";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dateKetThuc
            // 
            dateKetThuc.AutoSize = true;
            dateKetThuc.Location = new Point(306, 50);
            dateKetThuc.Name = "dateKetThuc";
            dateKetThuc.Size = new Size(100, 20);
            dateKetThuc.TabIndex = 4;
            dateKetThuc.Text = "Ngày kết thúc";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(431, 43);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(118, 27);
            dateTimePicker2.TabIndex = 3;
            dateTimePicker2.Value = new DateTime(2024, 4, 2, 0, 0, 0, 0);
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateBatDau
            // 
            dateBatDau.AutoSize = true;
            dateBatDau.Location = new Point(26, 50);
            dateBatDau.Name = "dateBatDau";
            dateBatDau.Size = new Size(99, 20);
            dateBatDau.TabIndex = 2;
            dateBatDau.Text = "Ngày bắt đầu";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(162, 43);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(116, 27);
            dateTimePicker1.TabIndex = 1;
            dateTimePicker1.Value = new DateTime(2024, 4, 2, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dgrTopSP
            // 
            dgrTopSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrTopSP.Location = new Point(6, 131);
            dgrTopSP.Name = "dgrTopSP";
            dgrTopSP.RowHeadersWidth = 51;
            dgrTopSP.Size = new Size(949, 392);
            dgrTopSP.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 30);
            label1.Name = "label1";
            label1.Size = new Size(324, 38);
            label1.TabIndex = 3;
            label1.Text = "Top sản phẩm bán chạy";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(455, 60);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 8;
            label5.Text = "Tổng tiền";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(586, 30);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 57);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // TopSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 684);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "TopSanPham";
            Text = "TopSanPham";
            Load += TopSanPham_Load_2;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgrTopSP).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label dateBatDau;
        private DateTimePicker dateTimePicker1;
        private DataGridView dgrTopSP;
        private Label dateKetThuc;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label5;
        private TextBox textBox1;
    }
}