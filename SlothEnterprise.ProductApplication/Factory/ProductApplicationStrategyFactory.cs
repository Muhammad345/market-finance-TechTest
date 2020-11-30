using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication.Factory
{
    public class ProductApplicationStrategyFactory
    {
        private readonly ISelectInvoiceService _selectInvoiceService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly IBusinessLoansService _businessLoansService;

        public ProductApplicationStrategyFactory(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;
        }

        public IProductApplicationStrategy GetProductApplicationStrategy(ISellerApplication application)
        {
         
            if(application.Product is SelectiveInvoiceDiscount)
            {
                return new SelectiveInvoiceDiscountStrategy(_selectInvoiceService);
            }
            else if(application.Product is ConfidentialInvoiceDiscount)
            {
                return new ConfidentialInvoiceDiscountStrategy(_confidentialInvoiceWebService);
            }

            else if (application.Product is BusinessLoans)
            {
                return new BusinessLoansStrategy(_businessLoansService);
            }


            return null;
        }
    }
}
