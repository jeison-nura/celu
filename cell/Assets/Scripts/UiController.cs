﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private float exponente = 1;
    private float crecimiento = 1;
    private float k = 0;

    private float ritmoTiempo = 1;
    private float aux = 1;
    List<int> valores;

    public Text expo;
    public Text creci;
    public Text contadorTiempo;

    public GameObject colorExpo;
    public GameObject colorCreci;

    public delegate void ChangeValues(float exponente, float crecimiento); //declaracion del delegate para el event
    public static event ChangeValues _changeValues; //Evento al que se suscriben las otras clases Observer

    private ContextState mContestState = new ContextState();

    Image exp;
    Image cre;

    void Start()
    {
        //evaluarCreci();
        //evaluarExpo();
        contadorTiempo.text = "1";
        exp = colorExpo.GetComponent<Image>();
        cre = colorCreci.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        expo.text = "Exponente : " + exponente.ToString("F2");
        creci.text = "Crecimiento: " + crecimiento.ToString("F3");
        evaluarExpo();
        evaluarCreci();
        Time.timeScale = ritmoTiempo;
    }

    private void evaluarCreci()
    {
        if (crecimiento >  0 && crecimiento < 0.8)
        {
            cre.color = new Color32(0, 140, 255, 255);
        }
        else if (crecimiento > 0.8 && crecimiento < 1.3)
        {
            cre.color = Color.green;
        }
        else
        {
            cre.color = Color.red;
        }
    }       
    

    private void evaluarExpo()
    {
        if (exponente > 0 && exponente < 0.8)
        {
            exp.color = new Color32(0, 140, 255, 255); ;
        }
        else if (exponente > 0.8 && exponente < 1.3)
        {
            exp.color = Color.green;
        }
        else {
            exp.color = Color.red;
        }
    }

    public void TraerExponente(float valor) {
        exponente = valor;
        //buscarK();

    }

    private void buscarK()
    {
       
    }

    public void TraerCrecimiento(float valor)
    {
        crecimiento = valor;
        //traerLista(crecimiento);
    }

    private void traerLista(float crecimiento)
    {
        switch ((int)crecimiento) {
            case 1:
                mContestState.setContext(new TamañoTipico1());
                break;
        }
        valores = mContestState.request();
    }

    public void aplicarCambios() {
        _changeValues?.Invoke(exponente, crecimiento);
    }

    public void agregarTiempo(){
        if( ritmoTiempo == 5 ){
            ritmoTiempo = 5;
        }else{
            ritmoTiempo += 1;
        }
        contadorTiempo.text = ritmoTiempo+"";
    }
    public void pausarTiempo(){
        aux = ritmoTiempo;
        ritmoTiempo = 0;
        contadorTiempo.text = ritmoTiempo+"";
    }
    public void reanudarTiempo(){
        ritmoTiempo = aux;
        contadorTiempo.text = ritmoTiempo+"";
    }
    public void disminuirTiempo(){
        if( ritmoTiempo == 0 ){
            ritmoTiempo = 0;
        }else{
            ritmoTiempo -= 1;
        }
        contadorTiempo.text = ritmoTiempo+"";
    } 
    
}
