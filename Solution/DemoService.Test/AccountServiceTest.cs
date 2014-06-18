using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompareUtil.Test {

    [TestClass]
    public class AccountServiceTest {

        IAccountService _accountService;
        Mock<ICustomerRepository> _mockCustomerRepository;

        [TestInitialize]
        public void Initialize() {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _accountService = new AccountService(_mockCustomerRepository.Object);
        }

        [TestMethod]
        public void GetAccountBalance_ReturnsBalanceSuccessfully() {

            _mockCustomerRepository.Setup(vr => vr.Get(It.IsAny<int>()))
                                .Returns(new Customer {
                                    DiscountRate = 0,
                                    IsGoldMember = true,
                                    TotalDue = 100m,
                                    TotalPaid = 0m
                                });
            
            var balance = _accountService.GetAccountBalance(123);

            Assert.AreEqual(100m, balance);
        }


        [TestMethod]
        public void GetAccountBalance_AppliesDiscountSuccessfullyToPreferredVendor() {

            _mockCustomerRepository.Setup(vr => vr.Get(It.IsInRange<int>(0, int.MaxValue, Range.Exclusive)))
                                .Returns(new Customer {
                                    Id = 123,
                                    IsGoldMember = true,
                                    TotalDue = 100m,
                                    TotalPaid = 0m,
                                    DiscountRate = 0
                                });
            _mockCustomerRepository.Setup(vr => vr.UpdateDiscount(123, 0.04m, 96m)).Verifiable();

            _accountService.ApplyEarlyPaymentDiscount(123, 0.04m);

            _mockCustomerRepository.Verify();
        }
    }
}
