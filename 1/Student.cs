using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1
{
    public class Student : Person
    {
        public string StudentID { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public override void Input()
        {
            Console.Write("Mã sinh viên: ");
            StudentID = Console.ReadLine();
            base.Input();
            Console.Write("Ngành học: ");
            Major = Console.ReadLine();
            Console.Write("GPA: ");
            GPA = double.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            Console.WriteLine($"{StudentID,-8} | {FullName,-20} | {Gender,-10} | {Major,-15} | {GPA,5:F2}");
        }
    }

}
