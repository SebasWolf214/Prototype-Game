using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    public float FallMutiplier = 2.5f;
    public float LowJumpMultiplier = 2f;

    Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMutiplier - 1) * Time.deltaTime;

        }
        else if (_rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

}
