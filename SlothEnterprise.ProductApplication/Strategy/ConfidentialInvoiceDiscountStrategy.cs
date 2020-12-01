using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication.Strategy
{
    public class ConfidentialInvoiceDiscountStrategy : IProductApplicationStrategy
    {
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;

        public ConfidentialInvoiceDiscountStrategy(IConfidentialInvoiceService confidentialInvoiceWebService)
        {
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
        }

        public LoanApplicationResponse SubmitApplicationFor(ISellerApplication application)
        {
            try
            {
                var cid = application.Product as ConfidentialInvoiceDiscount;
                var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                   new CompanyDataRequest
                   {
                       CompanyFounded = application.CompanyData.Founded,
                       CompanyNumber = application.CompanyData.Number,
                       CompanyName = application.CompanyData.Name,
                       DirectorName = application.CompanyData.DirectorName
                   }, cid.TotalLedgerNetworth, cid.AdvancePercentage, cid.VatRate);

                return new LoanApplicationResponse { IsSuccessfull = result.Success, ApplicationId = result.ApplicationId };

            }
            catch (Exception exp)
            {
                return new LoanApplicationResponse { IsSuccessfull = false, Exception = exp };
            }
        }
    }
}
