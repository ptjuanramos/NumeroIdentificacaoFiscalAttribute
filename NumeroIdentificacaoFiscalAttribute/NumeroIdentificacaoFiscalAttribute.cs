using NumeroIdentificacaoFiscalAttribute.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace NumeroIdentificacaoFiscalAttribute
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NumeroIdentificacaoFiscalAttribute : ValidationAttribute
    {
        public NumeroIdentificacaoFiscalAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if((value is string) == false)
            {
                throw new FormatException($"{validationContext.DisplayName} Property needs to be 'string'");
            }

            string obj = value == null ? string.Empty : (string) value;
            if(obj.Length != 9)
            {
                return new ValidationResult("PT NIF number has 9 digits");
            }

            bool isNifValid = NifValidationHelper.IsNIFValid((string) obj);
            return isNifValid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
