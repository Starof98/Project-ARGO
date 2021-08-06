using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject punkbutton;
    [SerializeField] GameObject melebutton;
    [SerializeField] GameObject punkie;
    [SerializeField] GameObject melenas;
    [SerializeField] GameObject backbutton;

    [SerializeField] GameObject sanic;
    [SerializeField] GameObject sanicButton;
    [SerializeField] GameObject pulpo;
    [SerializeField] GameObject pulpoButton;
    [SerializeField] GameObject daemon;
    [SerializeField] GameObject daemonButton;


    public void changerON()
    {
        melebutton.SetActive(false);
        punkbutton.SetActive(true);
        backbutton.SetActive(true);
        pulpoButton.SetActive(true);
    }

    public void demonio()
    {
        pulpo.SetActive(false);
        sanic.SetActive(false);
        pulpoButton.SetActive(true);
        sanicButton.SetActive(false);
        daemon.SetActive(true);
        daemonButton.SetActive(false);
    }

    public void punkye()
    {
        melenas.SetActive(false);
        punkie.SetActive(true);
        punkbutton.SetActive(false);
        melebutton.SetActive(true);
    }

    public void pelazo()
    {
        melenas.SetActive(true);
        punkie.SetActive(false);
        punkbutton.SetActive(true);
        melebutton.SetActive(false);
    }

    public void pulpin()
    {
        daemon.SetActive(false);
        pulpo.SetActive(true);
        sanic.SetActive(false);
        pulpoButton.SetActive(false);
        sanicButton.SetActive(true);
    }

    public void Sonic()
    {
        pulpo.SetActive(false);
        sanic.SetActive(true);
        daemon.SetActive(false);
        pulpoButton.SetActive(false);
        sanicButton.SetActive(false);
        daemonButton.SetActive(true);
    }

    public void changerOff()
    {
        melebutton.SetActive(false);
        punkbutton.SetActive(false);
        backbutton.SetActive(false);
        sanicButton.SetActive(false);
        pulpoButton.SetActive(false);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
