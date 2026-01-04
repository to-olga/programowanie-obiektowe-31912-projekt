namespace PetHealthHistory.Data;

public class Snake : Pet
{
    public Snake(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Snake;
    
    public override string[] FunFacts { get; } = 
    [
        "Snakes don't have eyelids.",
        "Snakes smell with their tongues.",
        "There are over 3,000 different species of snakes.",
        "Some snakes can fly (well, glide through the air).",
        "Snakes are found on every continent except Antarctica."
    ];
}
