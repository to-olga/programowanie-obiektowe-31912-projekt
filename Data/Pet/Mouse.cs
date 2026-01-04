namespace PetHealthHistory.Data;

public class Mouse : Pet
{
    public Mouse(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Mouse;
    
    public override string[] FunFacts { get; } = 
    [
        "Mice are very clean animals and groom themselves often.",
        "A mouse's tail can grow as long as its body.",
        "Mice can communicate with each other using ultrasound.",
        "They have very good hearing and a strong sense of smell.",
        "In the wild, mice are nocturnal."
    ];
}
