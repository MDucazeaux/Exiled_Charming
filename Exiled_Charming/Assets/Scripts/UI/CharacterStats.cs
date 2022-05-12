using UnityEngine;
using UnityEngine.UI;
public class CharacterStats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }

    public Stats Damage;
    public Stats Armor;

    public Text Damagetxt;
    public Text Armortxt;
    public Text Currenthealth;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10000000);
        }

      Damagetxt.text = $"Damage : {Damage.GetValue()}";
      Armortxt.text = $"Armor : {Armor.GetValue()}";
      Currenthealth.text = $"Health : {CurrentHealth}";
    }
    public void TakeDamage(int Damage)
    {
        Damage -= Armor.GetValue();
        Damage = Mathf.Clamp(Damage, 0, int.MaxValue);

        CurrentHealth -= Damage;
        Debug.Log(transform.name + "take" + Damage + " damage. ");
    }
}
