namespace quanlycafe
{
    partial class frmHelp
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
            this.components = new System.ComponentModel.Container();
            this.lblNhien = new System.Windows.Forms.Label();
            this.lblHai = new System.Windows.Forms.Label();
            this.lblThay = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnThay = new System.Windows.Forms.Button();
            this.btnHai = new System.Windows.Forms.Button();
            this.btnNhien = new System.Windows.Forms.Button();
            this.btnTruong = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNhien
            // 
            this.lblNhien.BackColor = System.Drawing.Color.Salmon;
            this.lblNhien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhien.ForeColor = System.Drawing.Color.Red;
            this.lblNhien.Location = new System.Drawing.Point(614, 321);
            this.lblNhien.Name = "lblNhien";
            this.lblNhien.Size = new System.Drawing.Size(184, 18);
            this.lblNhien.TabIndex = 28;
            this.lblNhien.Text = "Nguyễn Văn Huy";
            this.lblNhien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNhien.Click += new System.EventHandler(this.lblNhien_Click_1);
            // 
            // lblHai
            // 
            this.lblHai.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblHai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHai.ForeColor = System.Drawing.Color.Red;
            this.lblHai.Location = new System.Drawing.Point(420, 321);
            this.lblHai.Name = "lblHai";
            this.lblHai.Size = new System.Drawing.Size(184, 18);
            this.lblHai.TabIndex = 27;
            this.lblHai.Text = "Ngô Đình Hải";
            this.lblHai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHai.Click += new System.EventHandler(this.lblHai_Click_1);
            // 
            // lblThay
            // 
            this.lblThay.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblThay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThay.ForeColor = System.Drawing.Color.Red;
            this.lblThay.Location = new System.Drawing.Point(8, 288);
            this.lblThay.Name = "lblThay";
            this.lblThay.Size = new System.Drawing.Size(303, 52);
            this.lblThay.TabIndex = 26;
            this.lblThay.Text = "GVHD: Trương Thị Ngọc Phượng";
            this.lblThay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThay.Click += new System.EventHandler(this.lblThay_Click_1);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Gray;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(319, 165);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(92, 175);
            this.lblTime.TabIndex = 25;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 36);
            this.panel1.TabIndex = 29;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(339, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 19;
            this.label1.Text = "Hỗ Trợ";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Image = global::quanlycafe.Properties.Resources.Very_Basic_Cancel_icon__1_;
            this.btnClose.Location = new System.Drawing.Point(777, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 26);
            this.btnClose.TabIndex = 18;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnThay
            // 
            this.btnThay.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThay.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThay.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnThay.Image = global::quanlycafe.Properties.Resources.Teacher_female_icon;
            this.btnThay.Location = new System.Drawing.Point(8, 42);
            this.btnThay.Name = "btnThay";
            this.btnThay.Size = new System.Drawing.Size(303, 298);
            this.btnThay.TabIndex = 24;
            this.btnThay.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnThay.UseVisualStyleBackColor = false;
            this.btnThay.Click += new System.EventHandler(this.btnThay_Click_1);
            // 
            // btnHai
            // 
            this.btnHai.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnHai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHai.Image = global::quanlycafe.Properties.Resources.Student_Male_icon;
            this.btnHai.Location = new System.Drawing.Point(419, 165);
            this.btnHai.Name = "btnHai";
            this.btnHai.Size = new System.Drawing.Size(186, 175);
            this.btnHai.TabIndex = 23;
            this.btnHai.UseVisualStyleBackColor = false;
            this.btnHai.Click += new System.EventHandler(this.btnHai_Click_1);
            // 
            // btnNhien
            // 
            this.btnNhien.BackColor = System.Drawing.Color.Salmon;
            this.btnNhien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhien.Image = global::quanlycafe.Properties.Resources.Users_Student_2_icon;
            this.btnNhien.Location = new System.Drawing.Point(613, 165);
            this.btnNhien.Name = "btnNhien";
            this.btnNhien.Size = new System.Drawing.Size(186, 175);
            this.btnNhien.TabIndex = 22;
            this.btnNhien.UseVisualStyleBackColor = false;
            this.btnNhien.Click += new System.EventHandler(this.btnNhien_Click_1);
            // 
            // btnTruong
            // 
            this.btnTruong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruong.ForeColor = System.Drawing.Color.White;
            this.btnTruong.Image = global::quanlycafe.Properties.Resources.th;
            this.btnTruong.Location = new System.Drawing.Point(319, 42);
            this.btnTruong.Name = "btnTruong";
            this.btnTruong.Size = new System.Drawing.Size(480, 115);
            this.btnTruong.TabIndex = 21;
            this.btnTruong.UseVisualStyleBackColor = true;
            this.btnTruong.Click += new System.EventHandler(this.btnTruong_Click_1);
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(806, 348);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNhien);
            this.Controls.Add(this.lblHai);
            this.Controls.Add(this.lblThay);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnThay);
            this.Controls.Add(this.btnHai);
            this.Controls.Add(this.btnNhien);
            this.Controls.Add(this.btnTruong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHelp";
            this.Text = "frmHelp";
            this.Load += new System.EventHandler(this.frmHelp_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNhien;
        private System.Windows.Forms.Label lblHai;
        private System.Windows.Forms.Label lblThay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnThay;
        private System.Windows.Forms.Button btnHai;
        private System.Windows.Forms.Button btnNhien;
        private System.Windows.Forms.Button btnTruong;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}