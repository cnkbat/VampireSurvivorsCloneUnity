using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "CharacterSO", menuName = "ScriptableObjects/CharacterSO", order = 0)]
public class CharacterSO : ScriptableObject 
{
    [SerializeField] GameObject CharacterPrefab;

    public GameObject GetCharacterPrefab() {return CharacterPrefab;} 
    public void SetCharacterPrefab(GameObject Cprefab) {CharacterPrefab = Cprefab;}

    [SerializeField] Sprite Sprite;

    public Sprite GetSprite() {return Sprite;} 
    public void SetSprite(Sprite sprite) {Sprite = sprite;}
    [SerializeField] GameObject StartingWeapon;
    
    public GameObject GetStartingWeapon() {return StartingWeapon;} 
    public void SetStartingWeapon(GameObject weapon) {StartingWeapon = weapon;}

    [SerializeField] float MaxHealth;

    public float GetMaxHealth() {return MaxHealth;} 
    public void SetMaxHealth(float maxhealth) {MaxHealth = maxhealth;}

    [SerializeField] float MoveSpeed;

    public float GetMoveSpeed() {return MoveSpeed;} 
    public void SetMoveSpeed(float speed) {MoveSpeed = speed;}

    [SerializeField] float Recovery;

    public float GetRecovery() {return Recovery;} 
    public void SetRecovery(float recovery) {Recovery = recovery;}

    [SerializeField] float Power;

    public float GetPower() {return Power;} 
    public void SetPower(float power) {Power = power;}

    [SerializeField] float ProjectileSpeed;

    public float GetProjectileSpeed() {return ProjectileSpeed;} 
    public void SetProjectileSpeed(float PS) {ProjectileSpeed = PS;}

    [SerializeField] float MagnetRadius;

    public float GetMagnetRadius() {return MagnetRadius;} 
    public void SetMagnetRadius(float MR) {MagnetRadius = MR;}

    [SerializeField] float KnockbackMultiplier;

    public float GetKnockbackVector() {return KnockbackMultiplier;}
    public void SetKnockbackVector(float KBM) {KnockbackMultiplier = KBM;}

}

