using DataAccessLayer.Models;
using FluentValidation;

namespace BusinessLayer.ValidationFluent
{
    public class ValidationBlogs : AbstractValidator<Blogs>
    {
        public ValidationBlogs()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Name).MaximumLength(150).WithMessage("Max 150 Karakter");
            RuleFor(s => s.Explanation).NotEmpty().WithMessage("Boş Bırakılamaz.");
            
        }
    }
}
