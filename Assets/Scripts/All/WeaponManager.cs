using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    bool waitingForSpawn = false;
    [SerializeField] float randomTime;
    [SerializeField] int weaponIDToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (!waitingForSpawn)
        {
            weaponIDToSpawn = Random.Range(0, weapons.Length);
            waitingForSpawn = true;
            randomTime = Random.Range(15, 20);
            StartCoroutine(SpawnTimer(weapons[weaponIDToSpawn], randomTime));
        }
    }

    IEnumerator SpawnTimer(GameObject weaponToSpawn, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //initialiser le spawn ici 
        weaponToSpawn = Instantiate(weaponToSpawn, new Vector3(0,0,0), new Quaternion(0,0,0,0));


        waitingForSpawn = false; //relancer le délai de spawn
    }
}
