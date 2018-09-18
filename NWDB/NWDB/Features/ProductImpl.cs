using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace NWDB.Features
{
    public class ProductImpl : Define.IProduct
    {
        private SqlConnection conn;

        public ProductImpl(SqlConnection cnn)
        {
            this.conn = cnn;
        }

        public Bitmap GetProductPic(int ProductID)
        {
            Bitmap pp = null;
            string cmdS = "SELECT 產品圖片 FROM 產品資料 WHERE 產品編號=@pid";
            using (SqlCommand cmd = new SqlCommand(cmdS, this.conn))
            {
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = ProductID;

                this.conn.Open();
                object oo = cmd.ExecuteScalar();
                if (oo != null)
                {
                    byte[] bb = (byte[])oo;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bb);
                    Image ii = Image.FromStream(ms);
                    pp = new Bitmap(ii);
                }
                this.conn.Close();
            }

            return pp;            
        }

        public DataTable SearchProduct()
        {
            DataTable tt = null;
            string cmdS = "SELECT 產品編號,產品,單價,單位數量,庫存量 FROM 產品資料";            
            using (SqlCommand cmd = new SqlCommand(cmdS, this.conn))
            {
                this.conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tt = new DataTable();
                    tt.Load(dr);
                }
                dr.Close();
                cmd.Dispose();
                this.conn.Close();
            }
            return tt;
        }
    }
}
