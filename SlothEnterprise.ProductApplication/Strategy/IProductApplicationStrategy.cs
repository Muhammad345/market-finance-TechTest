﻿using SlothEnterprise.ProductApplication.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlothEnterprise.ProductApplication
{
    public interface IProductApplicationStrategy
    {
        LoanApplicationResponse SubmitApplicationFor(ISellerApplication application);
    }
}
