using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX12
{
class Program
    {
        static List<Doctor> doctors = new List<Doctor>();

        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            FakeData();
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("1. Hiển thị danh sách bác sĩ");
                Console.WriteLine("2. Nhập thêm bác sĩ mới");
                Console.WriteLine("3. Tìm và xóa theo số điện thoại");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string c = Console.ReadLine();
                switch (c)
                {
                    case "1": Display(); break;
                    case "2": AddDoctor(); break;
                    case "3": DeleteByPhone(); break;
                    case "0": return;
                    default: Console.WriteLine("Sai lựa chọn"); break;
                }
            }
        }

        static void AddDoctor()
        {
            Console.Write("Loại bác sĩ (1- Surgeon, 2- GeneralPractitioner): ");
            string type = Console.ReadLine();
            Doctor d = null;
            if (type == "1") d = new Surgeon();
            else if (type == "2") d = new GeneralPractitioner();
            else { Console.WriteLine("Không hợp lệ"); return; }

            d.Input();
            doctors.Add(d);
            Console.WriteLine("Đã thêm bác sĩ.");
        }

        static void Display()
        {
            if (doctors.Count == 0)
            {
                Console.WriteLine("Không có bác sĩ nào.");
                return;
            }
            foreach (var d in doctors)
                d.Output();
        }

        static void DeleteByPhone()
        {
            Console.Write("Nhập số điện thoại cần xóa: ");
            string phone = Console.ReadLine();
            var found = doctors.FirstOrDefault(d => d.Mobile == phone);
            if (found != null)
            {
                doctors.Remove(found);
                Console.WriteLine("Đã xóa bác sĩ.");
            }
            else Console.WriteLine("Không tìm thấy bác sĩ.");
        }

        static void FakeData()
        {
            doctors.Add(new Surgeon { ID = "S01", FullName = "Dr. An", Gender = "Nam", Specialty = "Tim mạch", Experience = 10, Mobile = "0911000001", SurgeryType = "Tim hở", NumberOfSurgeries = 250 });
            doctors.Add(new Surgeon { ID = "S02", FullName = "Dr. Bình", Gender = "Nữ", Specialty = "Thần kinh", Experience = 12, Mobile = "0911000002", SurgeryType = "Não", NumberOfSurgeries = 180 });
            doctors.Add(new GeneralPractitioner { ID = "G01", FullName = "Dr. Chi", Gender = "Nữ", Specialty = "Đa khoa", Experience = 8, Mobile = "0911000003", WorkingHours = 40 });
            doctors.Add(new GeneralPractitioner { ID = "G02", FullName = "Dr. Dũng", Gender = "Nam", Specialty = "Gia đình", Experience = 5, Mobile = "0911000004", WorkingHours = 45 });
        }
    }

}
