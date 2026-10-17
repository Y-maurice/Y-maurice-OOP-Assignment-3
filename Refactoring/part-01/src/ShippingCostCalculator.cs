using RefactoringLab.Part01.src.Carriers;

namespace RefactoringLab;

public class ShippingCostCalculator
{
    private readonly Dictionary<string, ICarrier> _carriers = new Dictionary<string, ICarrier>();

    public ShippingCostCalculator(IEnumerable<ICarrier> carriers)
    {
        foreach (var carrier in carriers)
        {
            _carriers[carrier.Name] = carrier;
        }
    }

    public decimal Calculate(string Carrier, decimal weightKg)
    {
        if (_carriers.TryGetValue(Carrier, out var found))
        {
            return found.CalculateCost(weightKg);
        }

        throw new ArgumentException($"Unknown carrier: {Carrier}");
    }
}
