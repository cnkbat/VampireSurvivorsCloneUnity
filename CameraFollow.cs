using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    PlayerStats PlayerStats;

    [SerializeField] Vector3 OffSet;
    void Awake() 
    {
        PlayerStats = FindObjectOfType<PlayerStats>();     
    }

    void Update()
    {
        transform.position = PlayerStats.transform.position + OffSet;
    }
}
