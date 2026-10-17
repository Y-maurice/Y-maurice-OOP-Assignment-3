namespace RefactoringLab.Part01.src.Carriers;

public class DhlCarrier : ICarrier
{
    public string Name => "DHL";

    public decimal CalculateCost(decimal weightKg)
        => weightKg * 18m;
}
