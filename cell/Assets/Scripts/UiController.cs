using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private float exponente = 0;
    public Text expo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expo.text = "Exponente : " + exponente;
    }

    public void traerExponente(float valor) {
        exponente = valor;
    }
}
