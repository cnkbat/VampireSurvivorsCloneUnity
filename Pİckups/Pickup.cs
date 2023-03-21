using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    PlayerStats Player;
    ExpMagnet ExpMagnet;
    private void Start() 
    {
        Player = FindObjectOfType<PlayerStats>();
    }
    
    private void Update() 
    {      
        ExpMagnet = FindObjectOfType<ExpMagnet>();
        

        if(!ExpMagnet)
        {
            return;
        }

        if(ExpMagnet.IsMagnetOn)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            Player.transform.position,
            10f * Time.deltaTime); 
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {   
            //collect the related collection and destroy the object
            gameObject.TryGetComponent(out ICollectible collectible);
            collectible.Collect();
            Destroy(gameObject);
        }
    }
}
