using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountPage.Pages
{
    public class indexModel : PageModel
    {

        public decimal AccountTotals { get; set; }

        public indexModel()
        {
            AccountRepository ac = new AccountRepository();
            AccountTotals = ac.GetAccountTotals();
        }

        public void OnGet()
        {

        }
    }
}