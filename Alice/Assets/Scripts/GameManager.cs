using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    public bool start;
    public bool dentroPorta1;
    public bool dentroPorta2;
    public bool dentroPorta3;
    public bool fuoriPorta1;
    public bool monocoloYPreso;
    public bool monocoloZPreso;
    public bool vedoMonocoloY;
    public bool vedoMonocoloZ;

    public bool lHoPreso;
    
    public GameObject buttonMonocoloY;
    public GameObject buttonMonocoloZ;

    public GameObject triggerPorta1;
    public GameObject triggerPorta2;
    public GameObject triggerPorta3;
    public GameObject triggerFuoriPorta1;
    public GameObject triggerFuoriPorta2;
    public GameObject triggerFuoriPorta3;
    
    //Plane con Shader che ti permette di vedere alcune cose
    public GameObject filtroY;
    public GameObject filtroZ;
    
    public GameObject porta;
    public Transform portaTransform;
    public GameObject cadavere;
    public Transform cadavereTransform;
    public GameObject alice;
    public Transform aliceTransform;

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
    public AudioSource sequenzaFinale;
    
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
            alice.transform.position = aliceTransform.position;
            alice.gameObject.SetActive(true);
            StartCoroutine(Sequenza5());
            five++;
        }
    }

    #region Sequenza1

    IEnumerator Sequenza1()
    {
        yield return new WaitForSeconds(5f);
        
        sequenza1.transform.position = player.transform.position;
        sequenza1.gameObject.SetActive(true);

        yield return new WaitForSeconds(15f); 
        
        porta.transform.position = portaTransform.position;
        porta.SetActive(true);
        triggerPorta1.SetActive(true);
        
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
        
        cadavere.transform.position = cadavereTransform.position;
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
        yield return new WaitForSeconds(1f);
    }

    #endregion

    #region Sequenza7

    IEnumerator Sequenza7()
    {
        //Parte quando esci dalla porta 2
        yield return new WaitForSeconds(1f);
    }

    #endregion

    #region SequenzaSoldi

    IEnumerator SequenzaSoldi()
    {
        //Parte quando esamini i soldi 
        yield return new WaitForSeconds(1f);
    }

    #endregion
    
    #region SequenzaFoto

    IEnumerator SequenzaFoto()
    {
        //Parte quando esamini le foto
        yield return new WaitForSeconds(1f);
    }

    #endregion
    
    #region SequenzaFinale

    IEnumerator Fine()
    {
        //Parte quando esci dalla porta 3
        yield return new WaitForSeconds(1f);
        
        //se soldi un audio se foto un altro 
    }

    #endregion

    public void Prendilo()
    {
        lHoPreso = true;
    }
    
    public void MonocoloY ()
    {
        filtroY.SetActive(true);
        vedoMonocoloY = true;
    }
    
    public void MonocoloYOff ()
    {
        filtroY.SetActive(false);
        vedoMonocoloY = false;
    }
   
    public void MonocoloZ ()
    {
        filtroZ.SetActive(true);
        vedoMonocoloZ = true;
    }

    public void MonocoloZOff ()
    {
        filtroZ.SetActive(false);
        vedoMonocoloZ = false;
    }
}
