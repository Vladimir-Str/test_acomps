using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_acomps.Data.Models
{
    public class Test3_model
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите строку для проверки")]
        [Display(Name = "Строка для проверки")]
        public string Str { get; set; }
        [Display(Name = "Результат")]
        public string Result { get; set; }
    }
}
