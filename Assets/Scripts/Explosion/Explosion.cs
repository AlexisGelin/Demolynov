using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<BoxCollider>().size = new Vector3(6, 6, 6);
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();
            //Instantiate(particle, transform.position, transform.rotation);
            //StartCoroutine(DestroyObject());
            Destroy(gameObject,  particle.GetComponent<ParticleSystem>().main.duration);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("player")) return;
        if (other.gameObject.layer is 3 or 6) return;
        Destroy(other);
    }*/
}
