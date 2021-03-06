﻿//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CelController : MonoBehaviour
{
    public delegate void OnDivision(string data); //declaracion del delgate
    public static event OnDivision _onDivision; // declaracion del evento

    float rv = 0;
    public GameObject celular;
    Clock cl;
    float tamaño;
    float tim = 0;
    float crecimiento = 0;
    bool divi = true;
    public float creci = 0.3f;   
    float F=0;
    public float beta = 0.1f;
    private float k = 0.005f;
    public float inicial = 0;
    int asignacion = 0;
    public String tipo = "Madre";
    void Start()
    {
        
        inicial = transform.localScale.y;
        Observer._onRevaluated += ReEstart; //subcripcion al evento
        UiController._changeValues += ChangeParams; //subcripcion al evento
        cl = GameObject.FindGameObjectWithTag("reloj").GetComponent<Clock>();
        rv = UnityEngine.Random.Range(0.0f , 1.0f);
        tamaño = transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        crecimiento = (creci * transform.localScale.y) * Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + crecimiento, transform.localScale.z);
        tim += Time.deltaTime;
        
        if (tim >= 1) {
            control();
            tim = 0;
        }
        
    }

    private void control()
    {
        F = F + (1 - F) * (Mathf.Pow(transform.localScale.y, beta)) * k;
        
        //Debug.Log(F + "de la celula" +  transform.name);

        if (F >= rv)
        {
            divi = true;
            if (divi)
            {
                division();
            }
        }
    }

    void division()
    {           
        divi = false;
        crecimiento = 0;
        //Debug.Log("Tamaño Celula: " + transform.localScale.y);
        //Debug.Log("Posicion: " + transform.position.y);
        float medida = transform.localScale.y;        
        float pos = transform.position.y;
        float res = medida/2;
        float resultado = pos + res;
        float resultado1 = pos - res;
        //Debug.Log("posicion 1" + resultado);
        //Debug.Log("posicion 2" + resultado1);
        celular.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        this.transform.position = new Vector3(transform.position.x, resultado1 , transform.position.z);
        this.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        GameObject celHija = Instantiate(celular, new Vector3(transform.position.x, resultado , transform.position.z), transform.rotation);
        celHija.GetComponent<CelController>().setTipo("Hija");
        celHija.transform.name = asignacion + " hija de : " + this.transform.name;
       
        

        //Debug.Log("Tamaño Celula madre: " + transform.localScale.y);
        //Debug.Log("Posicion madre: " + transform.position.y);
        //Debug.Log("Tamaño Celula hija: " + celHija.transform.localScale.y);
        //Debug.Log("Posicion hija: " + celHija.transform.position.y);
        string tiempo = cl.darTiempo();
        string data = "Tiempo | " + tiempo +"$ tamaño de "+transform.name +" : " + medida + "$ Tamaño inicial: " + inicial + "$Tipo:" + tipo;
        //Debug.Log(data);
        _onDivision?.Invoke(data); // notifica a los subcriptores
        asignacion++;
    }

    void ReEstart() {
        F = 0;
        rv = Random.Range(0.0f, 1.0f);
        //Debug.Log("Yo " + transform.name + " Reinicie mis valores");
    }

    void ChangeParams(float expo, float creci) {
        Debug.Log(expo + " " + creci );
        this.beta = expo;
        this.k = creci;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tapa"))
        {
            Observer._onRevaluated-= ReEstart; //remueve el objeto de donde estaba subcrito
            Destroy(gameObject);
        }
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }
        
}
