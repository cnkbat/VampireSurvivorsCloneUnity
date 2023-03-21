using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehaviour : MonoBehaviour
{
    // base of all melee weapons
    public WeaponSO WeaponSO;

    PlayerStats Player;

    //currentStats
    protected float CurrentProjectileSpeed;
    protected float CurrentDamage;
    protected float CurrentCoolDownDur;
    protected int CurrentPenet;
    
    private void Awake() 
    {
        Player = FindObjectOfType<PlayerStats>();
        
        CurrentProjectileSpeed = WeaponSO.GetProjectileSpeed();

        CurrentDamage = WeaponSO.GetDamage() + Player.CurrentPower;

        CurrentCoolDownDur = WeaponSO.GetCoolDownDuration();

        CurrentPenet = WeaponSO.GetPenet();
     

    }
    protected virtual void Start()
    {
        Destroy(gameObject,WeaponSO.GetDestroyAfterSeconds());
    }

     protected virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if(CurrentPenet > 0)
        {
            //applying currentdamage** to the enemy
            if(other.CompareTag("Enemy"))
            {
                EnemyStats Enemy = other.GetComponent<EnemyStats>();
                Enemy.TakeDamage(CurrentDamage);
                CurrentPenet--;

                Vector3 KnockbackDirection = (Player.transform.position - Enemy.transform.position).normalized;

                Enemy.transform.position -= KnockbackDirection * Player.CurrentPlayerKnockbackMultiplier;
            }
            else if(other.CompareTag("Obstacles"))
            {
                if(other.gameObject.TryGetComponent(out BreakableProps breakable))
                {
                    CurrentPenet--;
                    breakable.TakeDamage(CurrentDamage);
                }
            }
        }
        if(CurrentPenet<=0)
        {
            Destroy(gameObject);
        }

    }
}
