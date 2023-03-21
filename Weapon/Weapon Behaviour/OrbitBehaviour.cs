using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBehaviour : ProjectileWeaponBehaviour
{
    OrbitController OrbitController;
    [SerializeField] Vector3 OrbitDirection;
    protected override void Start()
    {
        base.Start();

        transform.SetParent(Player.transform);
        
        OrbitController = FindObjectOfType<OrbitController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position , OrbitDirection , 
        CurrentWeaponSOProjectileSpeed * base.CurrentCharSOProjectileSpeed *  Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
