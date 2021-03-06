﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Observer : MonoBehaviour
{
    public delegate void OnRevaluated();
    public static event OnRevaluated _onRevaluated;

    private List<string> datos = new List<string>();
    private List<string> madres = new List<string>();
    void Start()
    {
        CelController._onDivision += ReEstart; //subcripcion a un evento 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReEstart(string data) {
        //Debug.Log(data);
        //Debug.Log("Alguien se dividio");
        guardarDocumento(data);
        _onRevaluated?.Invoke();     // le dice a todos los subcriptores que a ocurrido algo el notify   
    }

   

    void guardarDocumento(string data) {
        datos.Add(data);
        using (StreamWriter outputFile = new StreamWriter(Application.persistentDataPath + "/Datos1.txt")) {
            foreach (string linea in datos)
            {
                outputFile.WriteLine(linea);
            }
        }
    }

    public void GenerarInforme() {
        ContextStrategy cs = new ContextStrategy(new Madres());
        madres = cs.SepararMadres(datos);
        using (StreamWriter outputFile = new StreamWriter(@"C:\Users\Jeison\Desktop\" + "Madres.txt"))
        {
            foreach (string linea in madres)
            {
                outputFile.WriteLine(linea);
            }
        }
    }
}
