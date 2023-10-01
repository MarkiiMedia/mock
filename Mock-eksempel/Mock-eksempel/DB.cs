using System.Collections.Generic;

public class DB : IDatabase {

    public List<Customer> GetCustomers() {
        
        return new List<Customer>(); //FIXME: Returner kundeliste fra DB
    }

    public Customer GetCustomerById(int id) {

        return new Customer(-1, "", "", ""); //FIXME: Returner kunde fra DB
    }
}