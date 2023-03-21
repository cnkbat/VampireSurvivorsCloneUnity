using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipController : WeaponController
{

    [SerializeField] Vector3 WhipStrikePointHorizontal;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();

        GameObject SpawnedWhip = Instantiate(WeaponSO.WeaponPrefab);

        // Position Setting

        if(gameObject.transform.parent.localScale.x > 0)
        {
            SpawnedWhip.transform.position = transform.position + WhipStrikePointHorizontal;  
        }
        else
        {
            SpawnedWhip.transform.position = transform.position - WhipStrikePointHorizontal;  
        }
         

        SpawnedWhip.GetComponent<WhipBehaviour>().DirectionChecker(PlayerMovement.GetLastMovedAxis());
    }


}
