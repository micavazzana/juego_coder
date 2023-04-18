using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasFragiles : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody>();
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
    /// Al colisionar el componente rigidbody de la plataforma pierde los contrains que tiene seteados
    /// cayendo al vacio por las fisicas
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            this.rb.constraints = RigidbodyConstraints.None;
        }
    }
}
