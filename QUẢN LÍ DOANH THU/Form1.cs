using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÍ_DOANH_THU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        QuanLyDoanhThu quanLy;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = modify.Table(" SELECT * FROM CLB ");
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Lỗi: "+ex.Message);
            }
            DeleteTextBox();
        }
        private void comboBox1_CLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1_CLB.SelectedIndex == 0)
            {
                txt_GiaVe.Text = "10";
                txt_TenNuoc.Text = "ANH";
            }
            if (comboBox1_CLB.SelectedIndex == 1)
            {
                txt_GiaVe.Text = "12";
                txt_TenNuoc.Text = "PHÁP";
            }
            if (comboBox1_CLB.SelectedIndex == 2)
            {
                txt_GiaVe.Text = "10";
                txt_TenNuoc.Text = "TÂY BAN NHA";
            }
            if (comboBox1_CLB.SelectedIndex == 3)
            {
                txt_GiaVe.Text = "7";
                txt_TenNuoc.Text = "BỒ ĐỘI NHA";
            }
            if (comboBox1_CLB.SelectedIndex == 4)
            {
                txt_GiaVe.Text = "12";
                txt_TenNuoc.Text = "Ý";
            }
            if (comboBox1_CLB.SelectedIndex == 5)
            {
                txt_GiaVe.Text = "10";
                txt_TenNuoc.Text = "TÂY BAN NHA";
            }
            if (comboBox1_CLB.SelectedIndex == 6)
            {
                txt_GiaVe.Text = "10";
                txt_TenNuoc.Text = "ĐỨC";
            }
            if (comboBox1_CLB.SelectedIndex == 7)
            {
                txt_GiaVe.Text = "11";
                txt_TenNuoc.Text = "Ý";
            }
        }

        private void txt_SLV_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteTextBox()
        {
            comboBox1_CLB.SelectedIndex = -1;
            txt_GiaVe.Text = "";
            txt_SLV.Text = "";
            txt_TenNuoc.Text = "";
        }
        private bool CheckTextBox()
        {
            if(comboBox1_CLB.SelectedIndex == 0)
            {
                MessageBox.Show("Mời bạn chọn CLB: ");
                return false;
            }
            if (txt_SLV.Text == " ")
            {
                MessageBox.Show("Mời Bạn Nhập Số Lượng Vé: ");
                return false;
            }
            return true;
        }
        private void GetValuseTextBox()
        {
            string __tenCauLacBo = comboBox1_CLB.Text;
            string __tenNuoc = txt_TenNuoc.Text;
            int __soLuongVe = int.Parse(txt_SLV.Text);
            double __giaVe = double.Parse(txt_GiaVe.Text);
            quanLy = new QuanLyDoanhThu(__tenCauLacBo,__tenNuoc,__soLuongVe,__giaVe);
    }
        private void txt_SLV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                GetValuseTextBox();
                string query = "INSERT INTO CLB VALUES ('" + quanLy.TenCauLacBo + "', N'" + quanLy.TenNuoc + "', '" + quanLy.SoLuongVe + "', '" + quanLy.GiaVe + "', '" + quanLy.DoanhThu() + "')";
                try
                {
                    if(MessageBox.Show("Bạn Có Muốn Thêm Vào Không ?",  "Thông Báo ",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Thêm Thành Công !");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Thêm: "+ ex.Message);
                }
            }
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (CheckTextBox())
            {
                GetValuseTextBox();
                string query = "UPDATE CLB SET TenNuoc = N'" + quanLy.TenNuoc + "', SoLuongVe = " + quanLy.SoLuongVe + ", GiaVe = " + quanLy.GiaVe + ", TongTien = " + quanLy.DoanhThu() + "";
               query+= " WHERE TenCauLacBo = '" + quanLy.TenCauLacBo + "';";
                try
                {
                    if (MessageBox.Show("Bạn Có Sửa Thêm Vào Không ?", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Sửa Thành Công !");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Sửa: " + ex.Message);
                }
            } 
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                comboBox1_CLB.SelectedItem = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txt_GiaVe.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_SLV.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_TenNuoc.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string choose = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (dataGridView1.Rows.Count > 1)
            {
                string query = " DELETE CLB ";
                query += " WHERE TenCauLacBo = '" + choose + "'";
                try
                {
                    if (MessageBox.Show("Bạn Có Xoá Thêm Vào Không ?", "Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Xoá Thành Công !");
                        Form1_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Xoá: " + ex.Message);
                }
            }
        }
        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string name = txt_TimKiem.Text.Trim();
            if (name == "")
            {
                Form1_Load(sender, e);
            }
            else
            {
                string query = "SELECT * FROM CLB WHERE TenCauLacBo LIKE '%" + name + "%'";
                dataGridView1.DataSource = modify.Table(query);
            }
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn Có Muốn Thoát Không ? " , " Thông Báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information)  == DialogResult.Yes)
            Application.Exit();
        }
    }
}
