using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelController : MonoBehaviour
{
    float escala = 0;
    public GameObject celular;
    void Start()
    {
        escala = Random.Range(2f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.0009f, transform.localScale.y + 0.005f , 1);
        if (transform.localScale.y >= escala) {            
            duplicar(escala);
        }
    }

    private void duplicar(float escala)
    {
        celular.transform.localScale = new Vector3(1,escala/2,1);
        Instantiate(celular, new Vector3(0, 0.5f, transform.position.z + (escala * 0.25f)), transform.rotation);
        Instantiate(celular, new Vector3( 0, 0.5f, transform.position.z + (escala*0.75f)), transform.rotation);
        Debug.Log(escala);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tubo")) {
            Destroy(gameObject);
        }
    }
}
