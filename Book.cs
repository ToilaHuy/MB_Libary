using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop
{
    public class Book : Item
    {
        public int NumberOfPages { get; set; }

        public Book() { }
        public Book(int Id, string Title, string Author, string Category, string Description, DateTime PublicationDate, int NumberOfPages) : base(Id, Title, Author, Category, Description, PublicationDate, true)
        {
            this.NumberOfPages = NumberOfPages;
        }
        public override void addItem(int Id, string Category)
        {
            base.addItem(Id, Category);
            Console.WriteLine("So trang: ");
            this.NumberOfPages = Int32.Parse(Console.ReadLine());
        }
        public override void ShowItem()
        {
            base.ShowItem();
            Console.WriteLine("So trang: " + this.NumberOfPages);
            Console.WriteLine("------------------------------*---------------------------");
        }
    }
}