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

namespace QuanLyCafe.NghiepVu
{
    public partial class frm_lapHoaDon : Form
    {
        public frm_lapHoaDon()
        {
            InitializeComponent();
        }

        SqlConnection cn;
        SqlDataAdapter da;
        DataTable dt;
        double tongtien = 0;
        int stt = 0;

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
            da.FillSchema(dt, SchemaType.Mapped);
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

        public void do_dulieu_vao_combobox()
        {
            cbbSoBan.DataSource = laydulieu("select * from ban");
            cbbSoBan.DisplayMember = "sttban";
            cbbSoBan.ValueMember = "sttban";
            cbbSoBan.Text = "";

            cbbMaNV.DataSource = laydulieu("select * from nguoidung");
            cbbMaNV.DisplayMember = "ten";
            cbbMaNV.ValueMember = "id_user";
            cbbMaNV.Text = "";

            cbbMaMon.DataSource = laydulieu("select * from mon");
            cbbMaMon.DisplayMember = "tenmon";
            cbbMaMon.ValueMember = "mamon";
            cbbMaMon.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            tbSoHD.Text = cbbSoBan.Text = cbbMaNV.Text = "";
            cbbMaMon.Text = tbSoLuong.Text = "";
            lbDonGia.Text = lbThanhTien.Text = lbTongThanhTien.Text = "0";
            dataGridView1.Rows.Clear();
            tongtien = 0;
            dtpNgayLap.Text = dtpNgayLap.Text = "";  
            tbSoHD.Focus();  
        }

        private void frm_lapHoaDon_Load(object sender, EventArgs e)
        {
            do_dulieu_vao_combobox();
        }

        private bool kiem_tra_du_lieu_truoc_khi_luu()
        {
            if (tbSoHD.Text == "")
            {
                MessageBox.Show("Phải nhập số hóa đơn", "Thông báo");

                tbSoHD.Focus();
                return false;
            }
            try
            {
                double dongia = Convert.ToDouble(tbSoLuong.Text);
            }
            catch
            {
                return false;
            }
            if (dt.Rows.Contains(tbSoHD.Text))
            {
                MessageBox.Show("Mã món bị trùng", "Thông báo");
                tbSoHD.Text = "";
                tbSoHD.Focus();
                return false;
            }
            return true;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (kiem_tra_du_lieu_truoc_khi_luu() == false)
                return;
            string sql = "insert into hoadon values('" + tbSoHD.Text + "','" + dtpNgayLap.Value.ToString("yyyy/MM/dd HH:mm:ss") + "'," + lbTongThanhTien.Text + ",'" + cbbSoBan.Text + "','" + cbbMaNV.SelectedValue.ToString() + "')";
            int kq = Thuc_Hien_Lenh(sql);
            if (kq != 0)
                MessageBox.Show("Lưu Hóa đơn thành công");
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                sql = "insert into cthoadon values(";
                sql += "'" + tbSoHD.Text + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString();
                sql += "'," + dataGridView1.Rows[i].Cells[4].Value.ToString();
                sql += "," + dataGridView1.Rows[i].Cells[5].Value.ToString() + ")";
                kq = Thuc_Hien_Lenh(sql);
            }
            if (kq != 0)
                MessageBox.Show("Lập hóa đơn thành công");
        }

        private void cbbMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbMaMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void cbbMaMon_KeyDown(object sender, KeyEventArgs e)
        {
            if ((cbbMaMon.Text != "") && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab))
            {
                dt = laydulieu("select dongia from mon where mamon ='" + cbbMaMon.SelectedValue.ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    string dongia = dt.Rows[0][0].ToString();
                    lbDonGia.Text = dongia.Substring(0, dongia.IndexOf("."));
                    tbSoLuong.Focus();
                }

            }
        }

        private void cbbMaMon_TextChanged(object sender, EventArgs e)
        {
            dt = laydulieu("select dongia from mon where mamon ='" + cbbMaMon.SelectedValue.ToString() + "'");
            if (dt.Rows.Count > 0)
            lbDonGia.Text = dt.Rows[0][0].ToString();
        }

        private void tbSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double tt = double.Parse(lbDonGia.Text) * double.Parse(tbSoLuong.Text);
                tongtien += tt;
                lbThanhTien.Text = tt.ToString();
                lbTongThanhTien.Text = tongtien + "";
                dataGridView1.Rows.Add();
                int i = dataGridView1.Rows.Count - 2;
                dataGridView1.Rows[i].Cells[0].Value = (++stt).ToString();
                dataGridView1.Rows[i].Cells[1].Value = cbbMaMon.SelectedValue.ToString();
                dataGridView1.Rows[i].Cells[2].Value = cbbMaMon.Text;
                dataGridView1.Rows[i].Cells[3].Value = lbDonGia.Text;
                dataGridView1.Rows[i].Cells[4].Value = tbSoLuong.Text;
                dataGridView1.Rows[i].Cells[5].Value = lbThanhTien.Text;
                cbbMaMon.Focus();
            }
        }

        private void tbSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))  
            {
                e.Handled = true;
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là xóa hóa đơn số: " + tbSoHD.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "delete cthoadon where sohoadon = '" + tbSoHD.Text + "'";
                Thuc_Hien_Lenh(sql);
                sql = "delete hoadon where sohoadon = '" + tbSoHD.Text + "'";
                Thuc_Hien_Lenh(sql);
                MessageBox.Show("Đã xóa hóa đơn");
                btTim_Click(sender, e);
            }
        }

        private void tbSoHD_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbSoBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbSoBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void cbbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void btIn_Click(object sender, EventArgs e)
        {

        }
    }
}
