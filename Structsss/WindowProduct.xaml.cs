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
using System.Windows.Shapes;

namespace Structsss
{
    ///
    /// <summary>
    /// Логика взаимодействия для WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        public WindowProduct(Product p)
        {
            InitializeComponent();
            NAME.Text = p.name;
            PRODUCTION_DATE.SelectedDate = p.production_date;
            EXPIRATION_DATE.SelectedDate = p.expiration_date;
            PRICE.Text = p.price.ToString();
            SERIAL_NUMBER.Text = p.serial_number.ToString();
        }
        public WindowProduct()
        {
            InitializeComponent();
        }

        private void ADD_PRRODUCT_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string getName()
        {
            return NAME.Text;
        }

        public DateTime? getPD()
        {
            return PRODUCTION_DATE.SelectedDate;
        }

        public DateTime? getED()
        {
            return EXPIRATION_DATE.SelectedDate;
        }

        public int getPrice()
        {
            return int.Parse(PRICE.Text);
        }

        public int getSN()
        {
            return int.Parse(SERIAL_NUMBER.Text);
        }
    }
}
