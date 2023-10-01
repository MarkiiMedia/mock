public class Customer {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public string Email { get; set; }

    public Customer(int id, string name, string address, string email) {
        Id = id;
        Name = name;
        Address = address;
        Email = email;
    }
}