using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ProductManagement.Models
{
    public class ProductBox
    {
        public static IList<ProductBoxDto> ReturnBoxNotFilled()
        {

            var query = "select top 1 pbp.Box_Bar_Code, pb.Max_Size, count(*) as ProductCount " +
                            "from Product_Box_Products as pbp " +
                            "inner join Product_Box pb on pb.Pr_Box_Bar_Code = pbp.Box_Bar_Code " +
                            "group by pbp.Box_Bar_Code, pb.Max_Size " +
                            "having count(*) < pb.Max_Size";

            var box = DAL.ExecuteQuery(query, new SqlParameter[0], dataRecord =>
            {
                var productBox = new ProductBoxDto();
                productBox.BoxBarCode = dataRecord.GetString(0);
                    
                return productBox;
            });

            return box;
        }
    }
      
    public class ProductBoxDto
    {
        public string BoxBarCode { get; set; }
        public int MaxSize { get; }

    }
}