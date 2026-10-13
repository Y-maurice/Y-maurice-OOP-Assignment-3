namespace RefactoringLab.Part01.src;

public interface INotificationChannel
{
    void Send(string to, string message, DateTime? sendAt);
}
