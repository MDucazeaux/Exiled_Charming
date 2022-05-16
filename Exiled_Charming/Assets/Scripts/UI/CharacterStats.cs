using UnityEngine;
using UnityEngine.UI;
public class CharacterStats : MonoBehaviour
{
    public static CharacterStats Instance;

    public float MaxHealth = 100;
    public float CurrentHealth { get; set; }

    public Stats Damage;
    public Stats Armor;

    public Text Damagetxt;
    public Text Armortxt;
    public Text Healthtxt;

    public Image HealthBarImage;
    public Text healthText;
    //public Text text;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }

        Damagetxt.text = $"Damage : {Damage.GetValue()}";
        Armortxt.text = $"Armor : {Armor.GetValue()}";
        Healthtxt.text = $"HP : {CurrentHealth.ToString()}";

        if (CurrentHealth >= 70)
        {
            HealthBarImage.color = Color.green;
        }

        if (CurrentHealth <= 70)
        {
            HealthBarImage.color = Color.yellow;
        }

        if (CurrentHealth <= 30)
        {
            HealthBarImage.color = Color.red;
        }

        if (CurrentHealth >= 100)
        {
            CurrentHealth = 100;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }
    }
    public void TakeDamage(int Damage)
    {
        Damage -= Armor.GetValue();
        Damage = Mathf.Clamp(Damage, 0, int.MaxValue);

        CurrentHealth -= Damage;
        Debug.Log(transform.name + "take" + Damage + " damage. ");


        HealthBarImage.fillAmount = CurrentHealth / MaxHealth;
        healthText.text = CurrentHealth + " / " + MaxHealth;
    }

    public void IncreaseHealth(int value)
    {
        CurrentHealth += value;
        Healthtxt.text = $"HP : {CurrentHealth.ToString()}";
        HealthBarImage.fillAmount = CurrentHealth / MaxHealth;
        healthText.text = CurrentHealth + " / " + MaxHealth;
    }
}
