using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe.capnhat
{
    public partial class frm_mon : Form
    {
        bool Adding = false;
        bool Updating = false;
        public frm_mon()
        {
            InitializeComponent();
        }
        SqlConnection cn;

        SqlDataAdapter da;
        DataTable dt;

        BindingSource bs;

        BindingManagerBase danhsach;
        bool flag = false;

        string tenhinh = "";

        public void moketnoi()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=DESKTOP-12J6D6C\SQLEXPRESS;Initial Catalog=qlcf_lamlai;Integrated Security=True";
            cn.Open();
        }
        public void dongketnoi()
        {
            cn.Close();
        }


        public DataTable laydulieu(string sql)
        {
            moketnoi();
            dt = new DataTable();
            da = new SqlDataAdapter(sql, cn);
            da.FillSchema(dt,SchemaType.Mapped);
            da.Fill(dt);
            return dt;
        }

        public void do_dulieu_vao_combobox_loaimon()
        {
            dt = laydulieu("select * from loaimon");
            cbbLoaiMon.DataSource = dt;
            cbbLoaiMon.DisplayMember = "tenloai";
            cbbLoaiMon.ValueMember = "maloai";
        }
        public void do_dulieu_vao_combobox_donvi()
        {
            dt = laydulieu("select * from mon");
        }
        public void DoDuLieu_Vao_DatagridView()
        {
            dt = laydulieu("select * from mon");

            bs = new BindingSource();
            bs.DataSource = dt;

            danhsach = BindingContext[bs];
            dataGridView1.DataSource = bs;            
            bindingNavigator1.BindingSource = bs;

        }

        void danhsach_CurrentChanged(object sender, EventArgs e)
        {
            if (flag == false)
            {
                DataRowView row = (DataRowView)danhsach.Current;
                tbMaMon.Text = row[0].ToString();
                tbTenMon.Text = row[1].ToString();
                tbDonGia.Text = row[2].ToString();
                cbbDonViTinh.Text = row[3].ToString();
                if (row[4].ToString() != "")
                    ptbHinh.Load(Application.StartupPath + "\\image\\" + row[4].ToString());
                else
                    ptbHinh.Image = null;
                cbbLoaiMon.SelectedValue = row[5].ToString();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frm_mon_Load(object sender, EventArgs e)
        {
            do_dulieu_vao_combobox_loaimon();
            DoDuLieu_Vao_DatagridView();
            danhsach_CurrentChanged(sender, e);
        }

        private void ptbHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(JPEG files)|*.jpg";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ptbHinh.Load(open.FileName);
                tenhinh = open.FileName;
                MessageBox.Show(tenhinh);
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Adding = true;
            Updating = false;
            flag = true;
            tbMaMon.Text = tbTenMon.Text = tbDonGia.Text = cbbDonViTinh.Text = cbbLoaiMon.Text = "";
            btThem.Enabled = false;
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            dataGridView1.Enabled = false;
            tbMaMon.Focus();
            
        }
        private bool kiem_tra_du_lieu_truoc_khi_luu()
        {
            if (tbMaMon.Text == "")
            {
                MessageBox.Show("Phải nhập mã món!", "Thông báo");
                tbMaMon.Text = "";

                tbMaMon.Focus();
                return false;
            }
            try
            {
                double dongia = Convert.ToDouble(tbDonGia.Text); 
            }
            catch
            {
                MessageBox.Show("Đơn giá nhập không hợp lệ!", "Thông báo");
                tbDonGia.Text="";
                tbDonGia.Focus();
                return false;
                
            }
            //kiểm tra khóa chính
            if (dt.Rows.Contains(tbMaMon.Text))
            {
                MessageBox.Show("Mã món bị trùng!", "Thông báo");
                tbMaMon.Text = "";
                tbMaMon.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
           if (kiem_tra_du_lieu_truoc_khi_luu() == false) return;

            danhsach.AddNew();
            DataRowView row = (DataRowView)danhsach.Current;
            row[0] = tbMaMon.Text;
            row[1] = tbTenMon.Text;
            row[2] = tbDonGia.Text;
            row[3] = cbbDonViTinh.Text;
            if (tenhinh != "")
            {
                string ten = tenhinh.Substring(tenhinh.LastIndexOf("\\") + 1);
                row[4] = ten;
                System.IO.File.Copy(tenhinh, Application.StartupPath + "\\image\\" + ten);
                tenhinh = "";
            }
            row[5] = cbbLoaiMon.SelectedValue;
            danhsach.EndCurrentEdit();

            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Lưu thành công!");
            if (flag) flag = false;

            btThem.Enabled = true;
            btLuu.Enabled = false;
            btSua.Enabled = true;
            btXoa.Enabled = true;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)danhsach.Current;
            row[0] = tbMaMon.Text;
            row[1] = tbTenMon.Text;
            row[2] = tbDonGia.Text;
            row[3] = cbbDonViTinh.Text;
            if (tenhinh != "")
            {
                string ten = tenhinh.Substring(tenhinh.LastIndexOf("\\") + 1);
                row[4] = ten;
                System.IO.File.Copy(tenhinh, Application.StartupPath + "\\image\\" + ten);
                tenhinh = "";
            }
            row[5] = cbbLoaiMon.SelectedValue;
            danhsach.EndCurrentEdit();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Sửa thành công!");
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt.Rows[danhsach.Position].Delete();
            da.Update(dt);
            MessageBox.Show("Xóa thành công!");
        }

        private void tbMaMon_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbDonViTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//chi chon ko dc nhap
        }

        private void cbbLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbLoaiMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//chi chon ko dc nhap
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            danhsach.CurrentChanged += danhsach_CurrentChanged;
        }
        
    }
}
