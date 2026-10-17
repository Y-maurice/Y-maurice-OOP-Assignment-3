namespace RefactoringLab.Part01.src.Carriers;

public class FedExCarrier : ICarrier
{
    public string Name => "FedEx";

    public decimal CalculateCost(decimal weightKg)
        => weightKg * 15m;
}
