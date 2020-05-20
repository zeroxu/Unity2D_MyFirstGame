using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public GameObject soundOb;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.name);
        if(other.name == "player"){
        Instantiate(soundOb,transform.position,Quaternion.identity);
        Destroy(gameObject);
        }
    }
}
