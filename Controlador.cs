using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public float velocitat = 10f;
    public float gir = 0.02f;
    
    public void accelerar(float davantDarrere, float speed)
    {
        if (davantDarrere == 0f)//frenar
        {
            
        }
        if (davantDarrere == 1f)//davant
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * speed *
          GetComponent<DadesCotxe>().maxSpeed);
        }
    }

    public void girar(float dretaEsquerra, float força)
    {
        gir = força;

        float upDown = Vector2.Dot(GetComponent<Rigidbody2D>().transform.TransformDirection(Vector2.up), GetComponent<Rigidbody2D>().velocity.normalized); //mirar si va a dalt o abaix
        if (upDown >= 0)
        {
            if (dretaEsquerra == 0f)//dreta
            {
                GetComponent<Rigidbody2D>().AddTorque(-gir * (GetComponent<Rigidbody2D>().velocity.sqrMagnitude * 0.5f *
                    GetComponent<DadesCotxe>().maxSteer)); //com més rapid, més pot girar
            }
            if (dretaEsquerra == 2f)//esquerra
            {
                GetComponent<Rigidbody2D>().AddTorque(gir * (GetComponent<Rigidbody2D>().velocity.sqrMagnitude * 0.5f *
                    GetComponent<DadesCotxe>().maxSteer)); //si està parat, no gira
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //endavant enrere
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            accelerar(1f, velocitat);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            accelerar(0f, velocitat);
        }*/

        //dreta esquerra
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            girar(2f, gir);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            girar(0f, gir);
        }*/
        //arreglar fricció lateral -reduir velocitat si el cotxe va de costat-
        Vector2 velocitatEndavant() { return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up); }
        GetComponent<Rigidbody2D>().velocity = velocitatEndavant();
    }
}
