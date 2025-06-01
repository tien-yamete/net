using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private List<BenhNhan> danhSachBenhNhan = new List<BenhNhan>();

        public MainWindow()
        {
            InitializeComponent();
            dgBenhNhan.ItemsSource = danhSachBenhNhan;
        }

        private void btnNhap_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBN.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text) || dpNgayVao.SelectedDate == null)
            {
                MessageBox.Show("Tất cả các trường đều phải có dữ liệu.");
                return;
            }
            if (dpNgayVao.SelectedDate > DateTime.Now)
            {
                MessageBox.Show("Ngày vào viện không được lớn hơn ngày hiện tại.");
                return;
            }

            var bn = new BenhNhan
            {
                MaBN = txtMaBN.Text,
                HoTen = txtHoTen.Text,
                NgayVao = dpNgayVao.SelectedDate.Value,
                LoaiBN = (cbLoaiBN.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            danhSachBenhNhan.Add(bn);
            dgBenhNhan.Items.Refresh();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            var dsNgoaiTru = danhSachBenhNhan.FindAll(bn => bn.LoaiBN == "Ngoại trú");
            Window thongKeWindow = new Window
            {
                Title = "Danh sách Ngoại trú",
                Width = 400,
                Height = 300,
                Content = new DataGrid
                {
                    ItemsSource = dsNgoaiTru,
                    AutoGenerateColumns = true
                }
            };
            thongKeWindow.ShowDialog();
        }
    }

    public class BenhNhan
    {
        public string MaBN { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayVao { get; set; }
        public string LoaiBN { get; set; }
    }
}
