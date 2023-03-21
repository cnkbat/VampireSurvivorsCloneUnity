using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> TerrainChunks;
    CharacterSelector CharacterSelector;
    [SerializeField] float CheckerRadius;
    Vector3 NoTerrainPosition;
    [SerializeField] LayerMask TerrainMask; 

    [SerializeField] GameObject CurrentChunk;
    PlayerMovement PlayerMovement;

    [Header("Optimization")]
    public List<GameObject> SpawnedChunks;

    GameObject LastestChunk;

    public float MaxOpDist; //must be greater than tilemap
    void Start()
    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void ChunkChecker()
    {
        if(!CurrentChunk)
        {
            return;
        }

        if(PlayerMovement.GetPlayerMovementDirection().x > 0 ) //right side
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Right").position,CheckerRadius,TerrainMask)) // left
            {
                NoTerrainPosition =CurrentChunk.transform.Find("Right").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpRight").position,CheckerRadius,TerrainMask)) // right up
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpRight").position;
                SpawnChunk();
            }
            
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownRight").position,CheckerRadius,TerrainMask)) // right down
            {
                NoTerrainPosition=CurrentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Down").position,CheckerRadius,TerrainMask)) // DOWN
            {
                NoTerrainPosition=CurrentChunk.transform.Find("Down").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Up").position,CheckerRadius,TerrainMask)) // UP
            {
                NoTerrainPosition = CurrentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }

        else if(PlayerMovement.GetPlayerMovementDirection().x < 0 ) //left side 
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Left").position,CheckerRadius,TerrainMask)) // left
            {
                NoTerrainPosition = CurrentChunk.transform.Find("Left").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpLeft").position,CheckerRadius,TerrainMask)) // left up
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpLeft").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownLeft").position,CheckerRadius,TerrainMask)) // left down
            {
                NoTerrainPosition = CurrentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            } 

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Down").position,CheckerRadius,TerrainMask)) // DOWN
            {
                NoTerrainPosition=CurrentChunk.transform.Find("Down").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Up").position,CheckerRadius,TerrainMask)) // UP
            {
                NoTerrainPosition = CurrentChunk.transform.Find("Up").position;
                SpawnChunk();
            }

            
        }
    
        else if(PlayerMovement.GetPlayerMovementDirection().y > 0 && PlayerMovement.GetPlayerMovementDirection().x == 0) //Up
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Up").position,CheckerRadius,TerrainMask)) // UP
            {
                NoTerrainPosition = CurrentChunk.transform.Find("Up").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpLeft").position,CheckerRadius,TerrainMask)) // left up
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpLeft").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpRight").position,CheckerRadius,TerrainMask)) // right up
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpRight").position;
                SpawnChunk();
            }

            

        }
        
        else if(PlayerMovement.GetPlayerMovementDirection().y < 0 && PlayerMovement.GetPlayerMovementDirection().x == 0) //Down
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("Down").position,CheckerRadius,TerrainMask)) // DOWN
            {
                NoTerrainPosition=CurrentChunk.transform.Find("Down").position;
                SpawnChunk();
            }

            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownLeft").position,CheckerRadius,TerrainMask)) // left down
            {
                NoTerrainPosition = CurrentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            } 
            
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownRight").position,CheckerRadius,TerrainMask)) // right down
            {
                NoTerrainPosition=CurrentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }
        }
       //                         TEST İCİN AGA


        ///                                         <<< OLD SYSTEM >>>
       /* else if(PlayerMovement.GetPlayerMovementDirection().x > 0 && PlayerMovement.GetPlayerMovementDirection().y > 0) //right up
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpRight").position,CheckerRadius,TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpRight").position;
                SpawnChunk();
            }
        }


        else if(PlayerMovement.GetPlayerMovementDirection().x > 0 && PlayerMovement.GetPlayerMovementDirection().y < 0) //right down
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownRight").position,CheckerRadius,TerrainMask))
            {
                NoTerrainPosition=CurrentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }
        }

        else if(PlayerMovement.GetPlayerMovementDirection().x < 0 && PlayerMovement.GetPlayerMovementDirection().y > 0) //left up
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("UpLeft").position,CheckerRadius,TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("UpLeft").position;
                SpawnChunk();
            }
        }

        else if(PlayerMovement.GetPlayerMovementDirection().x<0 && PlayerMovement.GetPlayerMovementDirection().y< 0) //left down
        {
            if(!Physics2D.OverlapCircle(CurrentChunk.transform.Find("DownLeft").position,CheckerRadius,TerrainMask))
            {
                NoTerrainPosition = CurrentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            }
        } */
    }
    void SpawnChunk()
    {
        int rand = Random.Range(0,TerrainChunks.Count);
        LastestChunk = Instantiate(TerrainChunks[rand],NoTerrainPosition,Quaternion.identity);

        SpawnedChunks.Add(LastestChunk);
    }

    public void ChunkOptimizer()
    {
        foreach(GameObject chunk in SpawnedChunks)
        {   
            
            float OpDist = Vector3.Distance(PlayerMovement.transform.position,chunk.transform.position);

            if(OpDist >  MaxOpDist) 
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
    List<GameObject> GetTerrainChunks()
    {
        return TerrainChunks;
    }

    float GetCheckerRadius()
    {
        return CheckerRadius;
    }

    LayerMask GetTerrainLayerMask()
    {
        return TerrainMask;
    }

    public GameObject GetCurrentChunk()
    {
        return CurrentChunk;
    }

    public void SetCurrentChunk(GameObject gb)
    {
        CurrentChunk = gb;
    }
}
