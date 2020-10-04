using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test_acomps.Data.Models
{
    public class Test1_model
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите через пробел массив целых чисел")]
        [RegularExpression(@"[- \d]*", ErrorMessage = "Допустимы только цифры, знак - и пробелы")]
        [Display(Name = "Массив чисел")]
        public string Mas { get; set; }
        [Display(Name = "Результат")]
        public int Result { get; set; }
    }
}
