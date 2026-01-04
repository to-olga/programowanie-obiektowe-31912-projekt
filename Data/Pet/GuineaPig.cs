namespace PetHealthHistory.Data;

public class GuineaPig : Pet
{
    public GuineaPig(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.GuineaPig;
}
