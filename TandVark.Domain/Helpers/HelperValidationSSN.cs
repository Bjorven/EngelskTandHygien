using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TandVark.Domain.DTO;
using TandVark.Domain.Helpers.Interfaces;

namespace TandVark.Domain.Helpers
{
    public class HelperValidationSSN:IHelperValidationSSN
    {



        public bool validate(string SSNr)
        {
            
            if (!Regex.Match(SSNr, @"^\d{12}$").Success)
                throw new ArgumentNullException($"Parameter {nameof(SSNr)} Must be 12 characters long", nameof(SSNr));
            int check = int.Parse(SSNr.Substring(11, 1));
            string sValue = SSNr.Substring(2, 9);

            int result = 0;

            for (int i = 0, len = sValue.Length; i < len; i++)
            {
                int tmp = int.Parse(sValue.Substring(i, 1));

                if ((i % 2) == 0)
                {
                    tmp *= 2;
                }

                if (tmp > 9)
                {
                    result += (1 + (tmp % 10));
                }
                else
                {
                    result += tmp;
                }
            }

            return ((check + result) % 10) == 0;
        }
    }
}
