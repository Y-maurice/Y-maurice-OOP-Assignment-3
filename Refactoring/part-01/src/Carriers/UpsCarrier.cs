using RefactoringLab.Part01.src.Carriers;

namespace RefactoringLab;

public class UpsCarrier : ICarrier
{
    public string Name => "UPS";
    public decimal CalculateCost(decimal weightKg) => weightKg * 20m;
}