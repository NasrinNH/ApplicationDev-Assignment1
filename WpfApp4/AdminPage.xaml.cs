using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        DataTable dt;
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            dt = new Admin().selectStar();
            DGrid.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            foreach (DataRow item in dt.Rows)
            {
                if (item.RowState == DataRowState.Modified)
                {
                    new Admin().updateProductAmount(item[0].ToString(), Convert.ToInt16( item[2]));
                }
                if (item.RowState == DataRowState.Added)
                {
                    new Admin().insert(item[0].ToString(), Convert.ToInt32(item[1]), Convert.ToInt16(item[2]), Convert.ToDouble(item[3]));
                }
                if (item.RowState == DataRowState.Deleted)
                {
                    new Admin().delete(item[0, DataRowVersion.Original].ToString());
                }

            }
        }
    }
}
