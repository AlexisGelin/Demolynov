using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    private float speed;
    private bool isSpeedBoosted;
    private float remainingTimeSpeedBoost;
    [SerializeField] private float originSpeed;
    private float force;
    private bool isForceBoosted;
    private float remainingTimeForceBoost;
    [SerializeField] private float originForce;
    [SerializeField] private bool freezeTime;
    [SerializeField] private Text text;
    [Range(0, 10)] [SerializeField] private float durationOfSpeedBoost;
    [Range(0, 10)] [SerializeField] private float durationOfForceBoost;

    private void Awake()
    {
        speed = originSpeed;
        force = originForce;
    }

    private void Update()
    {
        text.text = "Speed : " + GetSpeed() + "\n" + remainingTimeSpeedBoost + "/" + durationOfSpeedBoost +
                    "\nForce : " + GetForce() + "\n" + remainingTimeForceBoost + "/" + durationOfForceBoost;
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddSpeedBoost(2);
            isSpeedBoosted = true;
        }

        if (durationOfSpeedBoost <= remainingTimeSpeedBoost)
        {
            isSpeedBoosted = false;
            RemoveSpeedBoost();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AddForceBoost(2);
            isForceBoosted = true;
        }

        if (durationOfForceBoost <= remainingTimeForceBoost)
        {
            isForceBoosted = false;
            RemoveForceBoost();
        }

        if (isForceBoosted)
        {
            remainingTimeForceBoost += 0.1f;
        }

        if (isSpeedBoosted)
        {
            remainingTimeSpeedBoost += 0.1f;
        }
    }


    private float GetSpeed()
    {
        return speed;
    }

    public float GetForce()
    {
        return force;
    }

    public bool GetFreezeTime()
    {
        return freezeTime;
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
}