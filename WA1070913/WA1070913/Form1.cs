using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WA1070913
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int choice = int.Parse(textBox1.Text);
            
            FastFoodStore.Customer.Customer cc = new FastFoodStore.Customer.Customer("孫小美");
            //FastFoodStore.BaseStore ss = new FastFoodStore.Store.Mcdonalds();
            FastFoodStore.BaseStore ss = new FastFoodStore.Store.KFC();
            string a = cc.BuyMeal(ss, choice);
            label1.Text = a;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NWDB.NWDB mydb = new NWDB.NWDB();
            NWDB.Define.IProduct ip = new NWDB.Features.ProductImpl(mydb.Conn);
            DataTable tt = ip.SearchProduct();
            mydb.DbClose();

            if (tt != null)
            {
                dataGridView1.DataSource = tt;
            }
            else
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("查無任何資料！");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rr = e.RowIndex;
            int cc = e.ColumnIndex;

            /*            
            string aa;

            //DataTable uu = dataGridView1.DataSource as DataTable;
            //aa = uu.Rows[rr][cc].ToString();

            aa = dataGridView1.Rows[rr].Cells[cc].Value.ToString();

            MessageBox.Show(aa);
            */

            int aa = (int)dataGridView1.Rows[rr].Cells[0].Value;
            this.GetProductPic(aa);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cnnS = @"server=localhost;database=中文北風;UID=SQLUser;PWD=1234;";

            //千萬不要串接SQL命令
            //string cmdS = "SELECT 單價 FROM 產品資料 WHERE 產品編號=" + textBox2.Text;
            //string cmdS = "SELECT 單價 FROM 產品資料 WHERE 產品編號=?";     //Excel、Access、Oracle等其他資料庫
            string cmdS = "SELECT 單價 FROM 產品資料 WHERE 產品編號=@pid";        //SQL Server專用寫法

            using (SqlConnection cnn = new SqlConnection(cnnS))
            {
                cnn.ConnectionString = cnnS;
                using (SqlCommand cmd = new SqlCommand(cmdS, cnn))
                {
                    //指定參數值
                    cmd.Parameters.Add("@pid", SqlDbType.Int).Value = int.Parse(textBox2.Text);

                    cnn.Open();
                    double price = Convert.ToDouble(cmd.ExecuteScalar());
                    cmd.Dispose();
                    cnn.Close();

                    MessageBox.Show(price.ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NWDB.NWDB mydb = new NWDB.NWDB();
            NWDB.Define.IProduct ip = new NWDB.Features.ProductImpl(mydb.Conn);
            Bitmap pp = ip.GetProductPic(int.Parse(textBox2.Text));
            mydb.DbClose();

            if (pp != null)
            {
                PicLabel.Text = "";
                PicLabel.AutoSize = false;
                PicLabel.Size = pp.Size;
                PicLabel.Image = pp;
            }
            else
            {                
                MessageBox.Show("沒有圖片！");
            }
        }

        private void GetProductPic(int pid)
        {
            NWDB.NWDB mydb = new NWDB.NWDB();
            NWDB.Define.IProduct ip = new NWDB.Features.ProductImpl(mydb.Conn);
            Bitmap pp = ip.GetProductPic(pid);
            mydb.DbClose();

            if (pp != null)
            {
                PicLabel.Text = "";
                PicLabel.AutoSize = false;
                PicLabel.Size = pp.Size;
                PicLabel.Image = pp;
            }
            else
            {
                MessageBox.Show("沒有圖片！");
            }
        }

    }
}
