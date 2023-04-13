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

    void Update()
    {
        if (IDPlayer == 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                rb.transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.LookAt(transform.position + Vector3.left * speed * Time.deltaTime);
                rb.transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.transform.position = transform.position + Vector3.back * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {

            }
            if (Input.GetKey(KeyCode.E))
            {

            }
        }
        if (IDPlayer == 1)
        {
            if (Input.GetKey(KeyCode.O))
            {
                rb.transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.K))
            {
                rb.transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.L))
            {
                rb.transform.position = transform.position + Vector3.back * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.M))
            {
                rb.transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.I))
            {

            }
            if (Input.GetKey(KeyCode.P))
            {

            }
        }
    }
}
