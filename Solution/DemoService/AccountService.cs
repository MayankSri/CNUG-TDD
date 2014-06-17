
using System;
namespace CompareUtil {
    public class AccountService : IAccountService {

        private readonly ICustomerRepository _customerRepository;

        public AccountService(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        private void HandleNull(Customer customer) {
            if (customer == null)
                throw new ArgumentNullException("customer");
        }

        public decimal GetAccountBalance(int vendorId) {

            var vendor = _customerRepository.Get(vendorId);
            HandleNull(vendor);
            return vendor.TotalDue - vendor.TotalPaid;
        }

        public void ApplyEarlyPaymentDiscount(int vendorId, decimal discountRate) {

            var vendor = _customerRepository.Get(vendorId);
            HandleNull(vendor);

            if (!vendor.IsPreferredVendor)
                return;

            var balance = vendor.TotalDue - discountRate * vendor.TotalDue;
            _customerRepository.UpdateDiscount(vendorId, discountRate, balance);
        }

    }
}
