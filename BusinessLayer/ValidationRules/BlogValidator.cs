using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık alanı boş geçilemez..");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik alanı boş geçilemez...");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Görsel alanı boş geçilemez...");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen en fazla 150 karakter veri girişi yapın...");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapın...");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik alanı boş geçilemez...");
        }
    }
}
