using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelController : MonoBehaviour
{
    float escala = 0;
    public GameObject celular;
    void Start()
    {
        escala = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, transform.localScale.y + 0.005f , 1);
        if (transform.localScale.y >= escala*2) {
            duplicar();
        }
    }

    private void duplicar()
    {
        celular.transform.localScale = new Vector3(1,1,1);
        Instantiate(celular, transform.position, transform.rotation);
        Instantiate(celular, new Vector3(0, 0.5f, transform.position.z +2), transform.rotation);
        Destroy(gameObject);
    }
}
