using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbRandomizer : MonoBehaviour
{
    [SerializeField] List<GameObject> PropSpawnLocations;
    [SerializeField] List<GameObject> PropPrefabs;

    [SerializeField] int SpawnChanceOfProbs = 5;
    void Start()
    {
        SpawnProps();
    }
    void SpawnProps()
    {
        foreach(GameObject sp in PropSpawnLocations)
        {
            int RandomNumber = Random.Range(0,SpawnChanceOfProbs);
            if(RandomNumber < 1)
            {
                int rand = Random.Range(0,PropPrefabs.Count);
                Instantiate(PropPrefabs[rand],sp.transform.position,Quaternion.identity); 
            }
            

        }
    }
}
