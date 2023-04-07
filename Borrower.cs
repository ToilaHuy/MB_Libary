using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop
{
    public class Borrower
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int LibraryCardNumber { get; set; }

        public Borrower() { }
        public Borrower(string name, string address, int libraryCardNumber)
        {
            Name = name;
            Address = address;
            LibraryCardNumber = libraryCardNumber;
        }
        public void Show()
        {
            Console.WriteLine("Ma nguoi dung: " + this.LibraryCardNumber);
            Console.WriteLine("Ten nguoi  dung: " + this.Name);
            Console.WriteLine("Dia chi: " + this.Address);
            Console.WriteLine("------------------------------*---------------------------");
        }
        public void Add(int libraryCardNumber)
        {
            LibraryCardNumber = libraryCardNumber;
            Console.WriteLine("Nhap ten thanh vien: ");
            Name = Console.ReadLine();
            Console.WriteLine("Nhap dia chi : ");
            Address = Console.ReadLine();
        }
        public void Update(int libraryCardNumber)
        {
            LibraryCardNumber = libraryCardNumber;
            Console.WriteLine("Nhap ten thanh vien: ");
            Name = Console.ReadLine();
            Console.WriteLine("Nhap dia chi : ");
            Address = Console.ReadLine();
        }
    }
}