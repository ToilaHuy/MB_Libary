using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop;

public class ListItem
{
    readonly List<Borrower> borrower = new() {
        new Borrower("huy","da nang",1),
        new Borrower("hieu","da nang",2),
        new Borrower("hai","da nang",3)
    };
    readonly List<Item> listItem = new(){
        new Book (1, "sach", "huy", "book", "sach hay", DateTime.Parse("2012/12/5"), 100),
        new Book (2, "harry", "huy", "book", "sach hay", DateTime.Parse("2013/1/5"), 100),
        new Book (3, "may bay", "huy", "book", "sach hay", DateTime.Parse("2012/5/5"), 100),
        new DVD (4, "khim binh mai", "huy", "dvd", "sach hay", DateTime.Parse("2020/12/5"),"30p"),
        new DVD (5, "harry", "huy", "dvd", "sach hay", DateTime.Parse("2020/2/3"),"1h"),
        new DVD (6, "may bay", "huy", "dvd", "sach hay", DateTime.Parse("2020/3/20"), "20p"),
    };
    readonly List<BorrowingHistory> borrowingHistory = new();
    public void StartProject()
    {
        Console.WriteLine("Chon chuc nang ban muon su dung");
        Console.WriteLine("1 : In danh sach item");
        Console.WriteLine("2 : Them item");
        Console.WriteLine("3 : Xoa item");
        Console.WriteLine("4 : Kiem tra item ton tai");
        Console.WriteLine("5 : Sua item");
        Console.WriteLine("6 : Muon item");
        Console.WriteLine("7 : Tra item");
        Console.WriteLine("8 : In ra lich su muon item");
        Console.WriteLine("9 : In ra lich su muon item theo the thanh vien");
        Console.WriteLine("10 : In ra danh sach thanh vien");



        string number = Console.ReadLine();
        CheckNumber(number);
    }

