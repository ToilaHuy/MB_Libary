using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop
{
    public class BorrowingHistory
    {
        public int IdBorrowingHistory { get; set; }
        public int BorrowerLibraryCardNumber { get; set; }
        public DateTime BorrowerDate { get; set; }
        public int IdItem { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }
        public string checkStatus;
        public BorrowingHistory(int BorrowerLibraryCardNumber, DateTime BorrowerDate, int IdItem, string Category, int IdBorrowingHistory)
        {
            this.BorrowerLibraryCardNumber = BorrowerLibraryCardNumber;
            this.BorrowerDate = BorrowerDate;
            this.IdItem = IdItem;
            this.Category = Category;
            this.Status = true;
            this.IdBorrowingHistory = IdBorrowingHistory;
        }
        public void Show()
        {
            checkStatus = this.Status ? "Dang muon" : "Da tra";
            Console.WriteLine("Ma lich su cho muon: " + this.IdBorrowingHistory);
            Console.WriteLine("So the thanh vien: " + this.BorrowerLibraryCardNumber);
            Console.WriteLine("Ngay muon: " + this.BorrowerDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("Ma san pham: " + this.IdItem);
            Console.WriteLine("Trang thai: " + checkStatus);
            Console.WriteLine("-----------------------------*---------------------");
        }

    }
}