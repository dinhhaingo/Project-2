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

namespace QuanLyCafe.TimKiem
{
    public partial class frm_timkiemmon : Form
    {
        public frm_timkiemmon()
        {
            InitializeComponent();
        }

        SqlConnection cn;
        SqlDataAdapter da;
        DataTable dt;

        bool flag = false;

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
            da.Fill(dt);
            dongketnoi();
            return dt;
        }
        public void do_dulieu_vao_combobox_loaimon()
        {
            dt = laydulieu("select * from loaimon");
            cbbMaLoai.DataSource = dt;
            cbbMaLoai.DisplayMember = "tenloai";
            cbbMaLoai.ValueMember = "maloai";
            cbbMaLoai.Text = "";
        }
        private string tao_chuoi_dieu_kien()
        {
            string dieu_kien = "";
            string kethop = " or ";
            if (rdbtAnd.Checked) kethop = " and ";
            if (tbMaMon.Text != "")
                dieu_kien += ((dieu_kien != "") ? kethop : "") + "(mamon = '" + tbMaMon.Text + "')";
            if (tbTenMon.Text != "")
                dieu_kien += ((dieu_kien != "") ? kethop : "") + "(tenmon like N'%" + tbMaMon.Text + "%')";
            if (cbbTuGia.Text != "")
                dieu_kien += ((dieu_kien != "") ? kethop : "") + "(dongia >= " + cbbTuGia.Text + ")";
            if (cbbDenGia.Text != "")
                dieu_kien += ((dieu_kien != "") ? kethop : "") + "(dongia <= " + cbbDenGia.Text + ")";
            if (cbbDVTinh.Text != "")
                dieu_kien += ((dieu_kien != "") ? kethop : "") + "(dvtinh = N'" + cbbDVTinh.Text + "')";
            if (cbbMaLoai.Text != "")
                dieu_kien += ((dieu_kien != "") ? kethop : "") + "(maloai = '" + cbbMaLoai.SelectedValue.ToString() + "')";
            MessageBox.Show(dieu_kien);
            return dieu_kien;
        }
        private void frm_timkiemmon_Load(object sender, EventArgs e)
        {
            do_dulieu_vao_combobox_loaimon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            string dk = tao_chuoi_dieu_kien();
            dt = laydulieu("select * from mon where " + dk);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            flag = true;
         
            tbMaMon.Text = tbTenMon.Text = cbbDenGia.Text = cbbDVTinh.Text= cbbMaLoai.Text= cbbTuGia.Text = "";            
            tbMaMon.Focus();
        }
    }
}
