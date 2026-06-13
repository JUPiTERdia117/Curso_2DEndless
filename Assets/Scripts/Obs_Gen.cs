using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Gen : MonoBehaviour
{

    public GameObject[] obsPrefabs;

     

    void Awake(){

        int randomIndex = Random.Range(0, obsPrefabs.Length);

        Instantiate(obsPrefabs[randomIndex], new Vector3(transform.position.x , transform.position.y +1 , transform.position.z), Quaternion.identity);
    }
}
