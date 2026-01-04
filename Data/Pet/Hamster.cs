namespace PetHealthHistory.Data;

public class Hamster : Pet
{
    public Hamster(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Hamster;
    
    public override string[] FunFacts { get; } = 
    [
        "Hamsters are crepuscular, meaning they are most active during twilight.",
        "A hamster's teeth never stop growing.",
        "Hamsters can store up to half their body weight in food in their cheeks.",
        "The name 'hamster' comes from the German word 'hamstern', which means 'to hoard'.",
        "There are about 20 different species of hamsters."
    ];
}
