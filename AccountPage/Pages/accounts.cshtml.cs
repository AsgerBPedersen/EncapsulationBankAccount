using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountPage.Pages
{
    public class accountsModel : PageModel
    {
        private readonly AccountRepository ar = new AccountRepository();

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Account> Accounts { get; set; }

        public void OnGet()
        {
            List<Account> data = ar.GetAllAcounts();
            Accounts = data.OrderBy(a => a.Id).Skip((CurrentPage -1) * PageSize).Take(PageSize).ToList();
            Count = data.Count;
        }
        
    }
}