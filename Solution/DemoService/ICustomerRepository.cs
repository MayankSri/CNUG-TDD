using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareUtil {
    public interface ICustomerRepository {

        Customer Get(int id);
        IList<Customer> GetAll();
        void Add(Customer customer);
        void Update(Customer customer);
        void UpdateDiscount(int vendorId, decimal discountRate, decimal balance);
    }
}
