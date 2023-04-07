using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop;

public class ListItem
{
    protected List<Item> listItem = new();

    public ListItem()
    {

        var listItemDefault = new Item[]{
            new Book(1, "sach", "huy", "book", "sach hay", DateTime.Parse("2012/12/5"), 100),
            new Book(2, "harry", "huy", "book", "sach hay", DateTime.Parse("2013/1/5"), 100),
            new Book(3, "may bay", "huy", "book", "sach hay", DateTime.Parse("2012/5/5"), 100),
            new DVD(4, "khim binh mai", "huy", "dvd", "sach hay", DateTime.Parse("2020/12/5"),"30p"),
            new DVD(5, "harry", "huy", "dvd", "sach hay", DateTime.Parse("2020/2/3"),"1h"),
            new DVD(6, "may bay", "huy", "dvd", "sach hay", DateTime.Parse("2020/3/20"), "20p"),
         };

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
            Console.WriteLine("Them thanh cong");
            Console.WriteLine("Nhan phim bat ki de thoat");
            Console.ReadKey();
        }
        else if (number == "2")
        {
            Item item = new DVD();
            item.Add(lastId, "dvd");
            listItem.Add(item);
            Console.WriteLine("Them thanh cong");
            Console.WriteLine("Nhan phim bat ki de thoat");
            Console.ReadKey();
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
        Console.WriteLine("Nhan phim bat ki de thoat");
        Console.ReadKey();
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
                Console.WriteLine("Khong tim thay san pham nao");
                Console.WriteLine("Nhan phim bat ki de thoat");
                Console.ReadKey();
                break;
            }
            checkItem.ForEach(item => item.Show());
            Console.WriteLine("Nhan phim bat ki de thoat");
            Console.ReadKey();
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
        Console.WriteLine("Sua thanh cong");
        Console.WriteLine("Nhan phim bat ki de thoat");
        Console.ReadKey();
    }
}
