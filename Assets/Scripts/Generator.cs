using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] groundPrefabs;

    void OnTriggerEnter2D(Collider2D other){

        transform.position = new Vector2(transform.position.x + 20, transform.position.y);

        // Crea una instancia del objeto a partir de la prefab en la posición del objeto vacío

        int randomIndex = Random.Range(0, groundPrefabs.Length);

        Instantiate(groundPrefabs[randomIndex], transform.position, Quaternion.identity);

    }
   
}
