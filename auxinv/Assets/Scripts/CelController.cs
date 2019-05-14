//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelController : MonoBehaviour
{
    float rv = 0;
    public GameObject celular;
    GameObject cl;
    float tamaño;
    bool crecer = false;
    float crecimiento = 0;
    bool divi = true;
    public float creci = 0.00003f;
    float seg = 0;
    float medida = 0;
    float F=0;
    public float beta = 1;
    public float k = 0.00001f;
    void Start()
    {
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




        Debug.Log(F);

        if (F >= rv)
        {
            divi = true;
            if (divi)
            {
                division();
            }
        }
    }

    private void division()
    {
        F = 0;
        divi = false;
        crecimiento = 0;
        Debug.Log("Tamaño Celula: " + transform.localScale.y);
        Debug.Log("Posicion: " + transform.position.y);
        medida = transform.localScale.y;
        float res = medida / 4;
        celular.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        GameObject celHija = Instantiate(celular, new Vector3(transform.position.x, transform.position.y + res + 0.5f, transform.position.z), transform.rotation);

        this.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        this.transform.position = new Vector3(transform.position.x, transform.position.y - res - 0.5f, transform.position.z);

        Debug.Log("Tamaño Celula madre: " + transform.localScale.y);
        Debug.Log("Posicion madre: " + transform.position.y);
        Debug.Log("Tamaño Celula hija: " + celHija.transform.localScale.y);
        Debug.Log("Posicion hija: " + celHija.transform.position.y);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tapa"))
        {
            Destroy(gameObject);
        }
    }
}
