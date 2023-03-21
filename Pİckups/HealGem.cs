using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealGem : Pickup, ICollectible
{
    PlayerStats Player;
    [SerializeField] float HealAmount;
    public void Collect()
    {
        Player = FindObjectOfType<PlayerStats>();

        Player.Heal(HealAmount);

        Debug.Log("Healed");
    }

}
