using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX12
{
    public class GeneralPractitioner : Doctor
    {
        public int WorkingHours { get; set; }

        public override void Input()
        {
            Console.Write("ID: "); ID = Console.ReadLine();
            Console.Write("Họ tên: "); FullName = Console.ReadLine();
            Console.Write("Giới tính: "); Gender = Console.ReadLine();
            Console.Write("Chuyên khoa: "); Specialty = Console.ReadLine();
            Console.Write("Số năm kinh nghiệm: "); Experience = int.Parse(Console.ReadLine());
            Console.Write("Số điện thoại: "); Mobile = Console.ReadLine();
            Console.Write("Thời gian làm việc (giờ/tuần): "); WorkingHours = int.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            Console.WriteLine($"[GP] {ID} - {FullName} - {Gender} - {Specialty} - {Experience} năm - {Mobile} - {WorkingHours} giờ/tuần");
        }
    }

}
