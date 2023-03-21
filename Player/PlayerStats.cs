using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    CharacterSO CharacterSO;

    PlayerMovement PlayerMovement;

    ParticleSystem BloodEffect; 

    //Current Stats
    
    public float CurrentHealth;
    [HideInInspector]
    public float CurrentMoveSpeed;
    [HideInInspector]
    public float CurrentRecovery;
    [HideInInspector]
    public float CurrentPower;
    [HideInInspector]
    public float CurrentProjectileSpeed;
    [HideInInspector]
    public float CurrentMagnetRadius;

    [HideInInspector]
    public float CurrentPlayerKnockbackMultiplier;
    Sprite CurrentSprite;

    BoxCollider2D BoxCollider2D;
    //Spawning Weapons On Char
    [Header("Weapons")]
    [SerializeField] List <GameObject> SpawnableWeapons;
    public List<GameObject> SpawnedWeapons;


    //Exp and level of player
    [Header("Experience/Level")]

    public int Experience = 0;
    public int Level = 1;

    public int ExperienceCap;
    
    // class for defining a level range and the corresponding exp cap increase for that range
    [System.Serializable]
    public class LevelRange
    {
        public int StartLevel;
        public int EndLevel;
        public int ExperienceCapIncrease;
    }
    //I -Frames
    [Header("I-Frames")]
    public float UntouchableDuration;
    float UntouchableTimer;
    bool bIsUntouchable;
    public List <LevelRange> LevelRanges;
    // buradan seçilerek ekleme yapılır
    void Awake() 
    {

        CharacterSO = CharacterSelector.GetCharacterSO();

        CharacterSelector.Instance.DestroySingleton();

        //Assign the variables 

        CurrentHealth = CharacterSO.GetMaxHealth();

        CurrentMoveSpeed = CharacterSO.GetMoveSpeed();

        CurrentRecovery = CharacterSO.GetRecovery();

        CurrentPower = CharacterSO.GetPower();

        CurrentProjectileSpeed = CharacterSO.GetProjectileSpeed();
        
        CurrentMagnetRadius = CharacterSO.GetMagnetRadius();

        CurrentPlayerKnockbackMultiplier = CharacterSO.GetKnockbackVector();

        //spawn the starting weapon
        SpawnWeapon(CharacterSO.GetStartingWeapon());

        BloodEffect = GetComponentInChildren<ParticleSystem>();

        BoxCollider2D = GetComponent<BoxCollider2D>();

    }
    void Start() 
    {
        //ilk seviyenin capi yükselişle aynı olsun diye
        ExperienceCap = LevelRanges[0].ExperienceCapIncrease;

        PlayerMovement = GetComponent<PlayerMovement>();
       
    }

    void Update() 
    {
        if(UntouchableTimer > 0)
        {
            UntouchableTimer -= Time.deltaTime;
        }
        else if (bIsUntouchable)
        {
            bIsUntouchable = false;
        }

        Recover();
    }

    public void IncreaseExperince(int amount)
    {
        Experience += amount;

        LevelUpChecker();

        Debug.Log(Experience);
    }

    void LevelUpChecker()
    {
        if(Experience >= ExperienceCap)
        {
            Level++;
            Experience -= ExperienceCap;

            int randnumber = Random.Range(0,SpawnableWeapons.Count);
            SpawnWeapon(SpawnableWeapons[randnumber]);

            int ExperienceCapIncrease= 0;
            Debug.Log("Leveled up");
            foreach(LevelRange range in LevelRanges)
            {
                if(Level >=range.StartLevel && Level <= range.EndLevel)
                {
                    ExperienceCapIncrease = range.ExperienceCapIncrease;
                    break;
                    
                }
            }
            ExperienceCap +=ExperienceCapIncrease;
        }
    }
    
    public void TakeDamage(float dmg)
    {  
        if(!bIsUntouchable)
        {
            CurrentHealth -= dmg;

            UntouchableTimer = UntouchableDuration;
            bIsUntouchable = true; 
            if(CurrentHealth <= 0)
            {
                Kill();
            }
        }     
    }

    public void Kill()
    {
        Debug.Log("Player dead.");
    }

    public void Heal(float healamount)
    {   
        // to only heal when currenthealth is below maxhealth
        if(CurrentHealth < CharacterSO.GetMaxHealth())
        {
            CurrentHealth += healamount;

            // setting current to max health in case of overheal
            if(CurrentHealth > CharacterSO.GetMaxHealth())
            {
                CurrentHealth = CharacterSO.GetMaxHealth();
            }
        }
        
    }

    void Recover()
    {
        //to recover
        if(CurrentHealth < CharacterSO.GetMaxHealth())
        {
            CurrentHealth += CurrentRecovery * Time.deltaTime;
            
            //to make sure not to do overrecovery
            if(CurrentHealth > CharacterSO.GetMaxHealth())
            {
                CurrentHealth = CharacterSO.GetMaxHealth();
            }
        }
        
    }

    public void SpawnWeapon(GameObject weapon)
    {
        //Starting weapon
        GameObject SpawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        SpawnedWeapon.transform.SetParent(transform); //same method how attaching weapon to the player
        SpawnedWeapons.Add(SpawnedWeapon); // add it to the list
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
      if(other.CompareTag("Enemy"))
       {
            BloodEffect.Play();
       }  
    }

    void OnTriggerExit2D(Collider2D other) 
    {
       if(other.CompareTag("Enemy"))
       {
            BloodEffect.Stop();
       }
    }

    public ParticleSystem GetBloodEffect()
    {                                               
        return BloodEffect;                                     
    }
   
}
