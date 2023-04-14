using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
   [NonSerialized] public float speed;
    private bool isSpeedBoosted;
    private float remainingTimeSpeedBoost;
    [SerializeField] private float originSpeed;
    [NonSerialized] public float force;
    private bool isForceBoosted;
    private float remainingTimeForceBoost;
    private bool isFreezeTime;
    private float remainingTimeFreeze;

    [SerializeField] private float originForce;
    [SerializeField] private GameObject freezeEffectImage; //canva avec une image
    [SerializeField] private GamePanel panel;
    [Range(0, 10)] [SerializeField] private float durationOfSpeedBoost;
    [Range(0, 10)] [SerializeField] private float durationOfForceBoost;
    [Range(0, 10)] [SerializeField] private float durationOfTimeFreeze;


    private void Awake()
    {
        speed = originSpeed;
        force = originForce;
    }

    private void Update()
    {
        if (durationOfForceBoost <= remainingTimeForceBoost)
        {
            isForceBoosted = false;
            RemoveForceBoost();
        }

        if (durationOfSpeedBoost <= remainingTimeSpeedBoost)
        {
            isSpeedBoosted = false;
            RemoveSpeedBoost();
        }

        if (durationOfTimeFreeze <= remainingTimeFreeze)
        {
            isFreezeTime = false;
            freezeEffectImage.SetActive(false);

            panel.PowerUpFreezeCoeff = 1;
        }

        if (isForceBoosted)
        {
            remainingTimeForceBoost += 0.1f;
        }

        if (isFreezeTime)
        {
            remainingTimeFreeze += 0.1f;
        }

        if (isSpeedBoosted)
        {
            remainingTimeSpeedBoost += 0.1f;
        }
    }

    private void AddSpeedBoost(float multiplier)
    {
        if (!isSpeedBoosted)
        {
            speed *= multiplier;
        }

        remainingTimeSpeedBoost = 0;
    }

    private void RemoveSpeedBoost()
    {
        speed = originSpeed;
    }

    private void AddForceBoost(float multiplier)
    {
        if (!isForceBoosted)
        {
            force *= multiplier;
        }

        remainingTimeForceBoost = 0;
    }

    private void RemoveForceBoost()
    {
        force = originForce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("FreezeTime"))
        {
            remainingTimeFreeze = 0;
            freezeEffectImage.SetActive(true);
            isFreezeTime = true;
            Destroy(collision.gameObject);
            panel.PowerUpFreezeCoeff = 0;
        }

        if (collision.gameObject.tag.Equals("SpeedBoost"))
        {
            AddSpeedBoost(2);
            isSpeedBoosted = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("ForceBoost"))
        {
            AddForceBoost(2);
            isForceBoosted = true;
            Destroy(collision.gameObject);
        }
    }
}