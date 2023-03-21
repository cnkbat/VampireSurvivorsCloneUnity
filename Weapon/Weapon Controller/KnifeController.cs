using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    [SerializeField] Vector3 KnifeStrikeOffSet;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        
        GameObject SpawnedKnife = Instantiate(WeaponSO.WeaponPrefab);

        SpawnedKnife.transform.position = transform.position;

        // Position Setting

        Vector3 SpawnPointMultiplier = (Vector3) PlayerMovement.GetLastMovedAxis();

        if(gameObject.transform.parent.localScale.x > 0)
        {
            SpawnedKnife.transform.position = transform.position + Vector3.Scale(KnifeStrikeOffSet ,SpawnPointMultiplier);  
        }
        else
        {
            SpawnedKnife.transform.position = transform.position + Vector3.Scale(KnifeStrikeOffSet , SpawnPointMultiplier);  
        }
        
        SpawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(PlayerMovement.GetLastMovedAxis());
    }
   
}
