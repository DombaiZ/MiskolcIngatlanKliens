using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MiskolciIngatlanKliens.Models;

public partial class Ugyintezo
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Email { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<Ingatlan> Ingatlans { get; set; } = new List<Ingatlan>();
}
