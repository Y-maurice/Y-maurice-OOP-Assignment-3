namespace RefactoringLab.Part01.src.OrderProccessor;

public interface IEmailSender
{
    public void Send(string email, string body);
}
