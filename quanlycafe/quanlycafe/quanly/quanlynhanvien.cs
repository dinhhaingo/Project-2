using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCafe.quanly
{
    public partial class quanlynhanvien : Form
    {
        public quanlynhanvien()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-12J6D6C\SQLEXPRESS;Initial Catalog=qlcf_lamlai;Integrated Security=True");
        DataTable dt;
        SqlDataAdapter da;

        BindingSource bs;

        BindingManagerBase danhsach;

        

        private void quanlynhanvien_Load(object sender, EventArgs e)
        {
            dodulieuvaodatagridview();
        }

        public DataTable laydulieu(string sql)
        {
            con.Open();
            dt = new DataTable();
            da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void dodulieuvaodatagridview()
        {

            dt = laydulieu("select * from nguoidung");

            bs = new BindingSource();
            bs.DataSource = dt;

            danhsach = BindingContext[bs];
            dataGridView1.DataSource = bs;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt.Rows[danhsach.Position].Delete();
            da.Update(dt);
            MessageBox.Show("Xóa thành công!");

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            dodulieuvaodatagridview();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            kiemtradulieu();
        }

        private bool kiemtradulieu()
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Phải nhập tên!", "Thông báo");                
                txtname.Focus();
                return false;
            }
            return true;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
