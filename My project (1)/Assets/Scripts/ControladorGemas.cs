using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGemas : MonoBehaviour
{
    /// <summary>
    /// Si el jugador recoge una gema, entonces el objeto desaparece de la escena destruyendose
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Destroy(this.gameObject);
        }
    }
}
