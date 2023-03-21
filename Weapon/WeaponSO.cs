using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponScriptableObject",menuName ="ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon Stats")]
    [SerializeField] public GameObject WeaponPrefab;
    //public GameObject GetWeaponPrefab(){return WeaponPrefab;}

    public void SetWeaponPrefab(GameObject WP){WeaponPrefab = WP;}
    [SerializeField] float Damage; 
    public float GetDamage(){return Damage;} 
    public void SetDamage(float dmg){Damage = dmg;} 

    [SerializeField] float ProjectileSpeed; 
    public float GetProjectileSpeed(){return ProjectileSpeed;} 
    public void SetProjectileSpeed(float P_sp){ProjectileSpeed = P_sp;} 

    [SerializeField] float CoolDownDuration; 
    public float GetCoolDownDuration(){return CoolDownDuration;} 
    public void SetCoolDownDuration(float CDD){CoolDownDuration = CDD;} 

    [SerializeField] int Penetration; 
    public int GetPenet(){return Penetration;} 
    public void SetDamage(int Pnt){Penetration = Pnt;} 

    [SerializeField] float DestroyAfterSeconds;

    public float GetDestroyAfterSeconds() {return DestroyAfterSeconds;}
    public void SetDestroyAfterSeconds(float DAS) {DestroyAfterSeconds = DAS;}
    
    [SerializeField] float WeaponKbMultiplier;
    public float GetWeaponKbMultiplier() {return WeaponKbMultiplier;}
    public void SetWeaponKbMultiplier(float WKBM) {WeaponKbMultiplier = WKBM;}
}
