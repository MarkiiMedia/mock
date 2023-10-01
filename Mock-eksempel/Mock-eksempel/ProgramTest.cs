using Xunit;
using Moq;

public class ProgramTest {
    /*
    [Fact]
    public void Kunde_kan_findes_med_id() {
        //Arrange
        var dbStub = new Mock<IDatabase>();
        Customer kunde = new Customer(1, "Hans", "Vej 1");

        dbStub.Setup(db => db.GetCustomerById(1)).Returns(kunde);
        var handler = new CustomerHandler(dbStub.Object);

        //Act
        var result = handler.GetCustomerById(1);

        //Assert
        Assert.Equal(kunde, result);
    }*/
/*
    [Fact]
    public void Kundeliste_indeholder_alle_kunder() {
        //Arrange
        var dbStub = new Mock<IDatabase>();
        var kunde1 = new Customer(1, "Hans", "Vej 1");
        var kunde2 = new Customer(2, "Grethe", "Vej 2");
        var kunde3 = new Customer(3, "Jens", "Vej 3");

        dbStub.Setup(db => db.GetCustomers()).Returns(new List<Customer> { kunde1, kunde2, kunde3 });
        var handler = new CustomerHandler(dbStub.Object);

        //Act
        var result = handler.GetCustomers();

        //Assert
        Assert.Equal(3, result.Count);
        Assert.Equal(kunde1, result[0]);
        Assert.Equal(kunde2, result[1]);
        Assert.Equal(kunde3, result[2]);
    }*/

    [Fact]
    public void Mail_sendes_til_kunder_med_udestaaende_beloeb() {
        //Arrange
        var dbStub = new Mock<IDatabase>();
        var mailerMock = new Mock<IMailer>();
        var kunde1 = new Customer(1, "Hans", "Vej 1", "hans@hotmail.com");
        var kunde2 = new Customer(2, "Grethe", "Vej 2", "gre@gmail.com");
        var kunde3 = new Customer(3, "Jens", "Vej 3", "jj@yahoo.com");
        var kunder = new List<Customer> { kunde1, kunde2, kunde3 };

        mailerMock.Setup(mailer => mailer.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        var handler = new CustomerHandler(dbStub.Object, mailerMock.Object);

        //Act
        handler.MailOutstandingBalanceCustomers(kunder);

        //Assert
        mailerMock.Verify(mailer => mailer.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(3));
    }
}