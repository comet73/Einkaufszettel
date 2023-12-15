using CSharp.Ulid;

namespace Einkaufszettel.Domain;

public abstract class BaseEntity {
    public Ulid Id { get; init; }

    public BaseEntity()
    {
        Id = Ulid.NewUlid();
    }
}