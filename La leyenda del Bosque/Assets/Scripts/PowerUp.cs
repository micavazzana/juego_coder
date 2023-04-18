using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float bonus;

    /// <summary>
    /// Si el jugador recoge el bonus se llama al metodo Bonus de la clase Tiempo
    /// para establecer la cantidad de bonus que se sumara, luego deja de existir el objeto en la escena.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Tiempo.Bonus(this.bonus);
            Destroy(this.gameObject);
        }
    }
}
