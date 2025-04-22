using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1
{
    public class StudentManager
    {
        public List<Student> Students = new List<Student>();

        public void AddStudent()
        {
            Student s = new Student();
            s.Input();
            if (Students.Any(x => x.StudentID == s.StudentID))
                Console.WriteLine("Mã sinh viên đã tồn tại.");
            else
            {
                Students.Add(s);
                Console.WriteLine("Thêm sinh viên thành công.");
            }
        }

        public void DisplayStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên trống.");
                return;
            }

            Console.WriteLine($"{"Mã HS",-8} | {"Họ Tên",-20} | {"Giới Tính",-10} | {"Chuyên Ngành",-15} | {"GPA",5:F2}");
            foreach (var s in Students) s.Output();
        }

        public void SearchStudent()
        {
            Console.Write("Nhập mã sinh viên cần tìm: ");
            string id = Console.ReadLine();
            var student = Students.FirstOrDefault(s => s.StudentID == id);
            if (student != null) student.Output();
            else Console.WriteLine("Không tìm thấy sinh viên.");
        }

        public void EditStudent()
        {
            Console.Write("Nhập mã sinh viên cần sửa: ");
            string id = Console.ReadLine();
            var student = Students.FirstOrDefault(s => s.StudentID == id);
            if (student != null)
            {
                Console.WriteLine("Nhập thông tin mới:");
                student.Input();
            }
            else Console.WriteLine("Không tìm thấy sinh viên.");
        }

        public void DeleteStudent()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string id = Console.ReadLine();
            var student = Students.FirstOrDefault(s => s.StudentID == id);
            if (student != null)
            {
                Students.Remove(student);
                Console.WriteLine("Đã xóa sinh viên.");
            }
            else Console.WriteLine("Không tìm thấy sinh viên.");
        }

        public void SortByGPA()
        {
            Students = Students.OrderByDescending(s => s.GPA).ToList();
            Console.WriteLine("Đã sắp xếp theo GPA giảm dần.");
            DisplayStudents();
        }

        public void SortByGPAThenName()
        {
            Students = Students.OrderByDescending(s => s.GPA).ThenBy(s => s.FullName).ToList();
            Console.WriteLine("Đã sắp xếp theo GPA giảm dần và tên tăng dần.");
            DisplayStudents();
        }
    }

}
