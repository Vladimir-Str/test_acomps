using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using test_acomps.Data;
using test_acomps.Data.Models;

namespace test_acomps.Pages.Test1
{
    public class CreateModel : PageModel
    {
        private readonly test_acomps.Data.test_acompsContext _context;

        public CreateModel(test_acomps.Data.test_acompsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Test1_model Test1_model { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            //парсим полученную строку в массив int
            int[] mas = Test1_model.Mas.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToArray();
            //перебираем массив суммируя каждое второе если оно нечетное 
            //или выбираем нечетные и прибавляем каждое второе? из задания не понятно, наверное второе.
            bool second = false;
            Test1_model.Result = 0;
            foreach (int i in mas)
            {
                if (i % 2 != 0 && second==true)
                {
                    Test1_model.Result += Math.Abs(i);
                    second = false;
                } 
                else if (i % 2 != 0)
                {
                    second = true;    
                }

            }

            _context.Test1_model.Add(Test1_model);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
