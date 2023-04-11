using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
namespace oop;

public class ListItem
{
    protected List<Item> listItem = new();
    public ListItem(Item[] listItemDefault)
    {
        listItem.AddRange(listItemDefault);
    }
    public List<Item> GetItems()
    {
        return listItem;
    }
    public void RemoveItem()
    {
        listItem.ForEach(item =>
        {
            if (item.Status) item.Show();
        });
        Console.WriteLine("Vui long nhap id hoac ten item muon xoa");
        string input = Console.ReadLine();
        var indexItems = listItem.FindIndex(x => x.Id.ToString() == input || x.Title.ToLower() == input);
        var checkCount = listItem.FindAll(x => x.Id.ToString() == input || x.Title.ToLower() == input);
        if (checkCount.Count > 1)
        {
            Console.WriteLine($"Hien tai co {checkCount.Count} san pham trung ten");
            Console.WriteLine("------*------");

            checkCount.ForEach(item => item.Show());
            Console.WriteLine("Vui long nhap id item ban muon xoa");
            string inputId = Console.ReadLine();
            var indexItem = listItem.FindIndex(x => x.Id.ToString() == inputId);
            listItem.RemoveAt(indexItem);
        }
        else
        {
            listItem.RemoveAt(indexItems);
        }
        Console.WriteLine("Ban da xoa thanh cong");
        Console.WriteLine("Them thanh cong");
        Console.WriteLine("Nhan phim bat ki de thoat");
        Console.ReadKey();

    }
    private static void ShowMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Nhan phim bat ki de thoat");
        Console.ReadKey();
    }

    public void AddItem()
    {
        Console.WriteLine("Vui long chon loai item ban muon nhap:");
        Console.WriteLine("1: Book");
        Console.WriteLine("2: DVD");
        Console.WriteLine("3: Quay tro lai");
        string number = Console.ReadLine();
        int listItemCount = listItem.Count - 1;
        int lastId = listItem[listItemCount].Id > 0 ? listItem[listItemCount].Id + 1 : 1;
        if (number == "1")
        {
            Book item = new();
            item.Add(lastId, "book");
            listItem.Add(item);
            ShowMessage("Them thanh cong");
        }
        else if (number == "2")
        {
            Item item = new DVD();
            item.Add(lastId, "dvd");
            listItem.Add(item);
            ShowMessage("Them thanh cong");
        }
        else if (number == "3")
        {
            return;
        }
    }
    public void ShowItem()
    {
        listItem.ForEach(item =>
        {
            if (item.Status) item.Show();
        });
        ShowMessage("");
    }
    public void CheckItemExistence()
    {
        while (true)
        {
            Console.WriteLine("Vui long nhap id hoac ten item muon kiem tra");
            string input = Console.ReadLine();
            var checkItem = listItem.FindAll(x => x.Id.ToString() == input || x.Title.ToLower().Contains(input));
            Console.WriteLine(checkItem.Count);
            if (checkItem.Count == 0)
            {
                Console.Clear();

                ShowMessage("Khong tim thay san pham nao");

                break;
            }
            checkItem.ForEach(item => item.Show());
            ShowMessage("");
            break;
        }
    }
    public void UpdateItem()
    {
        listItem.ForEach(item =>
        {
            if (item.Status) item.Show();
        });

        Console.WriteLine("Vui long nhap id hoac  ten item ban muon sua");
        string inputItems = Console.ReadLine();
        var checkCount = listItem.FindAll(x => x.Id.ToString() == inputItems || x.Title.ToLower().Contains(inputItems));
        if (checkCount.Count > 1)
        {
            Console.WriteLine($"Hien tai co {checkCount.Count} san pham trung ten");
            Console.WriteLine("---------");
            checkCount.ForEach(item => item.Show());
            Console.WriteLine("vui long nhap id item de sua");
            string inputItem = Console.ReadLine();
            if (inputItem?.Length == 0)
            {
                Console.WriteLine("du lieu khong hop le"); return;
            }
            var updateItem = listItem.Find(x => x.Id.ToString() == inputItem);
            updateItem.Show();
            updateItem.Update(updateItem.Id, updateItem.Category);
        }
        else if (checkCount.Count == 0)
        {
            Console.WriteLine("khong tim thay san pham nao");
            return;
        }
        else
        {
            var updateItem = listItem.Find(x => x.Id.ToString() == inputItems || x.Title.ToLower().Contains(inputItems));
            updateItem.Show();
            updateItem.Update(updateItem.Id, updateItem.Category);
        }
        ShowMessage("Sua thanh cong");
    }

    public void ShowBook()
    {
        var listBook = listItem.Where(book => book.Category == "book").ToList();
        // var listBookQuery = from item in listItem where item.Category == "book" select item;
        listBook.ForEach(x => x.Show());
        Console.WriteLine("Ban co muon sap xep danh sach khong? Y/N");
        string answer = Console.ReadLine();
        if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
        {
            Console.Clear();
            listBook.OrderByDescending(x => x.Title).ToList().ForEach(x => x.Show());
        }
        ShowMessage("");
    }

    public void CountDVD()
    {
        // var countDvd = from item in listItem
        //                where item.Category == "dvd" && item.PublicationDate.Year == 2022
        //                select item;
        var countDvd = listItem.Count(x => x.Category == "dvd" && x.PublicationDate.Year == 2022);
        Console.WriteLine("So luong san pham dvd co nam phat hanh la 2022: " + countDvd);
        ShowMessage("");
    }
}