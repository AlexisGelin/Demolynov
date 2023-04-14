using System;
using TMPro;
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

    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textCombo;
    [SerializeField] private TMP_Text textMult;
    [SerializeField] private Slider slider;
    
    [Range(0, 10)] [SerializeField] private float delayBeforeResetCombo;

  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            remainingTime = 0;
            series += 1;

            if (series % 5 == 0)
            {
                combo.IncCombo();
            }

            AddScore(Random.Range(1, 10));

        }

        remainingTime += 0.01f;
        if (delayBeforeResetCombo <= remainingTime)
        {
            combo.ResetCombo();
            series = 0;
        }

        textScore.text = "Score : " + GetScore();
        textMult.text = "Multiplicator : " + combo.GetCombo();
        textCombo.text = "Combo : " + series;
        slider.minValue = 0;
        slider.maxValue = delayBeforeResetCombo;
        slider.value = delayBeforeResetCombo - remainingTime;
        //text.text = "Score : " + GetScore() + "\nCombo : " + combo.GetCombo();

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