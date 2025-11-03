using System;
using UnityEngine;

public class Interativo : MonoBehaviour
{
    
    private bool playerInArea = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInArea)
        {
            Acao();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerInArea = true;
            AcaoEntrada();
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerInArea = false;
            AcaoSaida();
        }
    }

    virtual public void AcaoEntrada()
    {
        
    }
    
    virtual public void AcaoSaida()
    {
        
    }

    virtual public void Acao()
    {
        
    }
}
