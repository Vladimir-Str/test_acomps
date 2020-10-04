using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_acomps.Data.Models
{
    public class Test2_model
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите целое положительное число")]
        [Display(Name = "Список 1")]
        [RegularExpression(@"[\d]*", ErrorMessage = "Допустимы только цифры")]
        public string Str1 { get; set; }

        [Required(ErrorMessage = "Введите целое положительное число")]
        [Display(Name = "Список 2")]
        [RegularExpression(@"[\d]*", ErrorMessage = "Допустимы только цифры")]
        public string Str2 { get; set; }

        [Display(Name = "Результат по-узлового сложения)")]
        public string Result { get; set; }
    }
}
