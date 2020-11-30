using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication
{
    public class LoanApplicationResponse
    {
        public int? ApplicationId { get; set; }

        public bool IsSuccessfull { get; set; }

        public IList<string> Errors { get; set; }

        public Exception Exception { get; set; }
    }
}
