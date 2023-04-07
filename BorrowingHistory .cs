using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oop
{
    public class BorrowingHistory
    {
        public int BorrowerLibraryCardNumber { get; set; }
        public DateTime BorrowerDate { get; set; }
        public int IdItem { get; set; }
        public string Category { get; set; }
        public bool Status { get; set; }

        public BorrowingHistory(int BorrowerLibraryCardNumber, DateTime BorrowerDate, int IdItem, string Category)
        {
            this.BorrowerLibraryCardNumber = BorrowerLibraryCardNumber;
            this.BorrowerDate = BorrowerDate;
            this.IdItem = IdItem;
            this.Category = Category;
            this.Status = true;
        }
    }
}