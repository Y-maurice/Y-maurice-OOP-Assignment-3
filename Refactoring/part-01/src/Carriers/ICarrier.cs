namespace RefactoringLab.Part01.src.Carriers;

public interface ICarrier
{
    string Name { get; }

    decimal CalculateCost(decimal weightKg);
}

// so whenever a new carrier needs to be added , only implement ICarrier and add it to carriers in shipping cost constructor in program.cs