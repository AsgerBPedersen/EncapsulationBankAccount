using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccountPage.Pages
{
    public class transactionsModel : PageModel
    {
        private readonly TransactionRepository tr = new TransactionRepository();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        public SelectList Sl = new SelectList(new []{ 1, 5, 10, 20, 50, 100, 200, 500, 1000 });
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Transaction> Transactions { get; set; }

        public void OnGet()
        {
            List<Transaction> data = tr.GetAllTransactions();
            Transactions = data.OrderBy(a => a.Id).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            Count = data.Count;
        }
        
    }
}