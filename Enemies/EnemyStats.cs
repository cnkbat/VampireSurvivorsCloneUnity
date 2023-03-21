using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{   
    DropRateManager DropRateManager;
    PlayerStats Player;
    [SerializeField] EnemySO EnemySO;

    [HideInInspector]
    public float CurrentHealth;
    [HideInInspector]
    public float CurrentMoveSpeed;
    [HideInInspector]
    public float CurrentDamage;
    public float DespawnDistance = 50;

    Transform PlayerTransform;
    
    void Awake() 
    {
        DropRateManager = GetComponent<DropRateManager>();

        CurrentHealth = EnemySO.GetMaxHealth();

        CurrentMoveSpeed = EnemySO.GetMoveSpeed();

        CurrentDamage = EnemySO.GetDamage();

        Player = FindObjectOfType<PlayerStats>();
    }

    private void Start() 
    {
        PlayerTransform = FindObjectOfType<PlayerStats>().transform;
    }
    private void Update() 
    {
        if(Vector2.Distance(transform.position,PlayerTransform.position) >= DespawnDistance)
        {
            ReturnEnemy();
        }    
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;

        if(CurrentHealth <= 0 )
        {
            Kill();
        } 
    }

    private void Kill()
    {
        DropRateManager.DropOnDeath();
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //dealing damage to the player when overlapped
        if(other.gameObject.CompareTag("Player"))
        {
            Player.TakeDamage(CurrentDamage);

            Debug.Log("Damage hit");
            //make sure deal the currentdamage instead of 
            //EnemySO.Damage incase of changing the currentdamage with something like curse
        }

    }
    private void OnDestroy() 
    {
        EnemySpawner EnemySpawner = FindObjectOfType<EnemySpawner>();
        EnemySpawner.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner Es = FindObjectOfType<EnemySpawner>();
        transform.position = PlayerTransform.position + 
        Es.RelativeSpawnPoints[UnityEngine.Random.Range(0,Es.RelativeSpawnPoints.Count)].position;
    }
}
