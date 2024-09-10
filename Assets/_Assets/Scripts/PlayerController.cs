using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public Stats stats;
    public Rigidbody2D rb;
    public FrameInput frameInput;
    public Vector3 frameVelocity;
    public float angle;
    public float angleOffset;
    
    

    #region Interface
    public Vector3 FrameInput => frameInput.move;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        HandleDirection();
        ApplyMovement();
    }

    private void GatherInput()
    {
        frameInput = new FrameInput
        {
            move = Camera.main.ScreenToWorldPoint(Input.mousePosition)
        };
        RoundGatherInput();
    }

    void RoundGatherInput()
    {
        frameInput.move.z = 0;
        if(frameInput.move.x < 0)
        {
            frameInput.move.x = Mathf.Abs(frameInput.move.x);
        }
        frameInput.move.x = frameInput.move.x < 1 ? 1 : frameInput.move.x;
    }

    private void HandleDirection()
    {
        Vector3 direction = frameInput.move - transform.position;
        direction.x = Mathf.Abs(direction.x);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle >= -90 && angle <= 90)
        {
            transform.rotation = Quaternion.AngleAxis(angle+angleOffset, Vector3.forward);     
        }

        // Cập nhật frameVelocity để di chuyển về phía trước theo hướng xoay
        frameVelocity = direction.normalized * stats.speed * Time.fixedDeltaTime;
        
    }

    public void ApplyMovement() => rb.velocity = frameVelocity;
}

public struct FrameInput
{
    public Vector3 move;
}

public interface IPlayerController
{
    public Vector3 FrameInput { get; }
}
