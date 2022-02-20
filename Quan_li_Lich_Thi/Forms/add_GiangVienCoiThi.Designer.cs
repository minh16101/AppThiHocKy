
namespace Quan_li_Lich_Thi.Forms
{
    partial class add_GiangVienCoiThi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_GiangVienCoiThi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView_GiangVien = new System.Windows.Forms.ListView();
            this.columnHeader_MSGV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_TenGV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Khoa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Khoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cb_MaSoGiangVien = new System.Windows.Forms.ComboBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.txt_TenGV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listView_GiangVien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 145);
            this.panel1.TabIndex = 0;
            // 
            // listView_GiangVien
            // 
            this.listView_GiangVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_MSGV,
            this.columnHeader_TenGV,
            this.columnHeader_Khoa});
            this.listView_GiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_GiangVien.FullRowSelect = true;
            this.listView_GiangVien.GridLines = true;
            this.listView_GiangVien.HideSelection = false;
            this.listView_GiangVien.Location = new System.Drawing.Point(0, 0);
            this.listView_GiangVien.Name = "listView_GiangVien";
            this.listView_GiangVien.Size = new System.Drawing.Size(489, 145);
            this.listView_GiangVien.TabIndex = 1;
            this.listView_GiangVien.UseCompatibleStateImageBehavior = false;
            this.listView_GiangVien.View = System.Windows.Forms.View.Details;
            this.listView_GiangVien.SelectedIndexChanged += new System.EventHandler(this.listView_GiangVien_SelectedIndexChanged);
            // 
            // columnHeader_MSGV
            // 
            this.columnHeader_MSGV.Text = "Mã Số Giảng Viên";
            this.columnHeader_MSGV.Width = 102;
            // 
            // columnHeader_TenGV
            // 
            this.columnHeader_TenGV.Text = "Tên Giảng Viên";
            this.columnHeader_TenGV.Width = 219;
            // 
            // columnHeader_Khoa
            // 
            this.columnHeader_Khoa.Text = "Khoa ";
            this.columnHeader_Khoa.Width = 164;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_Khoa);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btn_reset);
            this.panel2.Controls.Add(this.cb_MaSoGiangVien);
            this.panel2.Controls.Add(this.btn_them);
            this.panel2.Controls.Add(this.btn_Xoa);
            this.panel2.Controls.Add(this.btn_Luu);
            this.panel2.Controls.Add(this.txt_TenGV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 174);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txt_Khoa
            // 
            this.txt_Khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Khoa.Location = new System.Drawing.Point(151, 84);
            this.txt_Khoa.Multiline = true;
            this.txt_Khoa.Name = "txt_Khoa";
            this.txt_Khoa.ReadOnly = true;
            this.txt_Khoa.Size = new System.Drawing.Size(276, 31);
            this.txt_Khoa.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Khoa";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.FlatAppearance.BorderSize = 0;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Image = ((System.Drawing.Image)(resources.GetObject("btn_reset.Image")));
            this.btn_reset.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_reset.Location = new System.Drawing.Point(387, 121);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(90, 50);
            this.btn_reset.TabIndex = 38;
            this.btn_reset.Text = "Reset";
            this.btn_reset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // cb_MaSoGiangVien
            // 
            this.cb_MaSoGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MaSoGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_MaSoGiangVien.FormattingEnabled = true;
            this.cb_MaSoGiangVien.Location = new System.Drawing.Point(151, 8);
            this.cb_MaSoGiangVien.Name = "cb_MaSoGiangVien";
            this.cb_MaSoGiangVien.Size = new System.Drawing.Size(276, 32);
            this.cb_MaSoGiangVien.Sorted = true;
            this.cb_MaSoGiangVien.TabIndex = 37;
            this.cb_MaSoGiangVien.SelectedIndexChanged += new System.EventHandler(this.cb_MaSoGiangVien_SelectedIndexChanged);
            // 
            // btn_them
            // 
            this.btn_them.FlatAppearance.BorderSize = 0;
            this.btn_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_them.Location = new System.Drawing.Point(27, 118);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(90, 50);
            this.btn_them.TabIndex = 36;
            this.btn_them.Text = "Thêm";
            this.btn_them.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.FlatAppearance.BorderSize = 0;
            this.btn_Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Xoa.Location = new System.Drawing.Point(151, 118);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(90, 50);
            this.btn_Xoa.TabIndex = 35;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.FlatAppearance.BorderSize = 0;
            this.btn_Luu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.Image = ((System.Drawing.Image)(resources.GetObject("btn_Luu.Image")));
            this.btn_Luu.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Luu.Location = new System.Drawing.Point(275, 118);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(90, 50);
            this.btn_Luu.TabIndex = 34;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // txt_TenGV
            // 
            this.txt_TenGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenGV.Location = new System.Drawing.Point(151, 46);
            this.txt_TenGV.Multiline = true;
            this.txt_TenGV.Name = "txt_TenGV";
            this.txt_TenGV.ReadOnly = true;
            this.txt_TenGV.Size = new System.Drawing.Size(276, 31);
            this.txt_TenGV.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tên Giảng Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã Số Giảng Viên";
            // 
            // add_GiangVienCoiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 319);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "add_GiangVienCoiThi";
            this.Text = "GiangVien";
            this.Load += new System.EventHandler(this.ThemGiangVienCoiThi_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView_GiangVien;
        private System.Windows.Forms.ColumnHeader columnHeader_MSGV;
        private System.Windows.Forms.ColumnHeader columnHeader_TenGV;
        private System.Windows.Forms.ColumnHeader columnHeader_Khoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_Khoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ComboBox cb_MaSoGiangVien;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.TextBox txt_TenGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}