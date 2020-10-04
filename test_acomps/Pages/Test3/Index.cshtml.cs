using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test_acomps.Data;
using test_acomps.Data.Models;

namespace test_acomps.Pages.Test3
{
    public class IndexModel : PageModel
    {
        private readonly test_acomps.Data.test_acompsContext _context;

        public IndexModel(test_acomps.Data.test_acompsContext context)
        {
            _context = context;
        }

        public IList<Test3_model> Test3_model { get;set; }

        public async Task OnGetAsync()
        {
            Test3_model = await _context.Test3_model.ToListAsync();
        }
    }
}
