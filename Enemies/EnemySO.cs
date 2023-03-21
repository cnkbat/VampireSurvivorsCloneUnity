using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptableObject",menuName ="ScriptableObjects/Enemy")]


public class EnemySO : ScriptableObject
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float MaxHealth;
    [SerializeField] float Damage;


    public float GetMoveSpeed() {return MoveSpeed;} public void SetMoveSpeed(float speed) {MoveSpeed = speed;}
    public float GetMaxHealth() {return MaxHealth;} public void SetMaxHealth(float maxHealth) {MaxHealth = maxHealth;}
    public float GetDamage() {return Damage;} public void SetDamage(float dmg) {Damage = dmg;}
}