    void CheckNumber(string number)
    {
        switch (number)
        {
            case "1": ShowItem(); break;
            case "2": AddItem(); break;
            case "3": RemoveItem(); break;
            case "4": CheckItemExistence(); break;
            case "5": EditItem(); break;
            case "6": BorrowItem(); break;
            case "7": ReturnItem(); break;
            case "8": ShowBorrowingHistory(); break;
            case "9": ShowBorrowingHistoryDetails(); break;
            case "10": ShowBorrower(); break;
        }
    }
    void Callback(string name)
    {

        Console.WriteLine("Ban muon tiep tuc: Y/N");
        var input = Console.ReadLine();
        if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase))
        {
            switch (name)
            {
                case "ReturnItem":
                    ReturnItem();
                    break;
                case "BorrowItem":
                    BorrowItem();
                    break;
                case "EditItem":
                    EditItem();
                    break;
                case "AddItem":
                    AddItem();
                    break;
                case "RemoveItem":
                    RemoveItem();
                    break;
                case "CheckItemExistence":
                    CheckItemExistence();
                    break;
                case "ShowBorrowingHistoryDetails":
                    ShowBorrowingHistoryDetails();
                    break;
            }
        }
        else
        {
            StartProject();
        }
    }
    public void ReturnItem()
    {
        Console.WriteLine("Vui long nhap id san pham muon tra ");
        int id = int.Parse(Console.ReadLine());
        var itemHistory = borrowingHistory.Find(item => item.IdItem == id);
        if (itemHistory == null)
        {
            Console.WriteLine("Id khong dung");
            Callback("ReturnItem");
        }
        else
        {
            itemHistory.Status = false;
        }
        var findItem = listItem.Find(item => item.Id == id);
        if (findItem != null) findItem.Status = true;
        Console.WriteLine("Tra thanh cong");
        StartProject();

    }
    public void BorrowItem()
    {
        Console.WriteLine("Vui long nhap ten nguoi muon");
        string name = Console.ReadLine();
        var checkName = borrower.Find(item => item.Name == name);
        var getIndexName = borrower.FindIndex(item => item.Name == name);
        if (checkName == null)
        {
            Console.WriteLine("Ten " + name + " khong tim thay");

            Callback("BorrowItem");
        }
    l2: Console.WriteLine("Vui long nhap id san pham ban muon muon ");
        int idItem = int.Parse(Console.ReadLine());
        var findItem = listItem.Find(item => item.Id == idItem);
        if (findItem == null)
        {
            Console.WriteLine("Id khong dung");
            Callback("BorrowItem");
        }
        if (!findItem.Status)
        {
            Console.WriteLine("San pham khong con trong kho");
            goto l2;
        }
        if (findItem != null) findItem.Status = false;
        int lastId = borrowingHistory.Count > 0 ? borrowingHistory[^1].IdBorrowingHistory + 1 : 1;
        borrowingHistory.Add(new BorrowingHistory(borrower[getIndexName].LibraryCardNumber, DateTime.Now, idItem, "book", lastId));
        Console.WriteLine("Muon thanh cong");
        StartProject();
    }
    public void RemoveItem()
    {
        Console.WriteLine("Vui long nhap id item muon xoa");
        int id = int.Parse(Console.ReadLine());
        var index = listItem.FindIndex(x => x.Id == id);
        if (index < 0)
        {
            Console.WriteLine("Id khong dung");
            Callback("RemoveItem");
        }
        listItem.RemoveAt(index);
        Console.WriteLine("Ban da xoa thanh cong");
        Console.WriteLine("Ban muon quay tro lai: y/n");
        string answer = Console.ReadLine();
        if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
    }
    public static string ChooseCategory()
    {
        Console.WriteLine("1: Book");
        Console.WriteLine("2: DVD");
        Console.WriteLine("3: Quay tro lai");
        return Console.ReadLine();
    }
    public void AddItem()
    {
        Console.WriteLine("Vui long chon loai item ban muon nhap:");
        string number = ChooseCategory();
        int lastId = listItem[^1].Id > 0 ? listItem[^1].Id + 1 : 1;
        if (number == "1")
        {
            Book item = new();
            item.addItem(lastId, "book");
            listItem.Add(item);
            Console.WriteLine("Them thanh cong");
            Console.WriteLine("Ban muon quay tro lai: y/n");
            string answer = Console.ReadLine();
            if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
        }
        else if (number == "2")
        {
            Item item = new DVD();
            item.addItem(lastId, "dvd");
            listItem.Add(item);
            Console.WriteLine("Them thanh cong");

            Console.WriteLine("Ban muon quay tro lai: y/n");
            string answer = Console.ReadLine();
            if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
        }
        else if (number == "3")
        {
            StartProject();
        }
    }
    public void ShowItem()
    {
        foreach (var item in listItem)
        {
            if (item.Status)
                item.ShowItem();
        }
        Console.WriteLine("Ban muon quay tro lai: y/n");
        string answer = Console.ReadLine();
        if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
    }
    public void ShowBorrower()
    {
        foreach (var item in borrower)
        {
            item.showBorrower();
            Console.WriteLine("-----------------------------------------------");
        }
        Console.WriteLine("Ban muon quay tro lai: y/n");
        string answer = Console.ReadLine();
        if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
    }
    public void ShowBorrowingHistory()
    {
        foreach (var item in borrowingHistory)
        {
            item.ShowBorrowingHistory();
        }
        Console.WriteLine("Ban muon quay tro lai: y/n");
        string answer = Console.ReadLine();
        if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
    }
    public void ShowBorrowingHistoryDetails()
    {
        Console.WriteLine("Nhap ma so the thanh vien: ");
        int answer = int.Parse(Console.ReadLine());
        var listItems = borrowingHistory.FindAll(x => x.BorrowerLibraryCardNumber == answer);
        var user = borrower.Find(x => x.LibraryCardNumber == answer);
        string CheckDate = listItems.Count > 0 ? listItems[^1].BorrowerDate.ToString("dd/MM/yyyy") : "Chua muon lan nao";
        user.showBorrower();
        Console.WriteLine("So lan muon: " + listItems.Count);
        Console.WriteLine("Lan muon gan nhat: " + CheckDate);
        Console.WriteLine("-----------------------------*---------------------");
        foreach (var item in listItems)
        {
            item.ShowBorrowingHistory();
        }

        Callback("ShowBorrowingHistoryDetails");

    }
    public void CheckItemExistence()
    {
        Console.WriteLine("Ban muon kiem tra item, vui long nhap id:");
        int idItem = int.Parse(Console.ReadLine());
        var check = listItem.Find(item => item.Id == idItem);
        if (check != null)
        {
            Console.WriteLine("San pham ton tai");
            Callback("CheckItemExistence");
        }
        else
        {
            Console.WriteLine("San pham khong ton tai");
            Callback("CheckItemExistence");

        }
    }

    public void EditItem()
    {
        Console.WriteLine("Vui long nhap id item ban muon sua");
        int itemId = 0;
        try
        {
            itemId = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Nhap sai kieu du lieu");
            Callback("EditItem");
        }
        var indexItem = listItem.FindIndex(x => x.Id == itemId);
        if (indexItem < 0)
        {
            Console.WriteLine("Id khong dung");
            Callback("EditItem");
        }

        var Category = listItem[indexItem].Category;
        listItem[indexItem].ShowItem();

        try
        {
            if (Category == "book")
            {
                listItem.RemoveAt(indexItem);
                Book book = new();
                book.addItem(itemId, Category);
                listItem.Add(book);
                Console.WriteLine("Sua thanh cong");
                Console.WriteLine("Ban muon quay tro lai: y/n");
                string answer = Console.ReadLine();
                if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
            }
            else if (Category == "dvd")
            {
                listItem.RemoveAt(indexItem);
                DVD dvd = new();
                dvd.addItem(itemId, Category);
                listItem.Add(dvd);
                Console.WriteLine("Sua thanh cong");
                Console.WriteLine("Ban muon quay tro lai: y/n");
                string answer = Console.ReadLine();
                if (string.Equals(answer, "y", StringComparison.InvariantCultureIgnoreCase)) StartProject();
            }
        }
        catch
        {
            Console.WriteLine("Du lieu nhap khong dung");
            Callback("EditItem");
        }
    }
}
