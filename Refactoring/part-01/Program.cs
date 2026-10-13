using RefactoringLab;
using RefactoringLab.Part01.src.Carriers;
using RefactoringLab.Part01.src.Notifications;
using RefactoringLab.Part01.src.OrderProccessor;

var shipping = new ShippingCostCalculator(new ICarrier[]
{
    new AramexCarrier(), new DhlCarrier(), new FedExCarrier(), new UpsCarrier()   //providing existing carriers in the constructor
});

Console.WriteLine($"UPS 2kg → {shipping.Calculate("UPS", 2)}"); // new carrier
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
new Notification(new WhatsAppChannel(), urgent: true, sendAt: DateTime.Today.AddHours(18)) // new notification channel (whatsapp)
    .Send("+201000000000", "Your order ships tomorrow");
