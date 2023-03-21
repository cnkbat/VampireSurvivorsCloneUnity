using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAreaPickerBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] float RandXAxis;
    [SerializeField] float RandYAxis;   
    [SerializeField] float UntouchableDuration;
    float UntouchableTimer;

    bool bIsUntouchable;
    Vector3 SpawnPosition;
    protected override void Start()
    {
        base.Start();

        float SpawnPositionX = Player.transform.position.x + Random.Range(-RandXAxis,RandXAxis);

        float SpawnPositionY = Player.transform.position.y + Random.Range(-RandYAxis,RandYAxis);

        SpawnPosition = new Vector3(SpawnPositionX, SpawnPositionY , 0);

        transform.position = SpawnPosition;
    }

    private void Update() 
    {
        if(UntouchableTimer > 0)
        {
            UntouchableTimer -= Time.deltaTime;
        }
        else if (bIsUntouchable)
        {
            bIsUntouchable = false;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(!bIsUntouchable)
        {
            UntouchableTimer = UntouchableDuration;
            bIsUntouchable = true;

            base.OnTriggerEnter2D(other);
        }
    }
}
