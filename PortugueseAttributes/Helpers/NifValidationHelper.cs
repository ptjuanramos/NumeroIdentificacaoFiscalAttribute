using System;
using System.Collections.Generic;
using System.Text;

namespace PortugueseAttributes.Helpers
{
    public class NifValidationHelper
    {

        /// <summary>
        /// Algorith from https://pt.wikipedia.org/wiki/N%C3%BAmero_de_identifica%C3%A7%C3%A3o_fiscal 
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool IsNIFValid(string nif)
        {
            if(!Int32.TryParse(nif, out _))
            {
                throw new FormatException();
            }

            char[] nifAsCharArray = nif.ToCharArray();
            return GetNifCheckDigit(nif.ToCharArray()) == CalculateControlDigit(nifAsCharArray);
        }

        private static int CalculateControlDigit(char[] nifAsCharArray)
        {
            int total = 0;
            for(int i = 0; i <= 7; i++)
            {
                int nifDigit = Int32.Parse(nifAsCharArray[i].ToString());
                total += nifDigit * (nifAsCharArray.Length - i);
            }

            int ascValue = total % 11;
            return ascValue < 2 ? 0 : 11 - ascValue;
        }

        private static int GetNifCheckDigit(char[] nifAsCharArray)
        {
            int checkedDigit = Int32.Parse(nifAsCharArray[nifAsCharArray.Length - 1].ToString());
            return checkedDigit;
        }

    }
}
