using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop
{
    public class DVD : Item
    {
        public string RunTime { get; set; }

        public DVD() { }
        public DVD(int Id, string Title, string Author, string Category, string Description, DateTime PublicationDate, string RunTime) : base(Id, Title, Author, Category, Description, PublicationDate, true)
        {
            this.RunTime = RunTime;
        }

        public override void Add(int Id, string Category)
        {
            base.Add(Id, Category);
            Console.WriteLine("Thoi luong:");
            this.RunTime = Console.ReadLine();
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Thoi luong: " + this.RunTime);
            Console.WriteLine("------------------------------*---------------------------");
        }
        public override void Update(int Id, string Category)
        {
            base.Add(Id, Category);
            Console.WriteLine("Thoi luong:");
            this.RunTime = Console.ReadLine() != "" ? Console.ReadLine() : this.RunTime;
        }
    }
}