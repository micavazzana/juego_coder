using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tipo
{
    Cae,NoCae
}
public class PlataformasFragiles : MonoBehaviour
{
    public Tipo opcion;
    private Rigidbody rb;
    private event Action onCambioColor;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        onCambioColor += CambiarColor;
    }

    private void Update()
    {
        //Cuando el objeto se encuentre en posicion -20 se destruira para desaparecer de la escena
        if (transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Chequea si el jugador pisa la plataforma. 
    /// Si la opcion esta seteada en "Cae" la plataforma pierde los contrains seteados del rigidbody cayendo al vacio por las fisicas
    /// Si esta seteada en "No Cae" la plataforma cambia de color y la plataforma queda congelada en su lugar
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            switch (opcion)
            {
                case Tipo.Cae:
                    this.rb.constraints = RigidbodyConstraints.None;
                    break;
                case Tipo.NoCae:
                    this.rb.constraints = RigidbodyConstraints.FreezeAll;
                    onCambioColor();
                    break;
            }
        }
    }

    /// <summary>
    /// Cambia de color del material
    /// </summary>
    private void CambiarColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }
    /// <summary>
    /// Desuscribe al evento en caso de que cualquier cosa suceda
    /// </summary>
    private void OnDisable()
    {
        onCambioColor -= CambiarColor;
    }
}
