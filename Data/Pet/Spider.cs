namespace PetHealthHistory.Data;

public class Spider : Pet
{
    public Spider(string name, DateOnly birthDate, string? kind) : base(name, birthDate, kind)
    {
    }

    public override PetType PetType { get; protected set; } = PetType.Spider;
    
    public override string[] FunFacts { get; } = 
    [
        "Spiders are found on every continent except Antarctica.",
        "Most spiders have eight eyes, but some have none.",
        "Spider silk is stronger than steel of the same thickness.",
        "Not all spiders spin webs; some hunt their prey.",
        "Spiders are arachnids, not insects."
    ];
}
