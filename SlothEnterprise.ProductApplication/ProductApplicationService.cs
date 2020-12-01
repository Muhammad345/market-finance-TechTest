using System;
using System.Collections.Generic;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Factory;
using SlothEnterprise.ProductApplication.Products;
using SlothEnterprise.ProductApplication.Strategy;

namespace SlothEnterprise.ProductApplication
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly ProductApplicationStrategyFactory _productApplicationStrategyFactory;
        private ProductApplicationContextStrategy _productApplicationContextStrategy;

        public ProductApplicationService(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _productApplicationStrategyFactory = new ProductApplicationStrategyFactory(selectInvoiceService, confidentialInvoiceWebService, businessLoansService);
        }

        public LoanApplicationResponse SubmitApplicationFor(ISellerApplication application)
        {
           var productApplicationStrategy = _productApplicationStrategyFactory.GetProductApplicationStrategy(application);
            _productApplicationContextStrategy = new ProductApplicationContextStrategy(productApplicationStrategy);

            return _productApplicationContextStrategy.ExecuteStrategy(application);
        }
    }
}
