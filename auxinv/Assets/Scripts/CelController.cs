//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelController : MonoBehaviour
{
    float escala = 0;
    public GameObject celular;
    GameObject cl;
    float tamaño;
    bool crecer = false;
    float tasacrecimiento = 0;
    bool divi = true;
    public float creci = 0.03f;
    void Start()
    {
        cl = GameObject.FindGameObjectWithTag("reloj");
        escala = Random.Range(3f,6f);
        tamaño = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Clock clo = cl.gameObject.GetComponent<Clock>();
        crecer = clo.darEstado();
        if (crecer) {
            Debug.Log("creci");
            tasacrecimiento = transform.localScale.y + 1 * creci * transform.localScale.y;            
            crecer = false;
        }
        if (tasacrecimiento >= transform.localScale.y)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.03f, transform.localScale.z);
        }
        else {
            tasacrecimiento = 0;
        }
        if (transform.localScale.y >= escala) {
            divi = true;
            if (divi) {
                divicion();
            }           
        }
    }

    private void divicion()
    {
        divi = false;
        tasacrecimiento = 0;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y/2, transform.localScale.z);
        celular.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Instantiate(celular, new Vector3(transform.position.x, transform.position.y + transform.localScale.y * 0.75f, transform.position.z), transform.rotation);
    } 
}
