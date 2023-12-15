namespace Einkaufszettel.Domain;

public class Haushalt : BaseEntity {
    public string? Name {get; init;}

    public Haushalt() : base() {}

    public Haushalt(string name) : base()
    {
        Name = name;
    }
}