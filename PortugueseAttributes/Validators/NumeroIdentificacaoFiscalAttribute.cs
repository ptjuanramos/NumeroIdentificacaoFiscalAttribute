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
        private String _invalidErrorMessage;
        internal String InvalidErrorMessage
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
        internal new String FormatErrorMessage
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
        internal String LengthErrorMessage
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
