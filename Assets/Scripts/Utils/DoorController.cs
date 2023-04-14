using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] ParticleSystem _particuleHit;
    [SerializeField] ParticleSystem _particuleSmoke;
    [SerializeField] Collider col;

    private void OnTriggerEnter(Collider other)
    {
        _anim.SetBool("Open", true);
        _particuleHit.Play();
        StartCoroutine(DoorFallTime());
        col.enabled = false;
        generateNextRoom();
    }

    private IEnumerator DoorFallTime()
    {
        yield return new WaitForSeconds(1f);
        _particuleSmoke.Play();
    }

    public void generateNextRoom()
    {
        Debug.Log("missing code");
    }
}
