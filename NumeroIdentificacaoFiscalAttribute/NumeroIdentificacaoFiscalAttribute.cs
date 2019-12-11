using NumeroIdentificacaoFiscalAttribute;
using NumeroIdentificacaoFiscalAttributeValidation.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace NumeroIdentificacaoFiscalAttributeValidation
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NumeroIdentificacaoFiscalAttribute : ValidationAttribute
    {
        private String _invalidErrorMessage;
        public String InvalidErrorMessage
        {
            get
            {
                return _invalidErrorMessage ?? (_invalidErrorMessage = ValidationMessages.VALIDATION_INVALID);
            }
        }

        private String _formatErrorMessage;
        public new String FormatErrorMessage
        {
            get
            {
                return _formatErrorMessage ?? (_formatErrorMessage = ValidationMessages.VALIDATION_INTEGER_FORMAT);
            }
        }

        private String _lengthErrorMessage;
        public String LengthErrorMessage
        {
            get
            {
                return _lengthErrorMessage ?? (_lengthErrorMessage = ValidationMessages.VALIDATION_EXACT_LENGTH);
            }
        }

        public NumeroIdentificacaoFiscalAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string obj = value == null ? string.Empty : value.ToString();
            if(obj.Length != 9)
            {
                return new ValidationResult(LengthErrorMessage);
            }

            try
            {
                bool isNifValid = NifValidationHelper.IsNIFValid((string)obj);
                return isNifValid ? ValidationResult.Success : new ValidationResult(InvalidErrorMessage);
            } catch(FormatException)
            {
                return new ValidationResult(FormatErrorMessage);
            }
        }
    }
}
