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
    void Start()
    {
        direction = Vector2.one.normalized;
    }

    void FixedUpdate()
    {
        ownRb.velocity = direction * ballSpeed * Time.fixedDeltaTime;
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
}
