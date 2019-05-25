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
using System.Security.Cryptography;


namespace QuanLyCafe
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //chuỗi kết nối
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-12J6D6C\SQLEXPRESS;Initial Catalog=qlcf_lamlai;Integrated Security=True");
        
        //biến để lưu id người dùng
        public static string ID_USER = "";


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUser.ResetText();
            txtPass.ResetText();
            txtUser.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //hàm lấy id người dùng
        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM nguoidung WHERE username ='" + username + "' and pass='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    //id = "1";
                    foreach (DataRow dr in dt.Rows)
                    {

                        id = dr["id_user"].ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        //hàm mã hóa MD5
        public static string ToMD5(string pass)
        {
            string kq = "";
            byte[] buffer = Encoding.UTF8.GetBytes(pass);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            for (int i = 0; i < buffer.Length; i++)
            {
                kq += buffer[i].ToString("x");
            }
            return kq;
        }

        //code đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
           // string pass = ToMD5(txtPass.Text);
            ID_USER = getID(txtUser.Text, txtPass.Text);
          //  MessageBox.Show(ID_USER);
            if (ID_USER != "")
            {
                MessageBox.Show("Đăng nhập thành công !!");
                frmTrangChu trangchu = new frmTrangChu();
                trangchu.ShowDialog();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
