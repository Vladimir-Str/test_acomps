using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using test_acomps.Data;
using test_acomps.Data.Models;

namespace test_acomps.Pages.Test3
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
        public Test3_model Test3_model { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            //округленный центр строки
            int half = Test3_model.Str.Length / 2;
            //получаем первую половину строки
            string starthalfstring = Test3_model.Str.Substring(0,half).ToUpper();
            //получаем вторую половину строки
            string finhalfstring = Test3_model.Str.Substring(half+ Test3_model.Str.Length % 2).ToUpper();
            //реверс второй половины
            finhalfstring = new string(finhalfstring.ToCharArray().Reverse().ToArray());
            //сравниваем
            if (string.Compare(starthalfstring,finhalfstring)==0)
            {
                Test3_model.Result = "Строка является полиндромом";
            } 
            else Test3_model.Result = "Строка не является полиндромом";

            //сохраняем в базу и возвращаемся к списку
            _context.Test3_model.Add(Test3_model);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
