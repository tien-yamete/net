using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1
{
    class Program
    {
        static StudentManager manager = new StudentManager();

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n===== MENU QUẢN LÝ SINH VIÊN =====");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Tìm kiếm sinh viên");
                Console.WriteLine("4. Sửa thông tin sinh viên");
                Console.WriteLine("5. Xóa sinh viên");
                Console.WriteLine("6. Sắp xếp theo GPA giảm dần");
                Console.WriteLine("7. Sắp xếp theo GPA và tên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string c = Console.ReadLine();

                switch (c)
                {
                    case "1": manager.AddStudent(); break;
                    case "2": manager.DisplayStudents(); break;
                    case "3": manager.SearchStudent(); break;
                    case "4": manager.EditStudent(); break;
                    case "5": manager.DeleteStudent(); break;
                    case "6": manager.SortByGPA(); break;
                    case "7": manager.SortByGPAThenName(); break;
                    case "0": return;
                    default: Console.WriteLine("Không hợp lệ."); break;
                }
            }
        }
    }

}
