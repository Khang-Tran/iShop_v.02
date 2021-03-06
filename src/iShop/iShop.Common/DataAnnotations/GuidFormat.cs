﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iShop.Common.DataAnnotations
{
    public class GuidFormat: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                bool isValid = Guid.TryParse(value.ToString(), out var output);
                return isValid && output != Guid.Empty;
            }
            catch (Exception)
            {
                return false;
            }    
        }
    }
}
