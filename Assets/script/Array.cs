using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    public GameObject[] coinObject;

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "player"){
            for(int i = 0 ; i < coinObject.Length;i++){
                Debug.Log(i);
                coinObject[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}