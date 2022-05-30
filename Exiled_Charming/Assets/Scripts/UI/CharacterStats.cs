using UnityEngine;
using UnityEngine.UI;
public class CharacterStats : MonoBehaviour

    //script du player, lié a la barre de vie, et fonction de dégat subit qui réduit avec l'armure + fonction qui permet de se heal
{
    public static CharacterStats Instance;

    public float MaxHealth;
    public float CurrentHealth { get; set; }

    public Stats Damage;
    public Stats Armor;

    public Text Damagetxt;
    public Text Armortxt;
    public Text Healthtxt;

    public Image HealthBarImage;
    public Text healthText;

    public int defPlayer;
    public int adPlayer;

    public int amountDef;
    public int amountAd;
    //public Text text;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
        Instance = this;
    }

    private void Start()
    {
    }
    private void Update()
    {

        CurrentHealth = this.GetComponent<HpManager>().Hp;
        MaxHealth = this.GetComponent<HpManager>().maxHp;

        defPlayer = GameObject.Find("Player").GetComponent<StatsManager>().baseDef;
        adPlayer = GameObject.Find("Player").GetComponent<StatsManager>().baseAD;


        additionAdDef();
        healthText.text = CurrentHealth + " / " + MaxHealth;
        Damagetxt.text = $"Damage : {Damage.GetValue() + adPlayer}" ;
        Armortxt.text = $"Armor : {Armor.GetValue() + defPlayer}";
        Healthtxt.text = "Hp :" + CurrentHealth + "/" + MaxHealth;


        if (CurrentHealth >= MaxHealth/2)
        {
            HealthBarImage.color = Color.green;
        }

        if (CurrentHealth <= MaxHealth/2)
        {
            HealthBarImage.color = Color.yellow;
        }

        if (CurrentHealth <= MaxHealth/4)
        {
            HealthBarImage.color = Color.red;
        }

        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }
    }
    public void TakeDamage(int Damage)
    {
        Damage -= amountDef;
        Damage = Mathf.Clamp(Damage, 0, int.MaxValue);

        CurrentHealth -= Damage;
        this.GetComponent<HpManager>().Hp -= Damage;

        HealthBarImage.fillAmount = CurrentHealth / MaxHealth;
        healthText.text = CurrentHealth + " / " + MaxHealth;
    }

    public void IncreaseHealth(int value)
    {
        if(CurrentHealth < MaxHealth)
            CurrentHealth += value;

        HealthBarImage.fillAmount = CurrentHealth / MaxHealth;
        healthText.text = CurrentHealth + " / " + MaxHealth;
    }

    public void additionAdDef()
    {
        amountAd = adPlayer + Damage.GetValue();
        amountDef = defPlayer + Armor.GetValue();
    }
}
