using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    [SerializeField] SpriteScroller spriteScroller;
    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    Shooter shooter;

    private void Awake() 
    {
        shooter = GetComponent<Shooter>();    
    }
    
    void Start() 
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void Move() 
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
        spriteScroller.setHorizontalMoveSpeed(delta.x);
    }

    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    private void OnFire(InputValue value)
    {
        if (shooter != null) 
        {
            shooter.isShooting = value.isPressed;
        }
    }
}
