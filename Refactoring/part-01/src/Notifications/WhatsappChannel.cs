using RefactoringLab.Part01.src.Notifications;

public class WhatsAppChannel : INotificationChannel
{
    public void Send(string to, string message, DateTime? sendAt)
    {
        string tag = sendAt.HasValue ? $"whatsapp scheduled {sendAt:g}" : "whatsapp";
        Console.WriteLine($"[{tag}] {to}: {message}");
    }
}