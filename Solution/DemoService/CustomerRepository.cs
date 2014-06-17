using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareUtil {
    public class CustomerRepository : ICustomerRepository {

        public Customer Get(int id) {
            throw new NotImplementedException();
        }

        public IList<Customer> GetAll() {
            throw new NotImplementedException();
        }

        public void Add(Customer customer) {
            throw new NotImplementedException();
        }

        public void Update(Customer customer) {
            throw new NotImplementedException();
        }

        public void UpdateDiscount(int vendorId, decimal discountRate, decimal balance) {
            throw new NotImplementedException();
        }
    }
}
