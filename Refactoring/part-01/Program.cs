using RefactoringLab;
using RefactoringLab.Part01.src.Carriers;
using RefactoringLab.Part01.src.OrderProccessor;
using static RefactoringLab.Notification;

var shipping = new ShippingCostCalculator(new ICarrier[]
{
    new AramexCarrier(), new DhlCarrier(), new FedExCarrier()   //providing existing carriers in the constructor
});


Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine();

var smtpEmailSender = new SmtpEmailSender();
var sqlOrderRepo = new SqlOrderRepository();

var processor = new OrderProcessor(sqlOrderRepo, smtpEmailSender); // providing concrete repo and email sender ( can be changed without Orderproccessor know)
processor.Process(1001, "customer@example.com");
Console.WriteLine();

new Notification(new EmailChannel(), urgent: true, sendAt: DateTime.Today.AddHours(18)) //just provide the INotificationChannel in the constructor
    .Send("customer@example.com", "Your order ships tomorrow");
new Notification(new SmsChannel(), urgent: true)
    .Send("+201000000000", "OTP 4821");
