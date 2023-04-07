using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace oop
{
    public class Item
    {
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public Boolean Status { get; set; }

        public Item() { }
        public Item(int Id, string Title, string Author, string Category, string Description, DateTime PublicationDate, Boolean Status)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.Category = Category;
            this.Description = Description;
            this.PublicationDate = PublicationDate;
            this.Status = Status;
        }

        public virtual void Add(int Id, string Category)
        {
            this.Id = Id;
            Console.WriteLine("Tieu de:");
            this.Title = Console.ReadLine();
            Console.WriteLine("Ten tac gia:");
            this.Author = Console.ReadLine();
            this.Category = Category;
            Console.WriteLine("Mo ta:");
            this.Description = Console.ReadLine();
            Console.WriteLine("Ngay phat hanh - YYYY/MM/DD ");
            this.PublicationDate = DateTime.Parse(Console.ReadLine());
            this.Status = true;
        }
        public virtual void Show()
        {
            Console.WriteLine("Ma san pham: " + Id);
            Console.WriteLine("Tieu de: " + Title);
            Console.WriteLine("Ten tac gia: " + Author);
            Console.WriteLine("Loai san pham: " + Category);
            Console.WriteLine("Mo ta: " + Description);
            Console.WriteLine("Ngay phat hanh: " + PublicationDate.ToString("dd/MM/yyyy"));
        }
        public virtual void Update(int Id, string Category)
        {
            this.Id = Id;
            Console.WriteLine("Tieu de:");
            string inputTitle = Console.ReadLine();
            this.Title = inputTitle?.Length > 0 ? inputTitle : this.Title;
            Console.WriteLine("Ten tac gia:");
            string inputAuthor = Console.ReadLine();
            this.Author = inputAuthor != "" ? inputAuthor : this.Author;
            this.Category = Category;
            Console.WriteLine("Mo ta:");
            string inputDescription = Console.ReadLine();
            this.Description = inputDescription != "" ? inputDescription : this.Description;
            Console.WriteLine("Ngay phat hanh - YYYY/MM/DD ");
            string inputDate = Console.ReadLine();
            this.PublicationDate = DateTime.TryParse(inputDate, out DateTime date) != default ? date : this.PublicationDate;
            this.Status = true;
        }
    }
}