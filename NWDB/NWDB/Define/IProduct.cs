using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace NWDB.Define
{
    //定義有關產品的相關功能
    public interface IProduct
    {
        DataTable SearchProduct();
        Bitmap GetProductPic(int ProductID);
        

    }
}
