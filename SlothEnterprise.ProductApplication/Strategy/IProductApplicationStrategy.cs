using SlothEnterprise.ProductApplication.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication.Strategy
{
    public interface IProductApplicationStrategy
    {
        LoanApplicationResponse SubmitApplicationFor(ISellerApplication application);
    }
}
