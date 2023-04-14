using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 100f;
    public int damage = 1;
    public int IDPlayer;
    public GameObject mesh;
    public Animator animationPlayer;
    public GameObject hand;
    public GameObject weaponOnHand;
    public GameObject weaponOnFloor;
    public Weapon weapon;
    public GameObject hitArea;


    private void Start()
    {
        hitArea.SetActive(false);
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
                hitArea.SetActive(true);
                animationPlayer.SetBool("punch", true);
                hitArea.SetActive(false);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animationPlayer.SetBool("punch", false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (weaponOnHand != weaponOnFloor)
                {
                    weaponOnFloor.transform.rotation = new Quaternion(0, 0, 0, 0);
                    animationPlayer.SetBool("haveWeapon", true);
                    weaponOnFloor.gameObject.transform.parent = hand.transform;
                    weaponOnFloor.gameObject.transform.localPosition = new Vector3(0.00111f, 0.00117f, -0.00092f);
                    weaponOnFloor.gameObject.transform.DOLocalRotate(new Vector3(0, 90, 180), 0.1f);
                    weapon = weaponOnFloor.gameObject.GetComponent<Weapon>();
                    if (weaponOnHand != null)
                    {
                        weaponOnHand.transform.parent = null;
                    }
                    weaponOnHand = weaponOnFloor.gameObject;
                }
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
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (weaponOnHand != weaponOnFloor)
                {
                    weaponOnFloor.transform.rotation = new Quaternion(0, 0, 0, 0);
                    animationPlayer.SetBool("haveWeapon", true);
                    weaponOnFloor.gameObject.transform.parent = hand.transform;
                    weaponOnFloor.gameObject.transform.localPosition = new Vector3(0.00111f, 0.00117f, -0.00092f);
                    weaponOnFloor.gameObject.transform.DOLocalRotate(new Vector3(0, 90, 180), 0.1f);
                    if (weaponOnHand != null)
                    {
                        weaponOnHand.transform.parent = null;
                    }
                    weaponOnHand = weaponOnFloor.gameObject;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            weaponOnFloor = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            weaponOnFloor = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*if(other.CompareTag("weapon"))
        {
            if (IDPlayer == 0 && Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }*/
    }
}
