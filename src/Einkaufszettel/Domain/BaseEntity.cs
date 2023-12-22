using System;
using CSharp.Ulid;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Einkaufszettel.Domain;

public abstract class BaseEntity {

    [NotMapped]
    public Ulid Ulid { get; private set; }

    public string Id {
        get => Ulid.ToString();
        set => Ulid = new Ulid(Encoding.ASCII.GetBytes(value));
    }

    public BaseEntity()
    {
        Ulid = Ulid.NewUlid();
    }
}