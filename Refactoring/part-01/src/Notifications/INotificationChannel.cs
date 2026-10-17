namespace RefactoringLab.Part01.src.Notifications;

public interface INotificationChannel
{
    void Send(string to, string message, DateTime? sendAt);
}
