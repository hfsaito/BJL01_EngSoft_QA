using System;
using UnityEngine;

public class InterativoTutorial : Interativo
{

    private GameObject tutorial;

    void Start()
    {
       tutorial = GetComponentInChildren<Canvas>(true).transform.gameObject;
    }

    public override void AcaoEntrada()
    {
        tutorial.SetActive(true);
    }
    
    public override void AcaoSaida()
    {
        tutorial.SetActive(false);
    }
}
