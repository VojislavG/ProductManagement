using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProductManagement.Models
{
    public class ProductToProductBox
    {   
        public void SaveProductInBox(string barcode, string boxBarcode)
        {
            try
            {
                var query = "INSERT INTO Product_Box_Products(Box_Bar_Code, Bar_Code) Values(@Box_Bar_Code, @Bar_Code)";
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Bar_Code", barcode));
                parameters.Add(new SqlParameter("Box_Bar_Code", boxBarcode));

                DAL.ExecuteNonQuery(query, parameters.ToArray());
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw e;
            }
        }

    }
}

