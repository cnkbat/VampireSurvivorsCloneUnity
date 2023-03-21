using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProps : MonoBehaviour
{
    [SerializeField] float Health;
    DropRateManager DropRateManager;
    void Start() 
    {
        DropRateManager = GetComponent<DropRateManager>();
    }
    public void TakeDamage(float dmg)
    {
        Health -= dmg;
        if(Health <= 0)
        {
            Kill();
        }
    }
    void Kill()
    {   
        DropRateManager.DropOnDeath();
        Destroy(gameObject);
    }
}
