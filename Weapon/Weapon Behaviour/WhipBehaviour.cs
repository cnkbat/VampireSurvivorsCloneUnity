using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipBehaviour : MeleeBehaviour
{
    protected Vector3 Direction;
    protected override void Start()
    {
        base.Start(); 
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    public void DirectionChecker(Vector3 dir)
    {
        Direction = dir;
    
        float dirx= Direction.x;
        float diry= Direction.y;

        Vector3 Scale = transform.localScale;

        if(dirx < 0 && diry == 0)  // left
        {
            Scale.x = Scale.x * -1;

            
        }
        else if(dirx < 0 && diry > 0)  //left up
        {
            Scale.x = Scale.x * -1;

            
        }
        else if(dirx < 0 && diry < 0)  //left down
        {
            Scale.x = Scale.x * -1;

            
        }

        else if(dirx == 0 && diry > 0)  //up
        {

            Scale.y = Scale.y * -1;
            
        }

        else if(dirx == 0 && diry < 0)  //down
        {
            Scale.y = Scale.y * -1;

        }

        transform.localScale = Scale;
        
    }
}
