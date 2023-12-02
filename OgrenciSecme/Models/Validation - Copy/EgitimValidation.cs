using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciSecme.Models.Validation
{
    public class EgitimValidation : AbstractValidator<Egitim>
    {
        public EgitimValidation()
        {
            RuleFor(expression:x => x.donemID).NotEmpty().WithMessage("Dönem seçiniz.");
            //RuleFor(x => x.donemID).NotNull().WithMessage("Dönem seçiniz.");
            RuleFor(x => x.dersID).NotEmpty().WithMessage("Ders seçiniz.");
            //RuleFor(x => x.dersID).NotNull().WithMessage("Ders seçiniz.");
            RuleFor(x => x.grupID).NotEmpty().WithMessage("Grup seçiniz.");
            //RuleFor(x => x.grupID).NotNull().WithMessage("Grup seçiniz.");

        }
    }
}
