using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    
    protected override void Start()
    {
        base.Start();
    }

    void Update() 
    {
        transform.position += Direction * CurrentWeaponSOProjectileSpeed * Time.deltaTime;
    }

    
}
