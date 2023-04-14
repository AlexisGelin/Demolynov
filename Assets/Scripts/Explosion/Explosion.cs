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
        var explodeFX = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject, particle.GetComponent<ParticleSystem>().main.duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hitPlayer1") || other.CompareTag("hitPlayer2"))
        {
            gameObject.tag = other.tag + "e";
            ExplosionObject();
        }
    }
}