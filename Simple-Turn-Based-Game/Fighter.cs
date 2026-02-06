namespace Simple_Turn_Based_Game;

public class Fighter
{
    // Fields
    private static Random _random = new Random();

    // Properties
    public string Name { get; set; }
    public int MaxHealth { get; private set; } = 100;
    public int Health { get; private set; }
    public int AttackPower { get; private set; }
    public bool IsDead => Health <= 0;

    // Constructor
    public Fighter(string name)
    {
        Name = name;
        Health = MaxHealth;
    }

    // Methods
    public void TakeDamage(int damage)
    {
        Health = Math.Max(0, Health - damage);
    }

    public void Heal(out int healAmount)
    {
        healAmount = _random.Next(10, 26);
        Health = Math.Min(MaxHealth, Health + healAmount);
    }

    public int Attack(Fighter opponent)
    {
        AttackPower = _random.Next(5, 31);
        opponent.TakeDamage(AttackPower);
        return AttackPower;
    }
}
