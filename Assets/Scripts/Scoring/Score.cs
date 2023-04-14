using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Score : MonoBehaviour
{
    private int score { get; set; }
    public Combo Combo { get => combo; }

    private int series;
    public int TotalObjectDestroy;
    public int MaxCombo;

    // ---- code de test -----
    private Combo combo = new();

    private float remainingTime;

    [SerializeField] private TMP_Text textScore;
    [SerializeField] private TMP_Text textCombo;
    [SerializeField] private TMP_Text textMult;
    [SerializeField] private Slider slider;

    [Range(0, 10)][SerializeField] private float delayBeforeResetCombo;



    private void Update()
    {


        remainingTime += 1 * Time.deltaTime;
        if (delayBeforeResetCombo <= remainingTime)
        {
            if (series >= MaxCombo) MaxCombo = series;
            combo.ResetCombo();
            series = 0;
        }

        textScore.text = "Score : " + GetScore();
        textMult.text = "Bonus : " + combo.GetCombo() + "x";

        textCombo.text = "Combo : " + series;
        slider.minValue = 0;
        slider.maxValue = delayBeforeResetCombo;
        slider.value = delayBeforeResetCombo - remainingTime;
    }

    public void AddScore(int scoreToAdd)
    {
        remainingTime = 0;
        series += 1;

        DOTween.Kill(textMult.GetComponent<RectTransform>());
        textCombo.GetComponent<RectTransform>().localScale = Vector3.one;
        textCombo.GetComponent<RectTransform>().DOPunchScale(new Vector3(.2f, .2f, .2f), .1f).OnComplete(() => textCombo.GetComponent<RectTransform>().localScale = Vector3.one);

        if (series % 5 == 0)
        {
            combo.IncCombo();
        }

        TotalObjectDestroy++;

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