using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private float exponente = 1;
    private float crecimiento = 1;
    public Text expo;
    public Text creci;

    public GameObject colorExpo;
    public GameObject colorCreci;

    public delegate void ChangeValues(float exponente, float crecimiento);
    public static event ChangeValues _changeValues;

    Image exp;
    Image cre;

    void Start()
    {
        exp = colorExpo.GetComponent<Image>();
        cre = colorCreci.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        expo.text = "Exponente : " + exponente;
        creci.text = "Crecimiento: " + crecimiento;
        evaluarExpo();
        evaluarCreci();
    }

    private void evaluarCreci()
    {
        if (crecimiento > 2 && crecimiento < 5)
        {
            cre.color = Color.red;
        }
        else if (crecimiento > 5)
        {
            cre.color = Color.green;
        }
        else
        {
            cre.color = new Color32(0, 140, 255, 255);
        }
    }

    private void evaluarExpo()
    {
        if (exponente > 2 && exponente < 5)
        {
            exp.color = Color.red;
        }
        else if (exponente > 5)
        {
            exp.color = Color.green;
        }
        else {
            exp.color = new Color32(0,140,255,255);
        }
    }

    public void TraerExponente(float valor) {
        exponente = valor;
    }
    public void TraerCrecimiento(float valor)
    {
        crecimiento = valor;
    }

    public void aplicarCambios() {
        _changeValues?.Invoke(exponente, crecimiento);
    }
}
