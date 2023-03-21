using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public WeaponSO WeaponSO;

    float CurrentCoolDown;

    protected float CurrentCharacterProjectileSpeed;
    protected PlayerMovement PlayerMovement;

    protected PlayerStats Player;
    protected virtual void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        Player = FindObjectOfType<PlayerStats>();
        CurrentCoolDown = WeaponSO.GetCoolDownDuration(); // start with cooldown

        CurrentCharacterProjectileSpeed = Player.CurrentProjectileSpeed;
    }

    protected virtual void Update()
    {
        CurrentCoolDown -= Time.deltaTime;
        if(CurrentCoolDown <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        CurrentCoolDown = WeaponSO.GetCoolDownDuration();
    }


}
