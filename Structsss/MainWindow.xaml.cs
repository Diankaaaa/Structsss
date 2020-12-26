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

namespace Structsss
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public struct Product
    {
        public string name;
        public DateTime? production_date;
        public DateTime? expiration_date;
        public int price;
        public int serial_number;
    }

    public partial class MainWindow : Window
    {
        Product[] productes;
        int i = 0; 
        int count;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(i == 0)
            {
                try
                {
                    count = int.Parse(Count.Text);
                    productes = new Product[count];
                    AddProduct();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                AddProduct();
            }
            if(i == count)
            {
                Add.IsEnabled = false; //Как только достигнут максимум кнопка блокируется
            }
        }
        public void AddProduct()
        {
            if(i < count)
            {
                WindowProduct window = new WindowProduct();
                if(window.ShowDialog() == true)
                {
                    Product p = new Product();
                    p.name = window.NAME.Text;
                    p.production_date = window.PRODUCTION_DATE.SelectedDate;
                    p.expiration_date = window.EXPIRATION_DATE.SelectedDate;
                    p.price = int.Parse(window.PRICE.Text);
                    p.serial_number = int.Parse(window.SERIAL_NUMBER.Text);
                    productes[i] = p;
                    Product.Items.Add(p.name);
                }
                i++;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Add.IsEnabled = false;
        }

        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            Add.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < count; i++)
            {
                OUTPUT.Text += "Наименование товара: " + productes[i].name + Environment.NewLine + "Годен до: " + productes[i].expiration_date + Environment.NewLine + Environment.NewLine;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OUTPUT.Text = String.Empty;
        }
    }
}
