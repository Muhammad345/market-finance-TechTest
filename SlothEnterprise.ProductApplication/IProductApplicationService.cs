using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;

namespace SlothEnterprise.ProductApplication
{
    public interface IProductApplicationService
    {
        LoanApplicationResponse SubmitApplicationFor(ISellerApplication application);
    }
}