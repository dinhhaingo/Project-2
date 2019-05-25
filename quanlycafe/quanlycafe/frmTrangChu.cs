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
using System.Diagnostics;
namespace QuanLyCafe
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        public static string User = string.Empty;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-12J6D6C\SQLEXPRESS;Initial Catalog=qlcf_lamlai;Integrated Security=True");

        //biến list dùng hcung đễ lưu những codehanhdong mà csdl trả về
        List<string> list_detail;

        //hàm truy vấn lấy id nhóm quyền 
        string id = "";
        private string id_per(string id_user)
        {
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM per_relationship WHERE id_user ='" + id_user + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_permission"].ToString();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;
        }

        //hàm lấy chi tiết những quyền được cấp cho nhóm
        private List<string> list_per(string id_per)
        {
            List<string> termsList = new List<string>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM chitietquyen WHERE id_permission ='" + id_per + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termsList.Add(dr["codehanhdong"].ToString());
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return termsList;
        }

        //gọi hàm
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            list_detail = list_per(id_per(frmLogin.ID_USER));

            
        }

        //hàm truyền vào codehanhdong,duyệt trong mảng để kiểm tra, trả về giá trị true/false
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in list_detail)
            {
                if (item == code)
                {
                    check = true;
                }
            }
            return check;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("bạn có chắc chắn muốn thoát?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlr == DialogResult.Yes)
                Application.Exit();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangChu trangchu = new frmTrangChu();
            trangchu.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            

        }

        private void lậpHóaĐơnThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("order") == true)
            {
                NghiepVu.frm_lapHoaDon hoadon = new NghiepVu.frm_lapHoaDon();
                hoadon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
            
        }

        private void lậpBáoCáoThốngKếToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("report") == true)
            {
                BaoCao_thongke.frm_thongkedoanhthu thongke = new BaoCao_thongke.frm_thongkedoanhthu();
                thongke.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }           
        }

        private void tìmKiếmThôngTinMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("find") == true)
            {
                TimKiem.frm_timkiemmon timkiem = new TimKiem.frm_timkiemmon();
                timkiem.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void quảnLýQuyềnTryCậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("permission") == true)
            {
                quanly.quanlyquyentruycap truycap = new quanly.quanlyquyentruycap();
                truycap.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("user") == true)
            {
                quanly.quanlynhanvien nhanvien = new quanly.quanlynhanvien();
                nhanvien.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }          
        }

        private void quảnLýLoạiMónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkper("type") == true)
            {
                capnhat.frm_loaimon loaimon = new capnhat.frm_loaimon();
                loaimon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void quảnLýMónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (checkper("plat") == true)
            {
                capnhat.frm_mon mon = new capnhat.frm_mon();
                mon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        //hàm backup
        public void backup(string fileName)
        {
            con.Open();
            string sql = "Backup database qlcf_lamlai to disk = '" + fileName + ".bak'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //hàm restore
        public void restore(string fileName)
        {
            con.Open();
            string sql = "restore database qlcf_lamlai from disk = '" + fileName + "' with replace";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //gán sự kiện backup cho menu backup csdl
        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("backup") == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    backup(save.FileName);
                    MessageBox.Show("backup database thành công");
                }
                else
                {
                    MessageBox.Show("thao tác thất bại");
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }            
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkper("backup") == true)
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    restore(open.FileName);
                    MessageBox.Show("restore databse thành công");
                }
                else
                {
                    MessageBox.Show("thao tác thất bại");
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
