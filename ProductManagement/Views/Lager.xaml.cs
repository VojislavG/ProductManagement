using ProductManagement.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
namespace ProductManagement.Views
{
    /// <summary>
    /// Interaction logic for Lager.xaml
    /// </summary>
    public partial class Lager : UserControl
    {
        public Delegate del;
        public Lager()
        {
            InitializeComponent();
        }
       

        public void SearchClicked(object sender, RoutedEventArgs e)
        {

            string name_to_search = NameSearch.Text;
            var foundProducts = Product.SearchProduct(name_to_search);

            ProductsGrid.ItemsSource = foundProducts;

        }

        public void SearchEnterHit(object sender, object e)
        {
            SearchClicked(sender, null);
        }

        private void NameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchClicked(sender, null);
            }
        }

        private void editbtn(object sender, RoutedEventArgs e)
        {

            var cell = ProductsGrid.CurrentCell;

            var row_ind = ProductsGrid.Items.IndexOf(cell.Item);
            DataGridCell celija = GetCell(row_ind, 0);

            TextBlock tb = celija.Content as TextBlock;
            var PPcell = GetCell(row_ind, 2);
            TextBlock P_Price = PPcell.Content as TextBlock;
            string Prod_Price = P_Price.Text;


            var PNcell = GetCell(row_ind, 1);
            TextBlock P_Name = PNcell.Content as TextBlock;
            string Prod_Name = P_Name.Text;

            var PBarCell = GetCell(row_ind, 0);
            TextBlock PB = PBarCell.Content as TextBlock;
            string pb = PB.Text;

            if (pb != "")
            {
                var currentProduct = Product.SearchProductByBarCode(Convert.ToInt32(pb))[0];
                var currName = currentProduct.Name;
                if (Prod_Name == currName && Prod_Price == currentProduct.Price.ToString())
                {
                    
                }
                else
                {
                    Product.EditProduct(Convert.ToInt32(pb), Convert.ToInt32(Prod_Price), Prod_Name);
                    SearchClicked(sender, null);

                }
            }

            else
            {

                Product.SaveProduct(Prod_Name, Convert.ToInt32(Prod_Price));
                SearchClicked(sender, null);
            }
        }

        public DataGridCell GetCell(int row, int column)
        {
            DataGridRow rowData = GetRow(row);
            if (rowData != null)
            {
                DataGridCellsPresenter cellPresenter = GetVisualChild<DataGridCellsPresenter>(rowData);
                DataGridCell cell = (DataGridCell)cellPresenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    ProductsGrid.ScrollIntoView(rowData, ProductsGrid.Columns[column]);
                    cell = (DataGridCell)cellPresenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }

        public DataGridRow GetRow(int index)
        {
            DataGridRow row = (DataGridRow)ProductsGrid.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                ProductsGrid.UpdateLayout();
                ProductsGrid.ScrollIntoView(ProductsGrid.Items[index]);
                row = (DataGridRow)ProductsGrid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        private void deletebtn(object sender, RoutedEventArgs e)
        {
            var cell = ProductsGrid.CurrentCell;

            var row_ind = ProductsGrid.Items.IndexOf(cell.Item);
            DataGridCell celija = GetCell(row_ind, 0);
            TextBlock tb = celija.Content as TextBlock;
            var Bar = tb.Text;
            Product.DeleteProduct(Bar);
            SearchClicked(sender, null);
            
        }
       
    }
}
