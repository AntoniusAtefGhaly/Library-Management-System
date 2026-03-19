using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Dtos.Transaction
{
    public class TransactionExcellData
    {
        public string? Book { get; set; }
        public string? User { get; set; }
        public string? RequestDate { get; set; }
        public string? IssueDate { get; set; }
        public string? DueDate { get; set; }
        public string? ReturnDate { get; set; }
        public string? Status    { get; set; }
        public string? IssuedByUser { get; set; }
        public string? ReturnedByUser { get; set; }

    }
}
