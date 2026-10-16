namespace RefactoringLab.Part02.Enrollment;

public class EnrollmentFacade
{
    private readonly PaymentGateway _paymentGateway = new PaymentGateway();
    private readonly SeatInventory _seatInventory = new SeatInventory();
    private readonly InvoiceGenerator _invoiceGenerator = new InvoiceGenerator();
    private readonly EmailService _emailService = new EmailService();

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        _paymentGateway.Charge(studentId, amount);
        _seatInventory.Reserve(courseId, studentId);
        var invoiceId = _invoiceGenerator.Create(studentId, amount);
        _emailService.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}