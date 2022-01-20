select pb.Pr_Box_Bar_Code, pb.Max_Size, pbp.Bar_Code, p.Prod_Name, p.Prod_Price
from Product_Box pb
inner join Product_Box_Products pbp on pb.Pr_Box_Bar_Code = pbp.Box_Bar_Code
inner join Product p on p.Bar_Code = pbp.Bar_Code
where pb.Pr_Box_Bar_Code = '987654'

select pb.Pr_Box_Bar_Code , Min(p.Prod_Price) as MinPrice, Max(p.Prod_Price) as MaxPrice, AVG(p.Prod_Price) as AvgPrice
from Product_Box pb
inner join Product_Box_Products pbp on pb.Pr_Box_Bar_Code = pbp.Box_Bar_Code
inner join Product p on p.Bar_Code = pbp.Bar_Code
group by pb.Pr_Box_Bar_Code

select top 1 pbp.Box_Bar_Code, pb.Max_Size, count(*) as ProductCount
from Product_Box_Products as pbp
inner join Product_Box pb on pb.Pr_Box_Bar_Code = pbp.Box_Bar_Code
group by pbp.Box_Bar_Code, pb.Max_Size
having count(*) < pb.Max_Size

INSERT INTO Product_Box_Products (Box_Bar_Code, Bar_Code) Values (@Box_Bar_Code, @Bar_Code );