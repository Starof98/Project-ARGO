using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArStart : MonoBehaviour
{

    [SerializeField] GameObject daemon;
    [SerializeField] GameObject pulpo;
    [SerializeField] GameObject sanic;
    [SerializeField] GameObject calvo;
    [SerializeField] GameObject melenas;
    [SerializeField] GameObject mamadisimo;
    [SerializeField] GameObject planti;
    [SerializeField] GameObject señora;
    [SerializeField] GameObject particulas1;
    [SerializeField] GameObject canva;
    [SerializeField] GameObject[] particulas2;
    
   
    void Start()
    {
        daemon.SetActive(false);
        pulpo.SetActive(false);
        pulpo.SetActive(false);
        calvo.SetActive(true);
        melenas.SetActive(true);
        planti.SetActive(true);
        señora.SetActive(true);
        mamadisimo.SetActive(false);
        particulas1.SetActive(true);
        canva.SetActive(true);
        for (int i = 0; i < particulas2.Length; i++)
        {
            particulas2[i].SetActive(true);
        }
        canva.SetActive(true);
    }


}
