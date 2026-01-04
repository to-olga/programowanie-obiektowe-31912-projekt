namespace PetHealthHistory.Data;

public class GuineaPig : Pet
{
    public GuineaPig(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.GuineaPig;
    
    public override string[] FunFacts { get; } = 
    [
        "Guinea pigs are not from Guinea and they are not pigs.",
        "They sleep for only short periods at a time.",
        "A baby guinea pig can run when it is just a few hours old.",
        "They make a 'wheek-wheek' sound when they are excited.",
        "They need to eat Vitamin C every day."
    ];
}
