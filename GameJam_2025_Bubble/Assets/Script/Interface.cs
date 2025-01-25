public interface IDamageable{
    public void hit(PlayerController player);
}

public interface IHealable{
    public void HealPoint(PlayerController player);
}

public interface IResetable{
    public void _reset();
}