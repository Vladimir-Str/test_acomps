using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using test_acomps.Data;
using test_acomps.Data.Models;

namespace test_acomps.Pages.Test2
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
        public Test2_model Test2_model { get; set; }

        
        public LinkedList<byte> Sum(LinkedList<byte> list1, LinkedList<byte> list2)
        {
            var Result = new LinkedList<byte>();
            var maxlength = Math.Max(list1.Count, list2.Count);
            byte t = 0;
            var N1 = list1.Last;
            var N2 = list2.Last;

            while (N1!=null || N2 != null)
            {
                byte sum = (byte)((N1?.Value ?? 0) + (N2?.Value ?? 0) + t);
                if (sum >= 10)
                {
                    sum -= 10;
                    t = 1;
                }
                else
                {
                    t = 0;
                }
                N1 = N1?.Previous;
                N2 = N2?.Previous;
                Result.AddFirst(sum);
            }

            if (t > 0)
            {
                Result.AddLast(t);
            }

            return  Result;



        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            //для выполнения условий задания создаем два связанных списка и парсим в них полученные строки
            //из условия не ясно должна ли получившаяся сумма быть перевернутой как и списки, поэтому делаем в прямом порядке
            var Str1 = new LinkedList<byte>();
            var Str2 = new LinkedList<byte>();
            foreach (char c in Test2_model.Str1)
                Str1.AddFirst((byte)char.GetNumericValue(c)); //используем addfirst так как цифры в списке в обратном порядке, по условию
            foreach (char c in Test2_model.Str2)
                Str2.AddFirst((byte)char.GetNumericValue(c));
            //складываем в методе Sum получаем по условию связанный список, преобразовываем  его в строку для вывода и сохраняем в базе
            Test2_model.Result = "";
            foreach (byte b in Sum(Str1, Str2))
            Test2_model.Result+= b.ToString();
            _context.Test2_model.Add(Test2_model);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
