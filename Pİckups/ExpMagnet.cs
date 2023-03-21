using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpMagnet : MonoBehaviour, ICollectible
{

    PlayerCollector PlayerCollector;


    public bool IsMagnetOn = false;

    BoxCollider2D BoxCollider2D;
    [SerializeField] float MagnetDuration;
    float CurrentMagnetTime;
    void Start() 
    {
        PlayerCollector = FindObjectOfType<PlayerCollector>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        CurrentMagnetTime = MagnetDuration;
    }

    //ontriggerda görünmez yapıcaz
    //startcoroutinle destroyu aktifleştiricez

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            gameObject.GetComponent<Renderer>().enabled =false;
        }
    }

    public void Collect()
    {
        IsMagnetOn = true;
        Debug.Log("Magnet on");
    }
    void Update() 
    {
        if(IsMagnetOn)
        {
            CurrentMagnetTime -=Time.deltaTime;
            if(CurrentMagnetTime <= 0)
            {
                Debug.Log("Magnet off");
                TurnMagnetOff();
            }
        }
    }
    
    void TurnMagnetOff()
    {
        IsMagnetOn = false;
        CurrentMagnetTime = MagnetDuration;
        Destroy(gameObject);
    }
}
