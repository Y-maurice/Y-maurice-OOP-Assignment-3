using RefactoringLab.Part01.src.Notifications;

public class SmsChannel : INotificationChannel
{
    public void Send(string to, string message, DateTime? sendAt)
    {
        string tag = sendAt.HasValue ? $"sms scheduled {sendAt:g}" : "sms";
        Console.WriteLine($"[{tag}] {to}: {message}");
    }
}