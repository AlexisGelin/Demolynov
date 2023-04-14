using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    public void ExplosionObject()
    {
        gameObject.GetComponent<BoxCollider>().size = new Vector3(6, 6, 6);
        particle.SetActive(true);
        particle.GetComponent<ParticleSystem>().Play();

        Destroy(gameObject, particle.GetComponent<ParticleSystem>().main.duration);
    }

}
