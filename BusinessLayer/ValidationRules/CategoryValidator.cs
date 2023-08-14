using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategorinin adı boş geçilemez...");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategorinin açıklaması boş geçilemez...");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı 50 karakterden fazla olamaz...");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori adı 2 karakterden az olamaz...");
        }
    }
}
