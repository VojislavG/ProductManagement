using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductManagement.Views
{
  
    public partial class search : UserControl
    {
        public search()
        {
            InitializeComponent();

        }

        private void InitializeDataGrid()
        {
            throw new NotImplementedException();
        }

        private void Btn_Add_Product_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string Name = this.Name_Of_Product.Text;
                string Pr = this.Price_Of_Product.Text;
                
              
                if (string.IsNullOrEmpty(Name) | string.IsNullOrWhiteSpace(this.Price_Of_Product.Text))
                {
                    MessageBox.Show("Beide Felder müssen ausgefüllt werden ");
                    return;
                }

                int Price = Int16.Parse(Pr);
                string stringPrice = Price.ToString();
                Product.SaveProduct(Name, Price);

                MessageBox.Show("Erfolgreich gespeichert!");
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }
        public void AddProductHit(object sender, object e)
        {
            Btn_Add_Product_Click(sender, null);
        }

        private void AddProductKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_Add_Product_Click(sender, null);
            }
        }
    }
}
