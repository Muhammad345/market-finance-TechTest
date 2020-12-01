using FluentAssertions;
using Moq;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Applications;
using SlothEnterprise.ProductApplication.Products;
using System;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private readonly ProductApplicationService _sut;
        private readonly Mock<ISelectInvoiceService> _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
        private readonly Mock<IConfidentialInvoiceService> _confidentialInvoiceServiceMock = new Mock<IConfidentialInvoiceService>();
        private readonly Mock<IBusinessLoansService> _businessLoansServiceMock = new Mock<IBusinessLoansService>();
        private readonly Mock<IApplicationResult> _result = new Mock<IApplicationResult>();
        private SelectiveInvoiceDiscount _selectiveInvoiceDiscount;
        private ConfidentialInvoiceDiscount _confidentialInvoiceDiscount;
        private BusinessLoans _businessLoans;
        private SellerCompanyData _sellerCompanyData;
        private string _companyNumber;
        private int _applicationId;
        private decimal _invoiceAmount;
        private decimal _advancePercentage;
        private decimal _vatRate;
        private decimal _totalLedgerNetworth;
        private decimal _interestRatePerAnnum;
        private decimal _loanAmount;

        public ProductApplicationTests()
        {
            _sut = new ProductApplicationService(_selectInvoiceServiceMock.Object, _confidentialInvoiceServiceMock.Object, _businessLoansServiceMock.Object);

            _applicationId = 1;
            _companyNumber = "12345678";
            _result.SetupProperty(p => p.ApplicationId, _applicationId);
            _result.SetupProperty(p => p.Success, true);
            _invoiceAmount = 200;
            _advancePercentage = 10;
            _vatRate = 20;
            _totalLedgerNetworth = 55454545;
            _interestRatePerAnnum = 10;
            _loanAmount = 34343443;

            _selectiveInvoiceDiscount = new SelectiveInvoiceDiscount { 
                  InvoiceAmount = _invoiceAmount,
                  AdvancePercentage = _advancePercentage
            };

            _confidentialInvoiceDiscount = new ConfidentialInvoiceDiscount
            {
                TotalLedgerNetworth = _totalLedgerNetworth,
                AdvancePercentage = _advancePercentage,
                VatRate = _vatRate
            };

            _businessLoans = new BusinessLoans
            { 
               InterestRatePerAnnum = _interestRatePerAnnum,
               LoanAmount = _loanAmount
            };

            _sellerCompanyData = new SellerCompanyData
            {
                Number = int.Parse(_companyNumber),
                DirectorName = "Irfan",
                Founded = DateTime.UtcNow.AddYears(-20),
                Name = "MarketFinance Tech Test"
            };
        }

        [Fact]
        public void ProductApplicationService_SubmitApplicationFor_WhenCalledWithSelectiveInvoiceDiscount_ShouldReturnOneAndSuccessfull()
        {
            //Arrange 
            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, _selectiveInvoiceDiscount);
            sellerApplicationMock.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _selectInvoiceServiceMock.Setup(m => m.SubmitApplicationFor(_companyNumber, _invoiceAmount, 10)).Returns(_applicationId);

            //Act 
            var result = _sut.SubmitApplicationFor(sellerApplicationMock.Object);

            //Assert
            result.Should().BeOfType(typeof(LoanApplicationResponse));
            result.IsSuccessfull.Should().BeTrue();
            result.ApplicationId.Should().Be(1);
            _selectInvoiceServiceMock.Verify(x => x.SubmitApplicationFor(_companyNumber, _invoiceAmount, _advancePercentage), Times.Once());
        }

        [Fact]
        public void ProductApplicationService_SubmitApplicationFor_WhenCalledWithConfidentialInvoiceDiscount_ShouldReturnOneAndSuccessfull()
        {
            //Arrange 
            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, _confidentialInvoiceDiscount);
            sellerApplicationMock.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _confidentialInvoiceServiceMock.Setup(m => m.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), _totalLedgerNetworth, _advancePercentage, _vatRate)).Returns(_result.Object);

            //Act 
            var result = _sut.SubmitApplicationFor(sellerApplicationMock.Object);

            //Assert
            result.Should().BeOfType(typeof(LoanApplicationResponse));
            result.IsSuccessfull.Should().BeTrue();
            result.ApplicationId.Should().Be(1);
            _confidentialInvoiceServiceMock.Verify(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), _totalLedgerNetworth, _advancePercentage, _vatRate), Times.Once());
        }

        [Fact]
        public void ProductApplicationService_SubmitApplicationFor_WhenCalledWithBusinessLoans_ShouldReturnOneAndSuccessfull()
        {
            //Arrange 
            var sellerApplicationMock = new Mock<ISellerApplication>();
            sellerApplicationMock.SetupProperty(p => p.Product, _businessLoans);
            sellerApplicationMock.SetupProperty(p => p.CompanyData, _sellerCompanyData);
            _businessLoansServiceMock.Setup(m => m.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>())).Returns(_result.Object);

            //Act 
            var result = _sut.SubmitApplicationFor(sellerApplicationMock.Object);

            //Assert
            result.Should().BeOfType(typeof(LoanApplicationResponse));
            result.IsSuccessfull.Should().BeTrue();
            result.ApplicationId.Should().Be(1);
            _businessLoansServiceMock.Verify(x => x.SubmitApplicationFor(It.IsAny<CompanyDataRequest>(), It.IsAny<LoansRequest>()), Times.Once());
        }

    }
}
