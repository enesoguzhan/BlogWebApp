using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationFluent
{
    public class ValidationUsers :AbstractValidator<Users>
    {
        public ValidationUsers()
        {
            RuleFor(s => s.NameSurname).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.NameSurname).MaximumLength(100).WithMessage("Max 100 Karekter");

            RuleFor(s => s.Password).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Password).MaximumLength(30).WithMessage("Max 30 Karekter");

            RuleFor(s => s.Summary).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Summary).MaximumLength(150).WithMessage("Max 150 Karekter");

            RuleFor(s => s.Email).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Doğru Email Adresi Giriniz");

            RuleFor(s => s.Explanation).NotEmpty().WithMessage("Boş Bırakılamaz");
        }
    }
}
