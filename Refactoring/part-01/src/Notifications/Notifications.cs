namespace RefactoringLab.Part01.src.Notifications;

public class Notification
{
    private readonly INotificationChannel _channel;  //composition
    private readonly bool _urgent;
    private readonly DateTime? _sendAt;

    public Notification(INotificationChannel channel, bool urgent = false, DateTime? sendAt = null)
    {
        _channel = channel;
        _urgent = urgent;
        _sendAt = sendAt;
    }

    public void Send(string to, string message)
    {
        if (_urgent) message = $"[URGENT] {message}";
        _channel.Send(to, message, _sendAt);
    }


    public class EmailChannel : INotificationChannel
    {
        public void Send(string to, string message, DateTime? sendAt)
        {
            string tag = sendAt.HasValue ? $"email scheduled {sendAt:g}" : "email";
            Console.WriteLine($"[{tag}] {to}: {message}");
        }
    }



    public class SmsChannel : INotificationChannel
    {
        public void Send(string to, string message, DateTime? sendAt)
        {
            string tag = sendAt.HasValue ? $"sms scheduled {sendAt:g}" : "sms";
            Console.WriteLine($"[{tag}] {to}: {message}");
        }
    }




    public class WhatsAppChannel : INotificationChannel
    {
        public void Send(string to, string message, DateTime? sendAt)
        {
            string tag = sendAt.HasValue ? $"whatsapp scheduled {sendAt:g}" : "whatsapp";
            Console.WriteLine($"[{tag}] {to}: {message}");
        }
    }

}

// now if any new notification channel , it will only implement INotificationChannel