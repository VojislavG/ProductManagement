using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using Aspose.BarCode.Generation;
using Microsoft.Data.SqlClient;

namespace ProductManagement.Models
{
    class Product
    {
        public static void EditProduct(int Bar_Code, int Prod_Pric, string Prod_Nam)
        {
            try
            {
                var query = "UPDATE Product SET Prod_Name=@Prod_Name, Prod_Price=@Prod_Price WHERE Bar_Code = @Bar_Code";
                var parameterss = new List<SqlParameter>();
                parameterss.Add(new SqlParameter("Bar_Code", Bar_Code));
                parameterss.Add(new SqlParameter("Prod_Name", Prod_Nam));
                parameterss.Add(new SqlParameter("Prod_Price", Prod_Pric));
                DAL.ExecuteNonQuery(query, parameterss.ToArray());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeleteProduct(string Bar)

        {
            try
            {
                var query = "DELETE FROM Product WHERE Bar_Code=" + Bar;

                DAL.ExecuteNonDeleteQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static void SaveProduct(String Name, int Price)
        {
            var BarCode = BarcodeUtil.GenerateNew();

            try
            {
                var query = "INSERT INTO Product (Bar_Code, Prod_Name, Prod_Price)" +
                    "Values (@Bar_Code, @Prod_Name, @Prod_Price )";


                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Bar_Code", BarCode));
                parameters.Add(new SqlParameter("Prod_Name", Name));
                parameters.Add(new SqlParameter("Prod_Price", Price));

                DAL.ExecuteNonQuery(query, parameters.ToArray());
                var st = ProductBox.ReturnBoxNotFilled();
                if (st.Count == 0)
                {
                    var ppb = new ProductToProductBox();
                    ppb.SaveProductInBox(BarCode, BarcodeUtil.GenerateNew());
                }
                else
                {
                    var ppb = new ProductToProductBox();
                    var pb = ProductBox.ReturnBoxNotFilled()[0].BoxBarCode;
                    ppb.SaveProductInBox(BarCode, pb);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw e;
            }
        }

        public static IList<ProductDto> SearchProduct(string Name)
        {
            try
            {
                Name = Name + "%";
                var query = "SELECT Bar_Code , Prod_Name, Prod_Price FROM Product p WHERE p.Prod_Name LIKE @Name";
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("Name", Name));

                var list = DAL.ExecuteQuery(query, parameters.ToArray(), dataRecord =>
                {
                    var product = new ProductDto();
                    product.BarCode = dataRecord.GetString(0);
                    product.Name = dataRecord.GetString(1);
                    product.Price = (int)dataRecord.GetDecimal(2);

                    return product;
                });

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IList<ProductDto> SearchProductByBarCode(int BarCode)
        {
            try
            {
                var query = "SELECT Bar_Code, Prod_Name, Prod_Price FROM Product p WHERE p.Bar_Code LIKE @BarCode";
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("BarCode", BarCode));

                var list = DAL.ExecuteQuery(query, parameters.ToArray(), dataRecord =>
                {
                    var product = new ProductDto();
                    product.BarCode = dataRecord.GetString(0);
                    product.Name = dataRecord.GetString(1);
                    product.Price = (int)dataRecord.GetDecimal(2);

                    return product;
                });

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class ProductDto
    {
        public string BarCode { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

}
