using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Heroe : MonoBehaviour
{
    public int vida = 5000;
    [SerializeField] GameObject master;
    [SerializeField] GameObject Enemigo;
    [SerializeField] int hero;
    [SerializeField] Text hP;
    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem[] particles2;
    private int dañoMionimo = 1000;
    private int dañoManimo = 2000;
    public bool protect;
    public bool muerto;
    private float timer;

    void Start()
    {
        protect = false;
        muerto = false;
        timer = 0;
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if(vida <= 0)
        {
            vida = 0;
            muerto = true;
            
        }

        if(vida > 5000)
        {
            vida = 50000;
        }
       
        if (timer >= 5)
        {
            particles.Stop();
            timer = 0;
            for (int i = 0; i < particles2.Length; i++)
            {
                particles2[i].Stop();
            }
        }

        hP.text = vida.ToString();
    }

    public void Ataque()
    {
        Enemigo.GetComponent<Enemigo>().vida -= Random.Range(dañoMionimo, dañoManimo);
        master.GetComponent<TurnBehaviour>().ChangeUi();
    }

    public void Defense()
    {
        protect = true;
        master.GetComponent<TurnBehaviour>().ChangeUi();
    }

    
    public void Magia1()
    {
        Enemigo.GetComponent<Enemigo>().vida -= Random.Range(dañoMionimo, dañoManimo) *2;
        particles.transform.position = transform.position;
        timer = 0;
        particles.Play();
        master.GetComponent<TurnBehaviour>().ChangeUi();
    }
    public void Magia2()
    {
        GameObject[] Heroes = GameObject.FindGameObjectsWithTag("bueno");
        for (int i = 0; i < Heroes.Length; i++ )
        {
            Heroes[i].GetComponent<Heroe>().vida += Random.Range(dañoMionimo, dañoManimo);
        }
        for(int i = 0; i < particles2.Length; i++)
        {
            particles2[i].Play();
            timer = 0;
        }
        master.GetComponent<TurnBehaviour>().ChangeUi();
    }
}
