using RefactoringLab.Part01.src.Notifications;

public class EmailChannel : INotificationChannel
{
    public void Send(string to, string message, DateTime? sendAt)
    {
        string tag = sendAt.HasValue ? $"email scheduled {sendAt:g}" : "email";
        Console.WriteLine($"[{tag}] {to}: {message}");
    }
}