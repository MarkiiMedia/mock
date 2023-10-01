public class CustomerHandler {
    private IDatabase CustomerData;
    private IMailer Mailer;
    public CustomerHandler(IDatabase database, IMailer mailer) {
        // In real scenario, this would be injected.
        CustomerData = database;
        Mailer = mailer;
    }

    public List<Customer> GetCustomers() {
        return CustomerData.GetCustomers().ToList();
    }

    public Customer GetCustomerById(int id) {
        return CustomerData.GetCustomerById(id);
    }

    public void MailOutstandingBalanceCustomers(List<Customer> customers) {
        foreach (var customer in customers) {
            Mailer.SendMail(customer.Name, customer.Email, "It looks like you have an outstanding balance. Please pay it as soon as possible.");
        }
    }
}