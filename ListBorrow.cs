using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop;

public class ListBorrow
{

    protected List<BorrowingHistory> borrowingHistory = new();
    protected List<Borrower> borrower = new();
    protected List<Item> ListItem { get; set; }
    public ListBorrow()
    {
        var listBorrower = new Borrower[]{
            new Borrower("huy","da nang",1),
            new Borrower("hieu","da nang",2),
            new Borrower("hai","da nang",3)
        };
        borrower.AddRange(listBorrower);
    }
    public void AddListItem(ListItem item)
    {
        this.ListItem = item.GetItems();
    }

    private static void ShowMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Nhan phim bat ki de thoat");
        Console.ReadKey();
    }

    public void AddBorrower()
    {
        int lastId = borrower[borrower.Count - 1].LibraryCardNumber > 0 ? borrower[borrower.Count - 1].LibraryCardNumber + 1 : 1;
        Borrower user = new();
        user.Add(lastId);
        borrower.Add(user);
        ShowMessage("Them thanh cong");
    }
    public void UpdateBorrower()
    {
        Console.WriteLine("vui long nhap ten hoac ma so the");
        string input = Console.ReadLine();
        var checkCount = borrower.FindAll(x => x.Name == input || x.LibraryCardNumber.ToString() == input);
        if (checkCount.Count > 1)
        {
            Console.WriteLine($"Hien tai co {checkCount.Count} nguoi dung trung ten");
            Console.WriteLine("------*------");

            checkCount.ForEach(item => item.Show());
            Console.WriteLine("Vui long nhap id nguoi dung");
            string inputId = Console.ReadLine();
            var findUser = borrower.Find(x => x.LibraryCardNumber.ToString() == inputId);
            findUser.Update(findUser.LibraryCardNumber);
        }
        else if (checkCount.Count == 0)
        {
            Console.WriteLine("khong tim thay nguoi dung nao");
            return;
        }
        else
        {
            var updateItem = borrower.Find(x => x.LibraryCardNumber.ToString() == input || x.Name.ToLower().Contains(input));
            updateItem.Show();
            updateItem.Update(updateItem.LibraryCardNumber);
        }
        ShowMessage("Sua thanh cong");
    }
    public void ShowBorrower()
    {
        foreach (var item in borrower)
        {
            item.Show();
            Console.WriteLine("-----------------------------------------------");
        }
        Console.WriteLine("Ban muon quay tro lai: y/n");
        string answer = Console.ReadLine();
    }
    public void BorrowItem()
    {
        borrower.ForEach(user => user.Show());
        Console.WriteLine("Vui long nhap ma the thanh vien:");
        string inputUser = Console.ReadLine();
        var checkUser = borrower.Find(item => item.LibraryCardNumber.ToString() == inputUser);
        ListItem.ForEach(item =>
        {
            if (item.Status) item.Show();
        });
        Console.WriteLine("Vui long nhap id hoac ten san pham ban muon muon ");
        string inputItems = Console.ReadLine();

        int lastId = borrowingHistory.Count > 0 ? borrowingHistory[^1].IdBorrowingHistory + 1 : 1;
        var findItems = ListItem.FindAll(item => item.Id.ToString() == inputItems || item.Title.ToLower().Contains(inputItems));
        if (findItems.Count == 0)
        {
            Console.WriteLine("San pham khong ton tai");
        }
        if (findItems.Count > 1)
        {
            findItems.ForEach(item => item.Show());
            Console.WriteLine("Vui long nhap id pham ban muon muon ");
            string inputItem = Console.ReadLine();
            var findItem = ListItem.Find(item => item.Id.ToString() == inputItem);
            if (findItem == null)
            {
                Console.WriteLine("Nhap sai id");
                return;
            }
            if (!findItem.Status)
            {
                Console.WriteLine("San pham khong con trong kho");
            }
            findItem.Status = false;

            borrowingHistory.Add(new BorrowingHistory(checkUser.LibraryCardNumber, DateTime.Now, findItem.Id, findItem.Category, lastId));
            ShowMessage("Muon thanh cong");
        }
        else
        {
            var item = ListItem.Find(item => item.Id.ToString() == inputItems || item.Title.ToLower().Contains(inputItems));
            if (!item.Status)
            {
                Console.WriteLine("San pham khong con trong kho");
                return;
            }
            if (item != null) item.Status = false;
            borrowingHistory.Add(new BorrowingHistory(checkUser.LibraryCardNumber, DateTime.Now, item.Id, item.Category, lastId));
            ShowMessage("Muon thanh cong");
        }
    }

    public void ReturnItem()
    {
        borrowingHistory.ForEach(item => item.Show());
        Console.WriteLine("Vui nhap ma hoa don: ");
        int id = int.Parse(Console.ReadLine());
        var itemHistory = borrowingHistory.Find(item => item.BorrowerLibraryCardNumber == id);

        itemHistory.Status = false;
        var findItem = ListItem.Find(item => item.Id == itemHistory.IdItem);
        if (findItem != null) findItem.Status = true;
        ShowMessage("Tra thanh cong");

        // StartProject();
    }

    public void ShowBorrowingHistory()
    {
        foreach (var item in borrowingHistory)
        {
            item.Show();
        }
        Console.WriteLine("Ban muon quay tro lai: y/n");
        string answer = Console.ReadLine();

    }
    public void ShowBorrowingHistoryDetails()
    {
        Console.WriteLine("Nhap ma so the thanh vien: ");
        int answer = int.Parse(Console.ReadLine());
        var listItems = borrowingHistory.FindAll(x => x.BorrowerLibraryCardNumber == answer);
        var user = borrower.Find(x => x.LibraryCardNumber == answer);
        string CheckDate = listItems.Count > 0 ? listItems[^1].BorrowerDate.ToString("dd/MM/yyyy") : "Chua muon lan nao";
        user.Show();
        Console.WriteLine("So lan muon: " + listItems.Count);
        Console.WriteLine("Lan muon gan nhat: " + CheckDate);
        Console.WriteLine("-----------------------------*---------------------");
        foreach (var item in listItems)
        {
            item.Show();
        }
    }
    public void ShowListBorrowingBookAndDvd()
    {
        var listUser = from user in borrower
                       join historyBook in from history in borrowingHistory
                                           where history.Category == "book"
                                           select history
                       on user.LibraryCardNumber equals historyBook.BorrowerLibraryCardNumber
                       join historyDvd in from history in borrowingHistory
                                          where history.Category == "dvd"
                                          select history
                       on user.LibraryCardNumber equals historyDvd.BorrowerLibraryCardNumber
                       select user;
        foreach (var item in listUser.Distinct())
        {
            item.Show();
        }
        ShowMessage("");
    }

}
