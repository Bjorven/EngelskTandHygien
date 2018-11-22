using System;
using System.Text.RegularExpressions;
using TandVark.Domain.Helpers.Interfaces;

namespace TandVark.Domain.Helpers
{
    public class HelperValidationSSN:IHelperValidationSSN
    {

        public bool Validate(string sSNr)
        {

            if (!Regex.Match(sSNr, @"^\d{12}$").Success)
                return false;
            int check = int.Parse(sSNr.Substring(11, 1));
            string sValue = sSNr.Substring(2, 9);

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
