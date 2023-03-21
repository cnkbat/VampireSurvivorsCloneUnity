using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{   
    MapController MapController;

    [SerializeField] GameObject TargetMap;
    void Start()
    {
        MapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            MapController.SetCurrentChunk(TargetMap);
        }
        MapController.ChunkChecker();
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            if(MapController.GetCurrentChunk() == TargetMap)
            {
                MapController.SetCurrentChunk(null);
            }
        }

        MapController.ChunkOptimizer();

    }
    GameObject GetTargetChunk()
    {
        return TargetMap;
    }
}
