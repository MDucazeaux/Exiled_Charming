using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }

    public Stats Damage;
    public Stats Armor;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int Damage)
    {
        Damage -= Armor.GetValue();
        Damage = Mathf.Clamp(Damage, 0, int.MaxValue);

        CurrentHealth -= Damage;
        Debug.Log(transform.name + "take" + Damage + " damage. ");
    }
}
