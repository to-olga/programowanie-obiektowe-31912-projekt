namespace PetHealthHistory.Data;

public class Horse : Pet
{
    public Horse(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Horse;
    
    public override string[] FunFacts { get; } = 
    [
        "Horses can sleep both lying down and standing up.",
        "A horse's eyes are the largest of any land mammal.",
        "Horses can't breathe through their mouths.",
        "A young male horse is called a colt, and a young female is a filly.",
        "Horses have 205 bones in their skeleton."
    ];
}
