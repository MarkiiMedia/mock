public interface IDatabase {
    List<Customer> GetCustomers();
    Customer GetCustomerById(int id);
}