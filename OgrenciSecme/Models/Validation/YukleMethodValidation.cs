using FluentValidation;
using OgrenciSecme.Models.OgrenciKayitModel;
using System;
using System.Linq;

namespace OgrenciSecme.Models.Validation
{
    internal class YukleMethodValidation : AbstractValidator<YukleMethodModel>
    {
        public YukleMethodValidation()
        {

            RuleFor(x => x.Egitim.Ders.ad).NotEmpty().WithMessage("Ders seçiniz.");
            RuleFor(x => x.Egitim.Grup.ad).NotEmpty().WithMessage("Grup seçiniz.");
        }
    }
}
