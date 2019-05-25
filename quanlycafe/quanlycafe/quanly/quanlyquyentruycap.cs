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
    public partial class quanlyquyentruycap : Form
    {
        public quanlyquyentruycap()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-12J6D6C\SQLEXPRESS;Initial Catalog=qlcf_lamlai;Integrated Security=True");

        public void do_du_lieu_vao_combobox()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM quyenhan", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbNhanvien.DataSource = dt;
            cbNhanvien.DisplayMember = "tenquyen";
            cbNhanvien.ValueMember = "id_permission";
            con.Close();
        }

        private void quanlyquyentruycap_Load(object sender, EventArgs e)
        {
            this.do_du_lieu_vao_combobox();
        }

        public int Thuc_Hien_Lenh(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery();
        }

        public string check()
        {
            string s = "";
            if (radioButton1.Checked)
                s += radioButton1.Text;
            if (radioButton2.Checked)
                s += radioButton2.Text;
            if (radioButton3.Checked)
                s += radioButton3.Text;
            return s;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbNhanvien.ValueMember);
            string sql = "insert into chitietquyen value(null,'" + cbNhanvien.Text + "','" + cbNhanvien.ValueMember + "','" + check() + "')";
            int kq = Thuc_Hien_Lenh(sql);
            if (kq != 0)
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
