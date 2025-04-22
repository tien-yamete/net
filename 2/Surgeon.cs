using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX12
{
    public class Surgeon : Doctor
    {
        public string SurgeryType { get; set; }
        public int NumberOfSurgeries { get; set; }

        public override void Input()
        {
            Console.Write("ID: "); ID = Console.ReadLine();
            Console.Write("Họ tên: "); FullName = Console.ReadLine();
            Console.Write("Giới tính: "); Gender = Console.ReadLine();
            Console.Write("Chuyên khoa: "); Specialty = Console.ReadLine();
            Console.Write("Số năm kinh nghiệm: "); Experience = int.Parse(Console.ReadLine());
            Console.Write("Số điện thoại: "); Mobile = Console.ReadLine();
            Console.Write("Loại phẫu thuật: "); SurgeryType = Console.ReadLine();
            Console.Write("Số ca phẫu thuật: "); NumberOfSurgeries = int.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            Console.WriteLine($"[Surgeon] {ID} - {FullName} - {Gender} - {Specialty} - {Experience} năm - {Mobile} - {SurgeryType} - {NumberOfSurgeries} ca");
        }
    }

}
