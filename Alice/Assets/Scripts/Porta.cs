using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public bool porta1;
    public bool porta2;
    public bool porta3;
    public bool fuoriPorta1;
    public bool fuoriPorta2;
    public bool fuoriPorta3;

    public GameObject filtroCameraMondo1;
    public GameObject filtroCameraMondo2;
    public GameObject filtroCameraMondo3;

    private int one;
    private int two;
    private int trhee;
    private int four;
    private int five;
    private int six;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (one == 0 && porta1)
            {
                GameManager.Singleton.dentroPorta1 = true;
                filtroCameraMondo1.SetActive(true);
                one++;
            }
            else if (two == 0 && porta2)
            {
                GameManager.Singleton.dentroPorta2 = true;
                filtroCameraMondo2.SetActive(true);
                two++;
            }
            else if (trhee == 0 && porta3)
            {
                filtroCameraMondo3.SetActive(true);
                trhee++;
            }
            else if (four == 0 && fuoriPorta1)
            {
                GameManager.Singleton.fuoriPorta1 = true;
                filtroCameraMondo1.SetActive(false);
                four++;
            }
            else if (five == 0 && fuoriPorta2)
            {
                GameManager.Singleton.fuoriPorta2 = true;
                filtroCameraMondo2.SetActive(false);
                five++;
            }
            else if (six == 0 && fuoriPorta3)
            {
                GameManager.Singleton.fuoriPorta3 = true;
                filtroCameraMondo3.SetActive(false);
                six++;
            }
        }
       
    }
}
