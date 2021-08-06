using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 9000;
    [SerializeField] private int dañoMinimo = 1000;
    [SerializeField] private int dañoMaximo = 2000;
    public bool stop = false;
    public int numeroataque = 0;
    public int damage;
    [SerializeField] private GameObject[] heroes;


    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void start()
    {
        int tipo = Random.Range(1, 5);
        if (numeroataque >= 3)
        {
            stop = true;
        }
        numeroataque++;
        if (tipo == 5)
        {
            Especial();

        }
        else if (tipo < 5)
        {
            Ataque();
        }


        
    }


    private void Ataque()
    {
        int seleccionado = Random.Range(0, 3);
        damage = Random.Range(dañoMinimo, dañoMaximo);
        if (heroes[seleccionado].GetComponent<Heroe>().protect == true)
        {
            damage = damage / 2;
        }
        heroes[seleccionado].GetComponent<Heroe>().vida -= damage;
        if (stop == false)
        {
            start();
        }
    }

    private void Especial()
    {
        int seleccionado = Random.Range(0, 3);
        damage = Random.Range(dañoMinimo, dañoMaximo) + 1000;
        if(heroes[seleccionado].GetComponent<Heroe>().protect == true)
        {
            damage = damage / 2;
        }
        heroes[seleccionado].GetComponent<Heroe>().vida -= damage;
        if (stop == false)
        {
            start();
        }
    }
}
