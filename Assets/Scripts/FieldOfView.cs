using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public List<Transform> targets = new();
    public List<GameObject> players = new();

    public LayerMask targetMask;
    public LayerMask obstructionMask;
    


    public bool canSeePlayer;

    private void Start()
    {
        StartCoroutine(FOVRoutine());

    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.05f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        //Debug.Log("Check");

        if (rangeChecks.Length != 0)
        {
            foreach(Collider c in rangeChecks)
            {
                AddPlayerToList(c.gameObject);
                AddTargetToList(c.transform);

                Vector3 directionToTarget = (c.transform.position - transform.position).normalized;
                float distanceToTarget = Vector3.Distance(transform.position, c.transform.position);

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        canSeePlayer = true;
                        c.gameObject.transform.parent.gameObject.GetComponent<PlayerData>().speed = 5f;
                    }
                    else
                    {
                        canSeePlayer = false;
                    }
                }
                else 
                {
                    canSeePlayer = false;

                }

                if (distanceToTarget > radius)
                {
                    canSeePlayer = false;
                    RemovePlayerFromList(c.gameObject);
                    c.gameObject.transform.parent.gameObject.GetComponent<PlayerData>().speed = 10f;
                    RemoveTargetFromList(c.transform);
                }
                
            }
            
        }
        else if(canSeePlayer){ canSeePlayer = false; }
        else{ players.Clear(); targets.Clear();}
    }

    /*private void OnTriggerExit(Collider player)
    {
        player.GetComponent<PlayerController>().speed = 10f;
        RemovePlayerFromList(player.gameObject);
        RemoveTargetFromList(player.transform);
    }*/

    void AddPlayerToList(GameObject player)
    {
        if (!players.Contains(player))
        {
            players.Add(player);
        }
    }

    void AddTargetToList(Transform target)
    {
        if (!targets.Contains(target))
        {
            targets.Add(target);
        }
    }

    void RemovePlayerFromList(GameObject player)
    {
        if (players.Contains(player)) 
        {
            players.Remove(player);
        }
    }


    void RemoveTargetFromList(Transform target)
    {
        if (targets.Contains(target))
        {
            targets.Remove(target);
        }
    }
}
