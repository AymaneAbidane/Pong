using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentAi : MonoBehaviour
{
    private enum Difficulty { Easy, Normal, Hard }

    [Serializable]
    private struct AiDifficulty
    {
        public Difficulty difficulty;
        public float delay;
    }

    [SerializeField] private Difficulty ownDifficulty;
    [SerializeField] private Rigidbody2D ownRb;
    [SerializeField] private float mvSpeed;
    [SerializeField] private Ball ball;
    [SerializeField] private AiDifficulty[] aiDifficultys;


    private float delayBeforStartMovingGain;
    private Vector2 playerPos;
    private float lerpSpeed = 1f;

    void Start()
    {
        InitDifficulty();
        FollowBall();
    }

    private void InitDifficulty()
    {
        foreach (var aiDifficulty in aiDifficultys)
        {
            if (aiDifficulty.difficulty == ownDifficulty)
            {
                delayBeforStartMovingGain = aiDifficulty.delay;
            }
        }
    }

    private void FollowBall()
    {
        //StartCoroutine(COR_FollowBall());
    }

    #region AI movment By Velocity
    private void FixedUpdate()
    {
        if (ball.transform.position.y > transform.position.y)
        {
            if (ownRb.velocity.y < 0)
            {
                ResetVelocity();
            }
            MoveWithVelocity(Vector2.up);
        }
        else if (ball.transform.position.y < transform.position.y)
        {
            if (ownRb.velocity.y > 0)
            {
                ResetVelocity();
            }
            MoveWithVelocity(Vector2.down);
        }
        else
        {
            MoveWithVelocity(Vector2.zero);
        }

    }

    private void ResetVelocity()
    {
        ownRb.velocity = Vector2.zero;
    }

    private void MoveWithVelocity(Vector2 direction)
    {
        ownRb.velocity = Vector2.Lerp(ownRb.velocity, direction * mvSpeed, lerpSpeed * Time.deltaTime);
    }
    #endregion

    #region Ai Movment by Transform

    //private IEnumerator COR_FollowBall()
    //{
    //    while (true)
    //    {
    //        playerPos = new Vector2(-5f, ball.transform.position.y);
    //        ApplyPosition(playerPos);
    //        yield return new WaitForSeconds(delayBeforStartMovingGain);
    //    }
    //}

    //private void ApplyPosition(Vector2 finalPos)
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, finalPos, 2f);
    //}

    #endregion
}
