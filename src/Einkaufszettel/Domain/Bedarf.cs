namespace Einkaufszettel.Domain;

public class Bedarf : BaseEntity {
    public Haushalt? Haushalt {get; init;}

    public Produkt? Produkt {get; init;}

    public int? Menge {get; init;}

    public Bedarf() : base() {}

    public Bedarf(Haushalt haushalt, Produkt produkt, int menge) : base()
    {
        Haushalt = haushalt;
        Produkt = produkt;
        Menge = menge;
    }
}