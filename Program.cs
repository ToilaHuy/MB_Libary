using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using System.IO.Pipes;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System;
// See https://aka.ms/new-console-template for more information
using oop;





ListItem listItem = new();
ListBorrow listBorrow = new();

listBorrow.AddListItem(listItem);
bool StartProject()
{
    while (true)
    {
        Console.WriteLine("Chon chuc nang ban muon su dung");
        Console.WriteLine("0 : Thoat truong chinh");
        Console.WriteLine("1 : In danh sach item");
        Console.WriteLine("2 : Them item");
        Console.WriteLine("3 : Xoa item");
        Console.WriteLine("4 : Tim kiem item");
        Console.WriteLine("5 : Sua item");
        Console.WriteLine("6 : Muon item");
        Console.WriteLine("7 : Tra item");
        Console.WriteLine("8 : In ra lich su muon item");
        Console.WriteLine("9 : In ra lich su muon item theo the thanh vien");
        Console.WriteLine("10 : In ra danh sach thanh vien");
        Console.WriteLine("11 : Them Thanh vien");
        Console.WriteLine("12 : Sua thanh vien");
        Console.WriteLine("13 : In ra danh sach sach");
        Console.WriteLine("14 : Dem so luong dvd co nam phat hanh la 2022");
        Console.WriteLine("15 : In ra danh sach cac nguoi dung vua muon dvd va sach ");




        switch (Console.ReadLine())
        {
            case "0": return false;
            case "1": listItem.ShowItem(); break;
            case "2": listItem.AddItem(); break;
            case "3": listItem.RemoveItem(); break;
            case "4": listItem.CheckItemExistence(); break;
            case "5": listItem.UpdateItem(); break;
            case "6": listBorrow.BorrowItem(); break;
            case "7": listBorrow.ReturnItem(); break;
            case "8": listBorrow.ShowBorrowingHistory(); break;
            case "9": listBorrow.ShowBorrowingHistoryDetails(); break;
            case "10": listBorrow.ShowBorrower(); break;
            case "11": listBorrow.AddBorrower(); break;
            case "12": listBorrow.UpdateBorrower(); break;
            case "13": listItem.ShowBook(); break;
            case "14": listItem.CountDVD(); break;
            case "15": listBorrow.ShowListBorrowingBookAndDvd(); break;


        }
    }
}
StartProject();
