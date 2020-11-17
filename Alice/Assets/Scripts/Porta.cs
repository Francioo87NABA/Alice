using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{

    public bool porta1;
    public bool porta2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (porta1)
            {
                GameManager.Singleton.dentroPorta1 = true;
            }
            else if (porta2)
            {
                
            }
            else
            {
                
            }
        }
       
    }
}
