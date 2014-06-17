
namespace CompareUtil {

    public interface IAccountService {
        void ApplyEarlyPaymentDiscount(int vendorId, decimal discountRate);
        decimal GetAccountBalance(int vendorId);
    }
}
