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
        
    }

    public void takeDamage(GameObject player, int damage)
    {
        StartCoroutine(CooldownHit(damage));

        if (_hp <= 0)
        {
            _source.GetComponent<Score>().AddScore(_score);

            var _floatingTextGO = ObjectPooler.Instance.SpawnFromPool("FloatingText", transform.position + new Vector3(0, 0, -0.1f), Quaternion.identity);
            var _floatingText = _floatingTextGO.GetComponent<FloatingText>();

            _floatingText.InitSmall(_score, _source.GetComponent<Score>().Combo.GetCombo());

            ObjectPooler.Instance.SpawnFromPool("Debris", new Vector3(transform.position.x - 6f, 0, transform.position.z + 11.5f), Quaternion.identity);

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



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hitPlayer1"))
        {
            _source = GameManager.Instance.Player1.gameObject;
            takeDamage(_source, other.gameObject.GetComponent<Weapon>().damage);
        }

        if (other.CompareTag("hitPlayer2"))
        {
            _source = GameManager.Instance.Player2.gameObject; ;
            takeDamage(_source, other.gameObject.GetComponent<Weapon>().damage);
        }
    }

    IEnumerator CooldownHit(int damage)
    {
        yield return (0.5f);
        _hp = _hp - damage;
    }

}
