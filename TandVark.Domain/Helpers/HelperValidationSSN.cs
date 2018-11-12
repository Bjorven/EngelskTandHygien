using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TandVark.Domain.DTO;

namespace TandVark.Domain.Helpers
{
    public class HelperValidationSSN
    {



        public bool validate(PatientDTO SSNr)
        {
            if (SSNr.FldSSnumber == null)
                throw new ArgumentNullException($"Parameter {nameof(SSNr.FldSSnumber)} cannot be null", nameof(SSNr.FldSSnumber));
            if (!Regex.Match(SSNr.FldSSnumber, @"^\d{12}$").Success)
                throw new ArgumentNullException($"Parameter {nameof(SSNr.FldSSnumber)} Must be 12 characters long", nameof(SSNr.FldSSnumber));
            int check = int.Parse(SSNr.FldSSnumber.Substring(11, 1));
            string sValue = SSNr.FldSSnumber.Substring(2, 9);

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
