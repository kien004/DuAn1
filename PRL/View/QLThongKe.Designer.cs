namespace PRL.Views
{
    partial class QLThongKe
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            dgrTopKH = new DataGridView();
            groupBox2 = new GroupBox();
            dgrTopSanPham = new DataGridView();
            groupBox3 = new GroupBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            menuStrip1 = new MenuStrip();
            topsToolStripMenuItem = new ToolStripMenuItem();
            thốngKêSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            thốngKêKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            comboBox3 = new ComboBox();
            label4 = new Label();
            groupBox4 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgrTopKH).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgrTopSanPham).BeginInit();
            groupBox3.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(184, 31);
            label1.Name = "label1";
            label1.Size = new Size(232, 62);
            label1.TabIndex = 0;
            label1.Text = "Thống kê";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgrTopKH);
            groupBox1.Location = new Point(25, 259);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(509, 375);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Top Khách ";
            // 
            // dgrTopKH
            // 
            dgrTopKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrTopKH.Location = new Point(6, 68);
            dgrTopKH.Name = "dgrTopKH";
            dgrTopKH.RowHeadersWidth = 51;
            dgrTopKH.Size = new Size(497, 284);
            dgrTopKH.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgrTopSanPham);
            groupBox2.Location = new Point(551, 259);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(700, 375);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Top bán chạy ";
            // 
            // dgrTopSanPham
            // 
            dgrTopSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrTopSanPham.Location = new Point(51, 44);
            dgrTopSanPham.Name = "dgrTopSanPham";
            dgrTopSanPham.RowHeadersWidth = 51;
            dgrTopSanPham.Size = new Size(607, 308);
            dgrTopSanPham.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Location = new Point(654, 31);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(527, 211);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tổng doanh thu ";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(203, 106);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 57);
            textBox2.TabIndex = 8;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(62, 136);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 7;
            label6.Text = "Tổng hóa đơn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 72);
            label5.Name = "label5";
            label5.Size = new Size(72, 20);
            label5.TabIndex = 6;
            label5.Text = "Tổng tiền";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(203, 35);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 57);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { topsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1299, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // topsToolStripMenuItem
            // 
            topsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thốngKêSảnPhẩmToolStripMenuItem, thốngKêKháchHàngToolStripMenuItem });
            topsToolStripMenuItem.Name = "topsToolStripMenuItem";
            topsToolStripMenuItem.Size = new Size(132, 24);
            topsToolStripMenuItem.Text = "Chi tiết thống kê";
            // 
            // thốngKêSảnPhẩmToolStripMenuItem
            // 
            thốngKêSảnPhẩmToolStripMenuItem.Name = "thốngKêSảnPhẩmToolStripMenuItem";
            thốngKêSảnPhẩmToolStripMenuItem.Size = new Size(232, 26);
            thốngKêSảnPhẩmToolStripMenuItem.Text = "Thống kê sản phẩm";
            thốngKêSảnPhẩmToolStripMenuItem.Click += thốngKêSảnPhẩmToolStripMenuItem_Click;
            // 
            // thốngKêKháchHàngToolStripMenuItem
            // 
            thốngKêKháchHàngToolStripMenuItem.Name = "thốngKêKháchHàngToolStripMenuItem";
            thốngKêKháchHàngToolStripMenuItem.Size = new Size(232, 26);
            thốngKêKháchHàngToolStripMenuItem.Text = "Thống kê khách hàng";
            thốngKêKháchHàngToolStripMenuItem.Click += thốngKêKháchHàngToolStripMenuItem_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(201, 34);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 5;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 42);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 6;
            label4.Text = "Tính doanh thu theo";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox3);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(90, 115);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(394, 85);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            // 
            // QLThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1299, 659);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "QLThongKe";
            Text = "QLThongKe";
            Load += QLThongKe_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgrTopKH).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgrTopSanPham).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private DataGridView dgrTopSanPham;
        private GroupBox groupBox3;
        private Label label3;
        private ComboBox comboBox2;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem topsToolStripMenuItem;
        private DataGridView dgrTopKH;
        private ToolStripMenuItem thốngKêSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem thốngKêKháchHàngToolStripMenuItem;
        private ComboBox comboBox3;
        private Label label4;
        private GroupBox groupBox4;
    }
}