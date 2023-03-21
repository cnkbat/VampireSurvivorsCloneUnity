using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Enemy base script

    EnemyStats EnemyStats;
    Transform PlayerTransform;

    void Start()
    {
        PlayerTransform = FindObjectOfType<PlayerMovement>().transform;
        EnemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
        PlayerTransform.transform.position,
        EnemyStats.CurrentMoveSpeed * Time.deltaTime); 

        //constant move towards player
    }
}
