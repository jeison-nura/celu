using System.Collections;
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
    void Start()
    {
        CelController._onDivision += ReEstart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReEstart(string data) {
        //Debug.Log(data);
        //Debug.Log("Alguien se dividio");
        guardarDocumento(data);
        _onRevaluated?.Invoke();
        darDatos();
    }

    private void darDatos()
    {
        foreach (string dat in datos){
            string []elementos = dat.Split('$');
            for (int i = 0; i< elementos.Length; i++) {
                Debug.Log(elementos[i]);
            }            
        }
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
}
