using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
{
    public partial class DataContext: MainWindow
    {
        public DataContext()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
