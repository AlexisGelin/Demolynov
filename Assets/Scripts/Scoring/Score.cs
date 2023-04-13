using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Score : MonoBehaviour
{
    private int score { get; set; }
    private int series;
    
// ---- code de test -----
    private Combo combo = new();

    private float remainingTime;

    [SerializeField] private Text text;
    [Range(0, 10)] [SerializeField] private float delayBeforeResetCombo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            remainingTime = 0;
            series += 1;

            if (series % 10 == 0)
            {
                combo.IncCombo();
            }

            AddScore(Random.Range(1, 10) );

        }

        remainingTime += 0.01f;
        if (delayBeforeResetCombo <= remainingTime)
        {
            combo.ResetCombo();
            series = 0;
        }
        text.text = "Score : " + GetScore() + "\nCombo : " + combo.GetCombo();

    }
// ---- fin code de test -----

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd * combo.GetCombo();
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}