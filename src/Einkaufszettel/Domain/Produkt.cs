namespace Einkaufszettel.Domain;

public class Produkt : BaseEntity {

    public string? Name {get; init; }

    public Produkt() : base() {}

    public Produkt(string name) : base()
    {
        Name = name;
    }
}