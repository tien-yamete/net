using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp5.Models;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private QlbhContext db = new QlbhContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KhachHangCombo.ItemsSource = db.KhachHangs.ToList();
            KhachHangCombo.DisplayMemberPath = "HoTen";
            KhachHangCombo.SelectedValuePath = "MaKh";

            bangData.ItemsSource = db.DonHangs
                .OrderByDescending(d => d.MaDh)
                .ToList();
        }

        private void bangData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = bangData.SelectedItem;
            if (selected == null) return;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string maDh = MaDHText.Text.Trim();
            if (db.DonHangs.Any(d => d.MaDh == maDh))
            {
                MessageBox.Show("Mã đơn hàng đã tồn tại!");
                return;
            }

            try
            {
                var donHang = new DonHang
                {
                    MaDh = maDh,
                    NgayDat = DatePick.SelectedDate,
                    TongTien = decimal.Parse(TienText.Text),
                    MaKh = KhachHangCombo.SelectedValue.ToString()
                };

                db.DonHangs.Add(donHang);
                db.SaveChanges();

                bangData.ItemsSource = db.DonHangs
                .OrderByDescending(d => d.MaDh)
                .ToList();
            }
            catch
            {
                MessageBox.Show("Không thêm được đơn hàng!");
            }
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            Window1 stats = new Window1();
            stats.ShowDialog();
        }
        private void bangSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DonHang donHang = (DonHang)bangData.SelectedItem;
            if (donHang != null)
            {
                MaDHText.Text = donHang.MaDh;
                DatePick.SelectedDate = donHang.NgayDat;
                TienText.Text = donHang.TongTien.ToString();
                KhachHangCombo.SelectedValue = donHang.MaKh;
            }
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DonHang? donHang = db.DonHangs.Find(MaDHText.Text);
            if (donHang != null)
            {
                donHang.MaDh = MaDHText.Text;
                donHang.NgayDat = DatePick.SelectedDate;
                donHang.TongTien = Decimal.Parse(TienText.Text);
            };
            try
            {
                db.SaveChanges();
                bangData.ItemsSource = db.DonHangs.ToList();
            }
            catch
            {
                MessageBox.Show("Không sửa được nhân viên");
            }
        }
    }
}
