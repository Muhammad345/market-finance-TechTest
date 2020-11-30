using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication
{
    public class SelectiveInvoiceDiscountStrategy : IProductApplicationStrategy
    {
        private readonly ISelectInvoiceService _selectInvoiceService;

        public SelectiveInvoiceDiscountStrategy(ISelectInvoiceService selectInvoiceService)
        {
            _selectInvoiceService = selectInvoiceService;
        }

        public LoanApplicationResponse SubmitApplicationFor(ISellerApplication application)
        {
            try
            {
               var sid = application.Product as SelectiveInvoiceDiscount;
               var result  = _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(), sid.InvoiceAmount, sid.AdvancePercentage);
                
                if (result > 0)
                    return new LoanApplicationResponse { IsSuccessfull = true, ApplicationId = result };

                else
                    return new LoanApplicationResponse { IsSuccessfull = false, ApplicationId = result };

            }
            catch (Exception exp)
            {
                return new LoanApplicationResponse { IsSuccessfull = false, Exception = exp };
            }
        }
    }
}
