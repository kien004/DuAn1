namespace PRL.Views
{
    partial class TopKhachHang
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
            groupBox2 = new GroupBox();
            dateKetThuc = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateBatDau = new Label();
            dateTimePicker1 = new DateTimePicker();
            dgrTopKhachHang = new DataGridView();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgrTopKhachHang).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dateKetThuc);
            groupBox2.Controls.Add(dateTimePicker2);
            groupBox2.Controls.Add(dateBatDau);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(dgrTopKhachHang);
            groupBox2.Location = new Point(50, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1063, 602);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Top 10 nạp vip";
            // 
            // dateKetThuc
            // 
            dateKetThuc.AutoSize = true;
            dateKetThuc.Location = new Point(433, 38);
            dateKetThuc.Name = "dateKetThuc";
            dateKetThuc.Size = new Size(100, 20);
            dateKetThuc.TabIndex = 8;
            dateKetThuc.Text = "Ngày kết thúc";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(558, 31);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(118, 27);
            dateTimePicker2.TabIndex = 7;
            dateTimePicker2.Value = new DateTime(2024, 4, 2, 0, 0, 0, 0);
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // dateBatDau
            // 
            dateBatDau.AutoSize = true;
            dateBatDau.Location = new Point(153, 38);
            dateBatDau.Name = "dateBatDau";
            dateBatDau.Size = new Size(99, 20);
            dateBatDau.TabIndex = 6;
            dateBatDau.Text = "Ngày bắt đầu";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(289, 31);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(116, 27);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2024, 4, 2, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dgrTopKhachHang
            // 
            dgrTopKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrTopKhachHang.Location = new Point(62, 96);
            dgrTopKhachHang.Name = "dgrTopKhachHang";
            dgrTopKhachHang.RowHeadersWidth = 51;
            dgrTopKhachHang.Size = new Size(964, 480);
            dgrTopKhachHang.TabIndex = 0;
            dgrTopKhachHang.CellContentClick += dataGridView2_CellContentClick;
            // 
            // TopKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 652);
            Controls.Add(groupBox2);
            Name = "TopKhachHang";
            Text = "TopKhachHang";
            Load += TopKhachHang_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgrTopKhachHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dgrTopKhachHang;
        private Label dateKetThuc;
        private DateTimePicker dateTimePicker2;
        private Label dateBatDau;
        private DateTimePicker dateTimePicker1;
    }
}