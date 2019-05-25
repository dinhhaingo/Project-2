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

namespace QuanLyCafe.BaoCao_thongke
{
    public partial class frm_thongkedoanhthu : Form
    {
        public frm_thongkedoanhthu()
        {
            InitializeComponent();
        }

        SqlConnection cn;
        SqlDataAdapter da;
        DataTable dt;
        double tongtg = 0;
        int stt = 0;

        public void moketnoi()
        {
            cn = new SqlConnection();
            cn.ConnectionString = (@"Data Source=DESKTOP-12J6D6C\SQLEXPRESS;Initial Catalog=qlcf_lamlai;Integrated Security=True");
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
        public int Thuc_Hien_Lenh(string sql)
        {
            SqlCommand cm = new SqlCommand();
            if (cn.State == ConnectionState.Closed)
                moketnoi();
            cm.Connection = cn;
            cm.CommandType = CommandType.Text;
            cm.CommandText = sql;
            return cm.ExecuteNonQuery();

        }

        string dieu_kien_in = "";
        private string Tao_Chuoi_DieuKien_ThongKe()
        {
            string dieukien = "";
            if (rdbtTheoNgay.Checked)
            {
                dieukien = "ngaylap = '" + dtpNgay.Value.ToString("yyyy/MM/dd") + "'";
                dieu_kien_in = "{vw_HoaDon.Ngay} = '" + dtpNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            else if (rdbtTheoThang.Checked)
            {
                dieukien = "thang = " + cbbThang.Text + " and nam = " + tbNamThang.Text;
                dieu_kien_in = "{vw_HoaDon.thang} = " + cbbThang.Text + " and {vw_HoaDon.nam} =" + tbNamThang.Text;
            }
            else if (rdbtTheokhoangthoigian.Checked)
            {
                dieukien = "ngaylap >= '" + dtpTuNgay.Value.ToString("yyyy/MM/dd") + "' and ngaylap <= '" + dtpDenNgay.Value.ToString("yyyy/MM/dd") + "'";
                dieu_kien_in = "{vw_HoaDon.Ngay} >= '" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + "' and {vw_HoaDon.Ngay} <= '" + dtpDenNgay.Value.ToString("yyyy-MM-dd") + "'";
            }
            else if (rdbtTheoQuy.Checked)
            {
                dieukien = "quy = " + cbbQuy.Text + " and nam = " + tbNamQuy.Text;
                dieu_kien_in = "{vw_HoaDon.quy} = " + cbbQuy.Text + " and {vw_HoaDon.nam} =" + tbNamQuy.Text;
            }
            else if (rdbtTheoNam.Checked)
            {
                dieukien = "nam = " + tbNam.Text;
                dieu_kien_in = "{vw_HoaDon.nam} =" + tbNam.Text;
            }
            return dieukien;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_thongkedoanhthu_Load(object sender, EventArgs e)
        {
            rdbtTheoNgay.Checked = true;
            
        }

        private void bttimkiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("f");
            string dieukien = Tao_Chuoi_DieuKien_ThongKe();dt = null;
            dt = laydulieu("select distinct sohoadon, ngaylap, tongtg from vw_TK_DoanhThu where " + dieukien);
            if (dt == null) MessageBox.Show("f");
            dgvHoaDon.DataSource = dt;
            //dt = laydulieu("select distinct tenmon, dongia, soluong, thanhtien from vw_TK_DoanhThu where " + dieukien);
            //dgvChiTietHD.DataSource = dt;
            double tongtg = 0;
            for (int i = 0; i < dgvHoaDon.RowCount - 1; i++)
            {
                string trigia = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
                tongtg += double.Parse(trigia.Substring(0, trigia.IndexOf(".")));
            }
            lbTongDoanhThu.Text = tongtg.ToString();

        }

        private void rdbtTheoNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgay.Enabled = true;

            cbbThang.Enabled = false;
            tbNamThang.Enabled = false;

            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            cbbQuy.Enabled = false;
            tbNamQuy.Enabled = false;

            tbNam.Enabled = false;
        }

        private void rdbtTheoThang_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbtTheoThang.Checked)
            {
                tbNamThang.Text = DateTime.Now.Year.ToString();
                cbbThang.Focus();
            }
            else
            {
                tbNamThang.Text = "";   
                cbbThang.Text = "";
            }
            
                dtpNgay.Enabled = false;

                cbbThang.Enabled = true;
                tbNamThang.Enabled = true;

                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;

                cbbQuy.Enabled = false;
                tbNamQuy.Enabled = false;

                tbNam.Enabled = false;
            
        }

        private void rdbtTheokhoangthoigian_CheckedChanged(object sender, EventArgs e)
        {
            dtpNgay.Enabled = false;

            cbbThang.Enabled = false;
            tbNamThang.Enabled = false;

            dtpTuNgay.Enabled = true;
            dtpDenNgay.Enabled = true;

            cbbQuy.Enabled = false;
            tbNamQuy.Enabled = false;

            tbNam.Enabled = false;
        }

        private void rdbtTheoQuy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtTheoQuy.Checked)
            {
                tbNamQuy.Text = DateTime.Now.Year.ToString();
                cbbQuy.Focus();
            }
            else
            {
                tbNamQuy.Text = "";
                cbbQuy.Text = "";
            }

            dtpNgay.Enabled = false;

            cbbThang.Enabled = false;
            tbNamThang.Enabled = false;

            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            cbbQuy.Enabled = true;
            tbNamQuy.Enabled = true;

            tbNam.Enabled = false;
        }

        private void rdbtTheoNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtTheoNam.Checked)
            {
                tbNam.Text = DateTime.Now.Year.ToString();
                tbNam.Focus();
            }
            else
                tbNam.Text = "";

            dtpNgay.Enabled = false;

            cbbThang.Enabled = false;
            tbNamThang.Enabled = false;

            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            cbbQuy.Enabled = false;
            tbNamQuy.Enabled = false;

            tbNam.Enabled = true;
        }

        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//chi chon k dc nhap
        }

        private void cbbQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbQuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//chi chon k dc nhap
        }

        private void btThem_Click(object sender, EventArgs e)
        {

        }

        private void btIn_Click(object sender, EventArgs e)
        {

        }
    }
}
