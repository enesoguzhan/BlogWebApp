using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationFluent
{
    public class ValidationComment : AbstractValidator<Comments>
    {
        public ValidationComment()
        {
            RuleFor(s => s.Commenter).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Commenter).MaximumLength(100).WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Email).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Doğru Email Adresi Giriniz");
        }
    }
}
