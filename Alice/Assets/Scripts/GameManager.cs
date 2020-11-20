using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    
    public bool start;
    
    public bool dentroPorta1;
    public bool fuoriPorta1;
    public bool fuoriPorta2;
    public bool fuoriPorta3;
    
    public bool monocoloYPreso;
    public bool monocoloZPreso;
    public bool coltelloPreso;
    public bool mestoloPreso;
    public bool soldiPresi;
    public bool fotoPrese;
    
    public bool vedoMonocoloY;
    public bool vedoMonocoloZ;
    public bool esaminoSoldi;
    public bool esaminoFoto;
    
    public bool stoEsaminando;
    public bool lHoPreso;
    
    
    public GameObject buttonMonocoloY;
    public GameObject buttonMonocoloZ;

    public GameObject triggerPorta1;
    public GameObject triggerPorta2;
    public GameObject triggerPorta3;
    public GameObject triggerFuoriPorta1;
    public GameObject triggerFuoriPorta2;
    public GameObject triggerFuoriPorta3;

    public GameObject portaleMondo1;
    public GameObject portaleMondo2;
    public GameObject portaleMondo3;

    public GameObject porta;
    public GameObject mondo1;
    public GameObject mondo2;
    public GameObject mondo3;
    public GameObject cadavere;
    public GameObject alice;
    public GameObject armaColtello;
    public GameObject armaMestolo;

    public GameObject player;
    
    
    public AudioSource sequenza1;
    public AudioSource sequenza2;
    public AudioSource sequenza3;
    public AudioSource sequenza4;
    public AudioSource sequenza5;
    public AudioSource sequenza6;
    public AudioSource sequenza7;
    public AudioSource sequenzaSoldi;
    public AudioSource sequenzaFoto;
    public AudioSource sequenzaParadiso;
    public AudioSource sequenzaInferno;
    
    
    private Animator animatorPorta;
    
    
    private int one;
    private int two;
    private int three;
    private int four;
    private int five;
    private int six;
    private int seven;
    private int eight;
    private int nine;
    private int ten;
    
    
    private void OnEnable()
    {
        Singleton = this;
    }

    void Start()
    {
        animatorPorta = porta.GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (one == 0 && start)
        {
            StartCoroutine(Sequenza1());
            one++;
        }

        if (two == 0 && dentroPorta1)
        {
            StartCoroutine(Sequenza2());
            two++;
        }

        if (three == 0 && monocoloYPreso && monocoloZPreso)
        {
            StartCoroutine(Sequenza3());
            three++;
        }

        if (four == 0 && fuoriPorta1)
        {
            StartCoroutine(Sequenza4());
            four++;
        }

        if (five == 0 && vedoMonocoloY || vedoMonocoloZ)
        {
            alice.gameObject.SetActive(true);
            StartCoroutine(Sequenza5());
            five++;
        }

        if (six == 0 && coltelloPreso || mestoloPreso)
        {
            StartCoroutine(Sequenza6());
            six++;
        }

        if (seven == 0 && fuoriPorta2 && coltelloPreso || mestoloPreso)
        {
            StartCoroutine(Sequenza7());
        }

        if (eight == 0 && esaminoFoto)
        {
            StartCoroutine(SequenzaFoto());
            eight++;
        }

        if (nine == 0 && esaminoSoldi)
        {
            StartCoroutine(SequenzaSoldi());
            nine++;
        }

        if (ten == 0 && fuoriPorta3 && soldiPresi || fotoPrese)
        {
            StartCoroutine(SequenzaFinale());
            ten++;
        }
    }

    #region Sequenza1

    IEnumerator Sequenza1()
    {
        //parte allo start
        
        yield return new WaitForSeconds(5f);
        
        sequenza1.transform.position = player.transform.position;
        sequenza1.gameObject.SetActive(true);

        yield return new WaitForSeconds(15f); 
        
        porta.SetActive(true);

        yield return new WaitForSeconds(5f);
        
        animatorPorta.SetBool("Apriti",true);
    }
    
    #endregion

    #region Sequenza2

    IEnumerator Sequenza2()
    {
        //parte quando si entra dentro la porta1
        
        sequenza2.transform.position = player.transform.position;
        sequenza2.gameObject.SetActive((true));

        yield return new WaitForSeconds(5f);
        
        animatorPorta.SetBool("Apriti", false);
        
        triggerPorta1.SetActive(false);
    }
    
    #endregion

    #region Sequenza3

    IEnumerator Sequenza3()
    {
        //Parte quando vengono raccolti i due monocoli 
        
        sequenza3.transform.position = player.transform.position;
        sequenza3.gameObject.SetActive(true);
        
        triggerFuoriPorta1.SetActive(true);
        
        cadavere.SetActive(true);

        yield return new WaitForSeconds(10f);
        
        animatorPorta.SetBool("Apriti",true);
    }
    
    #endregion

    #region Sequenza4
    
    IEnumerator Sequenza4()
    {
        //Parte quando esci dalla porta1 e vedi il tuo cadavere

        sequenza4.transform.position = player.transform.position;
        sequenza4.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        
        animatorPorta.SetBool("Apriti", false);
        
        mondo1.SetActive(false);
        portaleMondo1.SetActive(false);
        mondo2.SetActive(true);
        portaleMondo2.SetActive(true);
        
        yield return new WaitForSeconds(28f);

        buttonMonocoloY.SetActive(true);
        buttonMonocoloZ.SetActive(true);
    }

    #endregion

    #region Sequenza5

    IEnumerator Sequenza5()
    {
        // parte quando vedi alice 
        
        sequenza5.transform.position = player.transform.position;
        sequenza5.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(25f);
        
        animatorPorta.SetBool("Apriti",true);
    }
    
    #endregion

    #region Sequenza6

    IEnumerator Sequenza6()
    {
        //Parte quando prendi o il coltello o il mestolo 
        
        sequenza6.transform.position = player.transform.position;
        sequenza6.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        
        triggerFuoriPorta1.SetActive(false);
        triggerFuoriPorta2.SetActive(true);

        if (coltelloPreso)
        {
            armaColtello.SetActive(true);
        }
        else
        {
            armaMestolo.SetActive(true);
        }
    }

    #endregion

    #region Sequenza7

    IEnumerator Sequenza7()
    {
        //Parte quando esci dalla porta 2
        
        sequenza7.transform.position = player.transform.position;
        sequenza7.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        
        animatorPorta.SetBool("Apriti", false);
        
        portaleMondo2.SetActive(false);
        mondo2.SetActive(false);
        portaleMondo3.SetActive(true);
        mondo3.SetActive(true);
        
        yield return new WaitForSeconds(25f);
        
        animatorPorta.SetBool("Apriti", true);
        
    }

    #endregion

    #region SequenzaSoldi

    IEnumerator SequenzaSoldi()
    {
        //Parte quando esamini i soldi 
        
        sequenzaSoldi.transform.position = player.transform.position;
        sequenzaSoldi.gameObject.SetActive(true);
        
        triggerFuoriPorta2.SetActive(false);
        triggerFuoriPorta3.SetActive(true);
        
        yield return new WaitForSeconds(1f);
    }

    #endregion
    
    #region SequenzaFoto

    IEnumerator SequenzaFoto()
    {
        //Parte quando esamini le foto
        
        sequenzaFoto.transform.position = player.transform.position;
        sequenzaFoto.gameObject.SetActive(true);
        
        triggerFuoriPorta2.SetActive(false);
        triggerFuoriPorta3.SetActive(true);
        
        yield return new WaitForSeconds(1f);
    }

    #endregion
    
    #region SequenzaFinale

    IEnumerator SequenzaFinale()
    {
        //Parte quando esci dalla porta 3 e hai preso o soldi o foto
        
        yield return new WaitForSeconds(4f);

        if (soldiPresi)
        {
            sequenzaInferno.transform.position = player.transform.position;
            sequenzaInferno.gameObject.SetActive(true);
        }
        else
        {
            sequenzaParadiso.transform.position = player.transform.position;
            sequenzaParadiso.gameObject.SetActive(true);
        }
    }

    #endregion

    public void Prendilo()
    {
        lHoPreso = true;
    }
    
    public void Esaminalo()
    {
        stoEsaminando = true;
    }
    
    public void MonocoloY ()
    {
        vedoMonocoloY = true;
    }
    
    public void MonocoloYOff ()
    {
        vedoMonocoloY = false;
    }
   
    public void MonocoloZ ()
    {
        vedoMonocoloZ = true;
    }

    public void MonocoloZOff ()
    {
        vedoMonocoloZ = false;
    }
}
