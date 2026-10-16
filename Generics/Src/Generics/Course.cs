namespace Generics;

public class Course : IHasId
{
    public int Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }
}
