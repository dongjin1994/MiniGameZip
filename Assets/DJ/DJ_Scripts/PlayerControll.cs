using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{  
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Finish"))
        {
            Debug.Log("아앗..");
            GameManager.instance.GameOver();
        }
    }
}
