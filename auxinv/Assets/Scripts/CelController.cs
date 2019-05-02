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
    float crecimiento = 0;
    bool divi = true;
    public float creci = 0.00003f;
    float seg = 0;
    float medida = 0;
    void Start()
    {
        cl = GameObject.FindGameObjectWithTag("reloj");
        escala = Random.Range(2f,4f);
        tamaño = transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       
            crecimiento = (creci * transform.localScale.y) * Time.deltaTime;
            //Debug.Log(crecimiento);
            //Debug.Log(crecimiento + transform.localScale.y);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + crecimiento, transform.localScale.z);
          
          
        
        
        

        if (transform.localScale.y >= escala) {
            divi = true;
            if (divi) {
                division();
            }           
        }
    }

    private void division()
    {
        divi = false;
        crecimiento = 0;

        medida = transform.localScale.y;

        this.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        this.transform.position = new Vector3(transform.position.x, transform.position.y + medida * 0.25f, transform.position.z);
        celular.transform.localScale = new Vector3(transform.localScale.x, medida / 2, transform.localScale.z);
        Instantiate(celular, new Vector3(transform.position.x, transform.position.y * 0.75f, transform.position.z), transform.rotation);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tapa")) {
            Destroy(gameObject);
        }
    }
}
