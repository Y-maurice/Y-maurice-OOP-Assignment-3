namespace RefactoringLab.Part01.src.OrderProccessor;

public class OrderProcessor
{
    private readonly IOrderRepository _repo;
    private readonly IEmailSender _email;

    public OrderProcessor(IOrderRepository repo, IEmailSender email)
    {
        _repo = repo;
        _email = email;
    }
    public void Process(int orderId, string customerEmail)
    {


        _repo.Save(orderId, DateTime.Now);
        _email.Send(customerEmail, $"Order {orderId} confirmed at {DateTime.Now}");
    }
}

public class SqlOrderRepository : IOrderRepository
{
    public void Save(int id, DateTime datetime)
    {
        Console.WriteLine($"Order: {id} confirmed at {datetime}");
    }
}

public class SmtpEmailSender : IEmailSender
{
    public void Send(string email, string body)
    {
        Console.WriteLine($"[SMTP] to={email} body={body}");
    }
}

// now they both depend on interfaces, orderproccessor class is not depending on a concrete class , instead on interfaces