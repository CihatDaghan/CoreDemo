using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x=>x.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en az 2 karakter girişi yapın");
        }

        private bool IsPasswordValid(string arg)
        {
            if (arg != null)
            {
                Regex regex = new Regex(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,})"); //En az 8 karakter uzunluğunda 1 karakter büyük ve 1 karakter küçük regex
                return regex.IsMatch(arg);
            }
            return false;
         
        }
    }
}
