using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 100f;
    public int IDPlayer;
    public GameObject mesh;
    public Animator animationPlayer;
    public GameObject hand;
    public GameObject weaponOnHand;


    private void Start()
    {

    }

    void Update()
    {
        if (IDPlayer == 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, -90, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, 180, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.back * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, 90, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            }
            if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.Z))
            {
                animationPlayer.SetBool("walk", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                animationPlayer.SetBool("punch", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animationPlayer.SetBool("punch", false);
            }
            if (Input.GetKey(KeyCode.E))
            {

            }
        }
        if (IDPlayer == 1)
        {
            if (Input.GetKey(KeyCode.O))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.K))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, -90, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.L))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, 180, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.back * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.M))
            {
                animationPlayer.SetBool("walk", true);
                mesh.transform.DORotate(new Vector3(0, 90, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            }
            if (!Input.GetKey(KeyCode.O) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.M))
            {
                animationPlayer.SetBool("walk", false);
            }
            if (Input.GetKey(KeyCode.I))
            {
                animationPlayer.SetBool("punch", true);
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                animationPlayer.SetBool("punch", false);
            }
            if (Input.GetKey(KeyCode.P))
            {

            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("weapon"))
        {
            if (IDPlayer == 0 && Input.GetKey(KeyCode.E))
            {
                weaponOnHand = other.GetComponent<GameObject>();
                weaponOnHand.transform.parent = hand.transform;
            }
        }
    }

}
