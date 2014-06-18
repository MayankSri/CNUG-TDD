
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

            var customer = _customerRepository.Get(vendorId);
            HandleNull(customer);
            return customer.TotalDue - customer.TotalPaid;
        }

        public void ApplyEarlyPaymentDiscount(int customerId, decimal discountRate) {

            var customer = _customerRepository.Get(customerId);
            HandleNull(customer);

            if (!customer.IsGoldMember)
                return;

            var balance = customer.TotalDue - discountRate * customer.TotalDue;
            _customerRepository.UpdateDiscount(customerId, discountRate, balance);
        }

    }
}
