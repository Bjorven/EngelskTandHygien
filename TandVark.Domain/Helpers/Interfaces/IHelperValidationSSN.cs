using System;
using System.Collections.Generic;
using System.Text;

namespace TandVark.Domain.Helpers.Interfaces
{
    public interface IHelperValidationSSN
    {
        bool validate(string SSNr);
    }
}
