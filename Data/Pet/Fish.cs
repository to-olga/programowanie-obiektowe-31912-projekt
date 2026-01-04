namespace PetHealthHistory.Data;

public class Fish : Pet
{
    public Fish(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Fish;
    
    public override string[] FunFacts { get; } = 
    [
        "Goldfish can remember things for at least five months.",
        "Some fish can swim backwards.",
        "Fish don't have eyelids.",
        "Starfish are not actually fish.",
        "Sharks are the only fish that have eyelids."
    ];
}
