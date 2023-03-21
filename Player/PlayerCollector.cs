using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    PlayerStats PlayerStats;
    Pickup Pickup;
    CircleCollider2D CircleCollider2D;

    [SerializeField] float PullSpeed;

    [SerializeField] float MoveSpeed;
    private void Start()
    {
      PlayerStats = FindObjectOfType<PlayerStats>();
      CircleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update() 
    {
      CircleCollider2D.radius = PlayerStats.CurrentMagnetRadius;
    }

    
    private void OnTriggerEnter2D(Collider2D other) 
    {
      //check if the other gameobject has the ICollectible interface
      if(other.gameObject.TryGetComponent(out ICollectible collectible))
      {                      
        //pulling to the player
        Rigidbody2D Rigidbody2D = other.gameObject.GetComponent<Rigidbody2D>();
        //Vector2 Diff between player and collectible
        Vector2 ForceDirection = (transform.position - other.transform.position).normalized;
        Rigidbody2D.AddForce(ForceDirection * PullSpeed);
      }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
      if(other.gameObject.TryGetComponent(out ICollectible collectible))
      {                      
        //pulling to the player
        other.transform.position = Vector2.MoveTowards(other.transform.position, PlayerStats.transform.position, MoveSpeed * Time.deltaTime );    
      }
    }
    //IsMagneton baska bir script ve pickupla bağlayıp
    // Tüm expleri toplamasını sağlicaz.
}
