using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PropsController : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] int _score;
    [SerializeField] GameObject _source;
    [SerializeField] ParticleSystem _ps;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(_source);
        }
    }

    public void takeDamage(GameObject player)
    {
        _hp = _hp - 1;
        if (_hp <= 0)
        {
            this.gameObject.SetActive(false);
            _ps.Play();
        }
        else
        {
            Vector3 direction = this.gameObject.transform.position - player.gameObject.transform.position;
            Vector3 destination = new Vector3(Mathf.Sign(direction.x)*0.1f, Mathf.Sign(direction.y) * 0.1f, Mathf.Sign(direction.z) * 0.1f);
            this.gameObject.transform.DOPunchPosition(destination, 0.5f);
        }
    }
    public void takeDamage()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            takeDamage(collision.body.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(("Explosion")))
        {
            takeDamage();
        }
    }
}
