using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1
{
    public class Person
    {
        public string FullName { get; set; }
        public string Gender { get; set; }

        public virtual void Input()
        {
            Console.Write("Họ tên: ");
            FullName = Console.ReadLine();
            Console.Write("Giới tính: ");
            Gender = Console.ReadLine();
        }

        public virtual void Output()
        {
            Console.WriteLine($"Họ tên: {FullName}, Giới tính: {Gender}");
        }
    }
}
