using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDetectore : MonoBehaviour
{
    public event EventHandler onBallReachedTheScoreBorder;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            onBallReachedTheScoreBorder?.Invoke(this, EventArgs.Empty);
        }
    }
}
