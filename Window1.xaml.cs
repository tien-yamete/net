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
using WpfApp5.Models;

namespace WpfApp5
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (QlbhContext db = new QlbhContext())
            {
                var thongKe = db.DonHangs
                .GroupBy(d => d.MaKhNavigation.HoTen)
                .Select(g => new
                {
                    HoTen = g.Key,
                    SoLuong = g.Count()
                })
                .ToList();

                ThongKeGrid.ItemsSource = thongKe;
            }
        }
    }
}
