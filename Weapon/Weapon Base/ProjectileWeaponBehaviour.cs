using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 Direction;

    protected PlayerStats Player;

    public WeaponSO WeaponSO;

    //currentStats

    protected float CurrentWeaponSOProjectileSpeed;
    protected float CurrentDamage;
    protected float CurrentCoolDownDur;
    protected int CurrentPenet;

    protected float CurrentCharSOProjectileSpeed;
    protected float CurrentWeaponKnockbackMultiplier;
    
    private void Awake() 
    {
        Player = FindObjectOfType<PlayerStats>();

        CurrentCharSOProjectileSpeed = Player.CurrentProjectileSpeed;

        CurrentWeaponSOProjectileSpeed = WeaponSO.GetProjectileSpeed();

        CurrentDamage = WeaponSO.GetDamage() + Player.CurrentPower;

        CurrentCoolDownDur = WeaponSO.GetCoolDownDuration();

        CurrentPenet = WeaponSO.GetPenet();

        CurrentWeaponKnockbackMultiplier = WeaponSO.GetWeaponKbMultiplier();

    }
    protected virtual void Start()
    {
        Destroy(gameObject,WeaponSO.GetDestroyAfterSeconds());
    }

    public virtual void DirectionChecker(Vector3 dir)
    {
        Direction = dir;
    
        float dirx= Direction.x;
        float diry= Direction.y;

        Vector3 Scale = transform.localScale;

        Vector3 Rotation = transform.rotation.eulerAngles;

        if(dirx < 0 && diry == 0)  // left
        {
            Scale.x = Scale.x * -1;

            Scale.y = Scale.y * -1;
        }
        else if(dirx < 0 && diry > 0)  //left up
        {
            Scale.x = Scale.x * -1;

            Scale.y = Scale.y * -1;

            Rotation= new Vector3 (0,0,-45f);
        }
        else if(dirx < 0 && diry < 0)  //left down
        {
            Scale.x = Scale.x * -1;

            Scale.y = Scale.y * -1;

            Rotation= new Vector3 (0,0,45f);
        }
        else if(dirx == 0 && diry > 0)  //up
        {

            Scale.y = Scale.y * -1;

            Rotation= new Vector3 (0,0,90f);
        }

        else if(dirx == 0 && diry < 0)  //down
        {

            Scale.x = Scale.x * -1;

            Rotation= new Vector3 (0,0,90f);
        }

        else if (dirx > 0 && diry > 0) // right up
        {
            Rotation= new Vector3 (0,0,45);
        } 

        else if (dirx > 0 && diry < 0) // right down
        {
            Rotation= new Vector3 (0,0,-45);
        }

        transform.localScale = Scale;

        transform.rotation = Quaternion.Euler(Rotation); // cant convert 
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

                Enemy.transform.position -= KnockbackDirection * Player.CurrentPlayerKnockbackMultiplier * CurrentWeaponKnockbackMultiplier;
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
