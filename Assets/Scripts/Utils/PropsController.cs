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
    public GameObject player1, player2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(GameObject player, int damage)
    {
        _hp = _hp - damage;
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

    private void OnCollisionEnter(Collision collision,int damage)
    {
        if (collision.gameObject.tag.Equals("Weapon"))
        {
            takeDamage(collision.body.gameObject,damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hitPlayer1"))
        {
            _source = player1;
            takeDamage(player1, other.gameObject.GetComponent<Weapon>().damage);
        }

        if (other.CompareTag("hitPlayer2"))
        {
            _source = player2;
            takeDamage(player2, other.gameObject.GetComponent<Weapon>().damage);
        }
    }
}
