using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private ScoreDetectore player1ScoreDector;
    [SerializeField] private ScoreDetectore player2ScoreDector;

    [SerializeField] private TextMeshProUGUI player1Scoretext;
    [SerializeField] private TextMeshProUGUI player2Scoretext;

    public event EventHandler onOnePlayerScorepoint;

    private int player1Score;
    private int player2Score;

    private void Awake()
    {
        player1ScoreDector.onBallReachedTheScoreBorder += Player1ScoreDector_onBallReachedTheScoreBorder;
        player2ScoreDector.onBallReachedTheScoreBorder += Player2ScoreDector_onBallReachedTheScoreBorder;
    }

    private void Start()
    {
        player1Scoretext.text = "0";
        player2Scoretext.text = "0";
    }

    private void OnDisable()
    {
        player1ScoreDector.onBallReachedTheScoreBorder -= Player1ScoreDector_onBallReachedTheScoreBorder;
        player2ScoreDector.onBallReachedTheScoreBorder -= Player2ScoreDector_onBallReachedTheScoreBorder;
    }

    private void Player2ScoreDector_onBallReachedTheScoreBorder(object sender, System.EventArgs e)
    {
        ApplyScore(player1Score, player1Scoretext);
    }

    private void Player1ScoreDector_onBallReachedTheScoreBorder(object sender, System.EventArgs e)
    {
        ApplyScore(player2Score, player2Scoretext);
    }
    private void ApplyScore(int playerScore, TextMeshProUGUI playerScoretext)
    {
        playerScore++;
        playerScoretext.text = playerScore.ToString();
        onOnePlayerScorepoint?.Invoke(this, EventArgs.Empty);
    }
}
