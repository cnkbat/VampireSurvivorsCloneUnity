using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject ItemPrefab;
        public float DropRate;
    }
     
    public List<Drops> drops;

    public void DropOnDeath() 
    {
        float RandomNumber = UnityEngine.Random.Range(0f,100f);
        List<Drops> PossibleDrops = new List<Drops>();
        foreach(Drops rate in drops)
        {
            if(RandomNumber <= rate.DropRate)
            {
                PossibleDrops.Add(rate);
            }
        }
        //check if more than gameobject matches the percentage
        if(PossibleDrops.Count > 0)
        {
            Drops drops = PossibleDrops[UnityEngine.Random.Range(0,PossibleDrops.Count)];

            Instantiate(drops.ItemPrefab,transform.position, Quaternion.identity);
        }
    }
}
