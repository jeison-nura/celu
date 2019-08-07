//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelController : MonoBehaviour
{
    public delegate void OnDivision();
    public static event OnDivision _onDivision;

    float rv = 0;
    public GameObject celular;
    GameObject cl;
    float tamaño;
    //bool crecer = false;
    float crecimiento = 0;
    bool divi = true;
    public float creci = 0.0003f;
    //float seg = 0;
    float medida = 0;
    float F=0;
    public float beta = 1;
    public float k = 0.0001f;
    void Start()
    {
        Observer._onRevaluated += ReEstart;
        cl = GameObject.FindGameObjectWithTag("reloj");
        rv = Random.Range(0.0f , 1.0f);
        tamaño = transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        F = F + (1 - F) * (Mathf.Pow(transform.localScale.y, beta)) * k;
        crecimiento = (creci * transform.localScale.y) * Time.deltaTime;
        //Debug.Log(crecimiento);
        //Debug.Log(crecimiento + transform.localScale.y);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + crecimiento, transform.localScale.z);




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
        medida = transform.localScale.y;
        float res = medida / 4;
        celular.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        GameObject celHija = Instantiate(celular, new Vector3(transform.position.x, transform.position.y + res + 0.5f, transform.position.z), transform.rotation);

        this.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        this.transform.position = new Vector3(transform.position.x, transform.position.y - res - 0.5f, transform.position.z);

        //Debug.Log("Tamaño Celula madre: " + transform.localScale.y);
        //Debug.Log("Posicion madre: " + transform.position.y);
        //Debug.Log("Tamaño Celula hija: " + celHija.transform.localScale.y);
        //Debug.Log("Posicion hija: " + celHija.transform.position.y);
        _onDivision?.Invoke();
    }

    void ReEstart() {
        F = 0;
        rv = Random.Range(0.0f, 1.0f);
        Debug.Log("Yo" + transform.name + "Reinicie mis valores");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tapa"))
        {
            Observer._onRevaluated-= ReEstart;
            Destroy(gameObject);
        }
    }


    
        
}
