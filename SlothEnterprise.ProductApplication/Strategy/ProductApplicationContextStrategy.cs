using SlothEnterprise.ProductApplication.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication.Strategy
{
    public class ProductApplicationContextStrategy
    {
        private readonly IProductApplicationStrategy productApplicationStrategy;

        public ProductApplicationContextStrategy(IProductApplicationStrategy productApplicationStrategy)
        {
            this.productApplicationStrategy = productApplicationStrategy;
        }

        public LoanApplicationResponse ExecuteStrategy(ISellerApplication application)
        {
            return productApplicationStrategy.SubmitApplicationFor(application);
        }
    }
}
