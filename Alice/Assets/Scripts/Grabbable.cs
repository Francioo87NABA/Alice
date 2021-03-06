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

    public GameObject togliColtello;
    public GameObject togliMestolo;
    public GameObject togliSoldi;
    public GameObject togliFoto;
    
    
    
    public GameObject bottonePrendi;
    public GameObject bottoneEsamina;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (foto && GameManager.Singleton.esaminoFoto && GameManager.Singleton.esaminoSoldi ||
                soldi && GameManager.Singleton.esaminoFoto && GameManager.Singleton.esaminoSoldi)
            {
                bottonePrendi.SetActive(true);
            }
            
            if (GameManager.Singleton.lHoPreso && monocoloY)
            {
                GameManager.Singleton.monocoloYPreso = true;
                transform.gameObject.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
                bottonePrendi.SetActive(false);
            }

            if (GameManager.Singleton.lHoPreso && monocoloZ)
            {
                GameManager.Singleton.monocoloZPreso = true;
                transform.gameObject.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
                bottonePrendi.SetActive(false);
            }
            
            if (GameManager.Singleton.lHoPreso && coltello)
            {
                GameManager.Singleton.coltelloPreso = true;
                transform.gameObject.SetActive(false);
                togliMestolo.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
                bottonePrendi.SetActive(false);
            }
            
            if (GameManager.Singleton.lHoPreso && mestolo)
            {
                GameManager.Singleton.mestoloPreso = true;
                transform.gameObject.SetActive(false);
                togliColtello.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
                bottonePrendi.SetActive(false);
            }

            if (GameManager.Singleton.stoEsaminando && foto)
            {
                GameManager.Singleton.esaminoFoto = true;
                GameManager.Singleton.stoEsaminando = false;
                bottoneEsamina.SetActive(false);

            }
            
            if (GameManager.Singleton.stoEsaminando && soldi)
            {
                GameManager.Singleton.esaminoSoldi = true;
                GameManager.Singleton.stoEsaminando = false;
                bottoneEsamina.SetActive(false);
            }
            
            if (GameManager.Singleton.lHoPreso && soldi)
            {
                GameManager.Singleton.soldiPresi = true;
                transform.gameObject.SetActive(false);
                togliFoto.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
                bottonePrendi.SetActive(false);
            }
            
            if (GameManager.Singleton.lHoPreso && foto)
            {
                GameManager.Singleton.fotoPrese = true;
                transform.gameObject.SetActive(false);
                togliSoldi.SetActive(false);
                GameManager.Singleton.lHoPreso = false;
                bottonePrendi.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (monocoloY || monocoloZ)
            {
                bottonePrendi.SetActive(true);
            }

            if (coltello && GameManager.Singleton.coltelloVisto && GameManager.Singleton.mestoloVisto ||
                mestolo && GameManager.Singleton.coltelloVisto && GameManager.Singleton.mestoloVisto)
            {
                bottonePrendi.SetActive(true);
            }
            
            if (soldi && !GameManager.Singleton.esaminoSoldi || foto && !GameManager.Singleton.esaminoFoto)
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
