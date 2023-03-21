using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExperienceCrystal : Pickup , ICollectible
{
    [SerializeField] int ExperienceGranted;
    public void Collect()
    {
        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        playerStats.IncreaseExperince(ExperienceGranted);
        Debug.Log("Collected");
    }
    public int GetExperienceGranted()
    {
        return ExperienceGranted;
    }

    
}
