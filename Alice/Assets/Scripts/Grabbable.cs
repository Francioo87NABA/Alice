﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool preso;
    public bool monocoloY;
    public bool monocoloZ;
    public bool mestolo;
    public bool coltello;
    public bool soldi;
    public bool foto;

    public GameObject bottonePrendi;
    public GameObject bottoneEsamina;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Singleton.lHoPreso && monocoloY)
            {
                GameManager.Singleton.monocoloYPreso = true;
                transform.gameObject.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
            }

            if (GameManager.Singleton.lHoPreso && monocoloZ)
            {
                GameManager.Singleton.monocoloZPreso = true;
                transform.gameObject.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bottonePrendi.SetActive(true);

            if (soldi || foto)
            {
                bottoneEsamina.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bottonePrendi.SetActive(false);
            
            if (soldi || foto)
            {
                bottoneEsamina.SetActive(false);
            }
        }
    }
}