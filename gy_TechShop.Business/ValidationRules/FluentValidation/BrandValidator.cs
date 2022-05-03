using FluentValidation;
using gy_TechShop.Entities.Concrete;
using gy_TechShop.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gy_TechShop.Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<BrandAddDto>
    {
        public BrandValidator()
        {
            RuleFor(i=> i. BrandName).MinimumLength(3).WithMessage("En az 3 harften oluşmalı");
        }
    }
}
