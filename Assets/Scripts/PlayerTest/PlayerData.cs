using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
   [HideInInspector] public float speed;
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
    [SerializeField] private ParticleSystem forceParticles;
    [SerializeField] private ParticleSystem speedParticles;

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
            forceParticles.Stop();
            RemoveForceBoost();
        }

        if (durationOfSpeedBoost <= remainingTimeSpeedBoost)
        {
            isSpeedBoosted = false;
            speedParticles.Stop();
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
            remainingTimeForceBoost += 1 * Time.deltaTime;
        }

        if (isFreezeTime)
        {
            remainingTimeFreeze += 1*Time.deltaTime;
        }

        if (isSpeedBoosted)
        {
            remainingTimeSpeedBoost += 1 * Time.deltaTime;
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
            speedParticles.Play();
            AddSpeedBoost(2);
            isSpeedBoosted = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("ForceBoost"))
        {
            forceParticles.Play();
            AddForceBoost(2);
            isForceBoosted = true;
            Destroy(collision.gameObject);
        }
    }
}