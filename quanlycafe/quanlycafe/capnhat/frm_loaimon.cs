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
using System.Data.Odbc;
using System.IO;
using Excel_12 = Microsoft.Office.Interop.Excel;

namespace QuanLyCafe.capnhat
{
    public partial class frm_loaimon : Form
    {
        public frm_loaimon()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlDataAdapter da;
        DataTable dt;
        BindingSource bs;

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
            return dt;
        }

        public void DoDuLieu_Vao_DatagridView()
        {
            dt = laydulieu("select * from loaimon");

            bs = new BindingSource();
            bs.DataSource = dt;

            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
        }

        private void frm_loaimon_Load(object sender, EventArgs e)
        {
            DoDuLieu_Vao_DatagridView();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Cập nhật thành công!");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//xuat ra excel
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export loai mon.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dataGridView1, sfd.FileName);
            }
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            string sHeaders = "";
            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + dGV.Rows[i].Cells[j].Value.ToString() + "\t";
                stOutput += stLine + "\r\n";
            }
            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter bw = new StreamWriter(fs, Encoding.Unicode);
            bw.Write(stOutput);
            bw.Flush();
            bw.Close();
            fs.Close();
        }
    }

}
