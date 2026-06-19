using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] groundPrefabs; //lista de pisos que pueden aparecer

    //Al detectar colision de tipo trigger 
    void OnTriggerEnter2D(Collider2D other){

        //mueve el generador
        transform.position = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);

        
        //obtiene indice aleatorio del tamaño de la lista de pisos
        int randomIndex = Random.Range(0, groundPrefabs.Length);

        // Crea una instancia del objeto a partir de la prefab en la posición del objeto vacío
        Instantiate(groundPrefabs[randomIndex], transform.position, Quaternion.identity);

    }
   
}
