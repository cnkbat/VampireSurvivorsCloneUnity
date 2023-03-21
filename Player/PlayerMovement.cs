using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    PlayerStats PlayerStats;
    
    
    //COMPONENTS
    Vector2 MoveInput;
    Rigidbody2D Rigidbody2D;
    CapsuleCollider2D CapsuleCollider;

    Vector2 LastMovedAxis;

    //LastMovedAxis
    float LastMovedHorizontalAxis;
    float LastMovedVerticalAxis;

    Vector2 MovementDirection;

    //HAS SPEEED
    bool PlayerHasHorizontalSpeed;

    bool PlayerHasVerticalSpeed;

    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
        PlayerStats = GetComponent<PlayerStats>();

        LastMovedAxis = new Vector2 (1f,0f);

    }
    
    void Update()
    {
        MoveCharacter();

        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
        MovementDirection= MoveInput;
    }

    void MoveCharacter()
    {
        Vector2 PlayerVelocity = new Vector2 (MoveInput.x * PlayerStats.CurrentMoveSpeed,MoveInput.y * PlayerStats.CurrentMoveSpeed);
        Rigidbody2D.velocity=PlayerVelocity;
        
        if(MovementDirection.y !=0)
        {   
            LastMovedVerticalAxis = MovementDirection.y;
            LastMovedAxis = new Vector2 (0f,LastMovedVerticalAxis); // last Moved Y
        }


        if(MovementDirection.x !=0)
        {   
            LastMovedHorizontalAxis = MovementDirection.x;
            LastMovedAxis = new Vector2 (LastMovedHorizontalAxis,0f); // last moved X
        }


        if(MovementDirection.x !=0 && MovementDirection.y !=0)
        {
            LastMovedAxis = new Vector2 (LastMovedHorizontalAxis,LastMovedVerticalAxis);  // last moved x , y
        }
    }

    void FlipSprite()
    {
        PlayerHasHorizontalSpeed = Mathf.Abs(Rigidbody2D.velocity.x) > Mathf.Epsilon;
        PlayerHasVerticalSpeed = Mathf.Abs(Rigidbody2D.velocity.y) > Mathf.Epsilon;
        if(PlayerHasHorizontalSpeed)
        {
            transform.localScale=  new Vector2 (Mathf.Sign(Rigidbody2D.velocity.x),1f);
        }
        
    }

    public Vector2 GetPlayerMovementDirection()
    {
        return MovementDirection;
    }

    public Vector2 GetLastMovedAxis()
    {
        return LastMovedAxis;
    }
    
    public Rigidbody2D GetRB2D()
    {
        return Rigidbody2D;
    }
}
