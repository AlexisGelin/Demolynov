using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 50f;
    public int IDPlayer;
    public GameObject mesh;

    void Update()
    {
        if (IDPlayer == 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                mesh.transform.DORotate(new Vector3(0, 0, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                mesh.transform.DORotate(new Vector3(0, -90, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                mesh.transform.DORotate(new Vector3(0, 180, 0), 1f).SetEase(Ease.OutQuart);
                rb.transform.position = transform.position + Vector3.back * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                mesh.transform.DORotate(new Vector3(0, 90, 0), 1f).SetEase(Ease.OutQuart);
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
