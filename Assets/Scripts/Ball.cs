using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    [SerializeField] private Rigidbody2D ownRb;

    private const string WALL_TAG_STRING = "SideWalls";
    private const string PLAYERS_TAG_STRING = "Player";

    private Vector2 direction;
    private bool canMove;

    void Start()
    {
        canMove = true;
        direction = Vector2.one.normalized;
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            ownRb.velocity = direction * ballSpeed * Time.fixedDeltaTime;
        }
        else
        {
            transform.position = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(WALL_TAG_STRING))
        {
            direction.y = -direction.y;
        }
        else if (collision.gameObject.CompareTag(PLAYERS_TAG_STRING))
        {
            direction.x = -direction.x;
        }
    }

    public void SetCanMove(bool v)
    {
        canMove = v;
    }
    public void SetRandomDirection()
    {
        float value = UnityEngine.Random.value;
        if (value <= 0.5f)
        {
            direction.y = -direction.y;
            direction.x = -direction.x;
        }
    }
}
