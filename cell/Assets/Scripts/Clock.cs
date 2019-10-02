using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour{
    float tiempo;
    int segundos = 0;
    float minutos = 0;
    bool minuto = false;
    public Text reloj;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 1)
        {
            segundos++;
            if (segundos % 60 == 0)
            {
                minutos++;               
                segundos = 0;
                count++;
            }
            tiempo = 0;
        }
        reloj.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        if (count == 1)
        {
            minuto = true;
            count++;
        }
        else {
            minuto = false;
            count = 0;
        }
    }

    public string darTiempo() {
        return minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    public  bool darEstado() {
        return minuto;
    }
}
