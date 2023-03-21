using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave 
    {
        public string WaveName;
        public List<EnemyGroup> EnemyGroups;
        public int EnemyQuota; // the total number of eneies to spawn in this wave
        public float SpawnGap; // Time Between Two Wave Spawns
        public int SpawnCount; //the number of enemies already enemies spawned in this wave
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string EnemyName;
        public int EnemyCount; // the total number of eneies to spawn in this wave
        public GameObject EnemyPrefab;
        public int SpawnCount; //the number of enemies already enemies spawned in this wave
    }

    public List<Wave> Waves; // a list of all the waves in the game
    public int CurrentWaveCount; //the index of current Wave [Remember, a list starts from  0]
    [Header("Spawn Atrributes")]
    float SpawnTimer; // Timer use to spawn next enemy
    public int EnemiesAlive;
    public int MaxEnemiesAllowed; // maxnumber of allowed enemies to enhance gameplay
    public bool MaxEnemiesReached = false;   // a flag indicating if the maximum number of enemies has been reached
    public float WaveGap; // the interval between each wave
    
    [Header("Spawn Positions")]
    public List<Transform> RelativeSpawnPoints; //a list to store all the spawn points of enemies

    bool CanBeginNextWave = false;
    Transform PlayerTransfrom; 
    private void Start() 
    {
        PlayerTransfrom = FindObjectOfType<PlayerStats>().transform;
        CalculateEnemyQuota();
        
    }
    private void Update() 
    {
        if(CurrentWaveCount < Waves.Count && Waves[CurrentWaveCount].SpawnCount == Waves[CurrentWaveCount].EnemyQuota) // check if the wave end and is there more?
        {
            StartCoroutine(BeginNextWave());
            CanBeginNextWave = true;
        }
        SpawnTimer += Time.deltaTime;

        if(SpawnTimer >= Waves[CurrentWaveCount].SpawnGap)
        {
            SpawnTimer = 0;
            SpawnEnemies();
        }
    }    

    IEnumerator BeginNextWave()
    {   
        //wave will spawn after the wavegap ends
        yield return new WaitForSeconds(WaveGap);

        //move on to the next wave
        if(CurrentWaveCount < Waves.Count -1 && CanBeginNextWave)
        {
            CurrentWaveCount++;
            CanBeginNextWave = false;
            CalculateEnemyQuota();
        }

    }
    void CalculateEnemyQuota()
    {
        int CurrentEnemyQuota = 0;
        foreach(var EnemyGroup in Waves[CurrentWaveCount].EnemyGroups)
        {
            CurrentEnemyQuota += EnemyGroup.EnemyCount;
        }
        
        Waves[CurrentWaveCount].EnemyQuota = CurrentEnemyQuota;
        Debug.LogWarning("Enemy Quota = " + CurrentEnemyQuota);
    }

    //<<SUMMARY>>
    // this method will stop spawning enemies if amount of enemiesalive is max. 
    //<<SUMMARY>>
    void SpawnEnemies()
    {   
        //check if quota is full
        if(Waves[CurrentWaveCount].SpawnCount < Waves[CurrentWaveCount].EnemyQuota && !MaxEnemiesReached)
        {   
            // spawn each type of enemy until the quota is filled
            foreach (var EnemyGroup in Waves[CurrentWaveCount].EnemyGroups)
            {
                //check if the minimum number of enemies of this type have been spawned
                if(EnemyGroup.SpawnCount < EnemyGroup.EnemyCount)
                {
                    // checking for the maxenemies for not breaking the game
                    if(EnemiesAlive >= MaxEnemiesAllowed)
                    {
                        MaxEnemiesReached =true;
                        return;
                    }

                    //spawn enemies at a random preset point
                    Instantiate(EnemyGroup.EnemyPrefab, 
                    PlayerTransfrom.position + RelativeSpawnPoints[Random.Range(0,RelativeSpawnPoints.Count)].position,
                    Quaternion.identity);

                    EnemyGroup.SpawnCount++;
                    Waves[CurrentWaveCount].SpawnCount++;
                    EnemiesAlive++;
                }
            }
        }

        //reseting the maxenemiesreached to continue spawning enemies
        if(EnemiesAlive < MaxEnemiesAllowed)
        {
            MaxEnemiesReached = false;
        }
    
    }

    //Call when the enemy dies
    public void OnEnemyKilled()
    {
        //decrement the numberof enemiesalive on death

        EnemiesAlive--;
    }
  
}
