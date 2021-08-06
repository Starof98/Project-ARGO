using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBehaviour : MonoBehaviour
{

    [SerializeField] GameObject[] UI;
    [SerializeField] GameObject malo;
    [SerializeField] GameObject[] heroes;
    public int selec;
    void Start()
    {
        selec = 0;
        UI[0].SetActive(true);
        UI[1].SetActive(false);
        UI[2].SetActive(false);
        UI[3].SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ChangeUi()
    {
        UI[selec].SetActive(false);
        selec++;
        if(heroes[selec].GetComponent<Heroe>().vida <= 0)
        {
            selec++;
        }
        UI[selec].SetActive(true);
        if(selec > 3)
        {

            selec = 0;
            UI[0].SetActive(true);
            UI[1].SetActive(false);
            UI[2].SetActive(false);
            UI[3].SetActive(false);
            malo.GetComponent<Enemigo>().stop = false;
            malo.GetComponent<Enemigo>().numeroataque = 0;
            malo.GetComponent<Enemigo>().start();
        }
    }


}
