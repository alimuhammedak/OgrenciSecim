using FluentValidation;
using FluentValidation.Validators;
using OgrenciSecme.Models.OgrenciSecimModel;
using System;
using System.Linq;

namespace OgrenciSecme.Models.Validation
{
    internal class SecimMethodValidation : AbstractValidator<SecimMethodModel>
    {
        public SecimMethodValidation()
        {
            RuleFor(x => x.Egitim.Ders.ad).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Egitim.Grup.ad).NotEmpty().WithMessage("Grup seçiniz.");
        }
    }
}
