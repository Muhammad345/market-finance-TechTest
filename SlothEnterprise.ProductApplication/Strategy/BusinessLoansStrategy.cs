using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication.Strategy
{
    public class BusinessLoansStrategy : IProductApplicationStrategy
    {
        private readonly IBusinessLoansService _businessLoansService;

        public BusinessLoansStrategy(IBusinessLoansService businessLoansService)
        {
            _businessLoansService = businessLoansService;
        }

        public LoanApplicationResponse SubmitApplicationFor(ISellerApplication application)
        {
            try
            {
                var loans = application.Product as BusinessLoans;

                var result = _businessLoansService.SubmitApplicationFor(new CompanyDataRequest
                {
                    CompanyFounded = application.CompanyData.Founded,
                    CompanyNumber = application.CompanyData.Number,
                    CompanyName = application.CompanyData.Name,
                    DirectorName = application.CompanyData.DirectorName
                }, new LoansRequest
                {
                    InterestRatePerAnnum = loans.InterestRatePerAnnum,
                    LoanAmount = loans.LoanAmount
                });

                return new LoanApplicationResponse { IsSuccessfull = result.Success, ApplicationId = result.ApplicationId };

            }
            catch (Exception exp)
            {
                return new LoanApplicationResponse { IsSuccessfull = false, Exception = exp };
            }
        }
    }
}
