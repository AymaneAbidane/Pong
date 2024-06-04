using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private PlayerMovment[] scenePlayers;
    [SerializeField] private Ball mainball;
    [SerializeField] private float delayBeforTheBallCanMove;
    [SerializeField] private bool vsAi;
    private void Awake()
    {
        scoreManager.onOnePlayerScorepoint += ScoreManager_onOnePlayerScorepoint;
    }

    private void OnDisable()
    {
        scoreManager.onOnePlayerScorepoint -= ScoreManager_onOnePlayerScorepoint;
    }

    private void ScoreManager_onOnePlayerScorepoint(object sender, System.EventArgs e)
    {
        ResetGamePlay();

        StartCoroutine(COR_MoveTheBall());
    }

    private IEnumerator COR_MoveTheBall()
    {
        mainball.SetRandomDirection();
        yield return new WaitForSeconds(delayBeforTheBallCanMove);
        mainball.SetCanMove(true);
    }

    private void ResetGamePlay()
    {
        mainball.SetCanMove(false);
        foreach (var player in scenePlayers)
        {
            player.ResetPosition();
            if (vsAi)
            {
                break;
            }
        }

    }
}
