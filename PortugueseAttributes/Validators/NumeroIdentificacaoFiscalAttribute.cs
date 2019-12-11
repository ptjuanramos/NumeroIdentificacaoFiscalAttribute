using PortugueseAttributes.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace PortugueseAttributes.Validators
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NumeroIdentificacaoFiscalAttribute : ValidationAttribute
    {

        #region Attributes Properties
        public Boolean IsRequired { get; set; }

        private String _requiredErrorMessage;
        public String RequiredErrorMessage
        {
            get
            {
                return _requiredErrorMessage ?? (_requiredErrorMessage = ValidationMessages.VALIDATION_REQUIRED);
            }

            set
            {
                _requiredErrorMessage = value;
            }
        }

        private String _invalidErrorMessage;
        public String InvalidErrorMessage
        {
            get
            {
                return _invalidErrorMessage ?? (_invalidErrorMessage = ValidationMessages.VALIDATION_INVALID);
            }

            set
            {
                _invalidErrorMessage = value;
            }
        }

        private String _formatErrorMessage;
        public new String FormatErrorMessage
        {
            get
            {
                return _formatErrorMessage ?? (_formatErrorMessage = ValidationMessages.VALIDATION_INTEGER_FORMAT);
            }

            set
            {
                _formatErrorMessage = value;
            }
        }

        private String _lengthErrorMessage;
        public String LengthErrorMessage
        {
            get
            {
                return _lengthErrorMessage ?? (_lengthErrorMessage = ValidationMessages.VALIDATION_EXACT_LENGTH);
            }

            set
            {
                _lengthErrorMessage = value;
            }
        }
        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string obj = value == null ? string.Empty : value.ToString();
            if(!String.IsNullOrEmpty(obj)  && obj.Length != 9)
            {
                return new ValidationResult(LengthErrorMessage);
            }

            if(IsRequired && String.IsNullOrEmpty(obj))
            {
                return new ValidationResult(RequiredErrorMessage);
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
