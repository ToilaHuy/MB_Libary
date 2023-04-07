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

        public virtual void addItem(int Id, string Category)
        {
            this.Id = Id;
            Console.WriteLine("Tieu de:");
            this.Title = Console.ReadLine();
            Console.WriteLine("Ten tac gia:");
            this.Author = Console.ReadLine();
            this.Category = Category;
            Console.WriteLine("Mo ta:");
            this.Description = Console.ReadLine();
        l1: try
            {
                Console.WriteLine("Ngay phat hanh - YYYY/MM/DD ");
                this.PublicationDate = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Nhap sai roi");
                goto l1;
            }
            this.Status = true;
        }
        public virtual void ShowItem()
        {
            Console.WriteLine("Ma san pham: " + this.Id);
            Console.WriteLine("Tieu de: " + this.Title);
            Console.WriteLine("Ten tac gia: " + this.Author);
            Console.WriteLine("Loai san pham: " + this.Category);
            Console.WriteLine("Mo ta: " + this.Description);
            Console.WriteLine("Ngay phat hanh: " + this.PublicationDate.ToString("dd/MM/yyyy"));
        }
    }
}