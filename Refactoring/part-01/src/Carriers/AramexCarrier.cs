namespace RefactoringLab.Part01.src.Carriers;

public class AramexCarrier : ICarrier
{
    public string Name => "Aramex";

    public decimal CalculateCost(decimal weightKg)
        => weightKg * 12m;
}
