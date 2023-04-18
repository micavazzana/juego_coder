using UnityEngine;

/// <summary>
/// Enumerado que brinda cuál va a ser la opcion a elegir para el tipo de plataforma móvil
/// </summary>
public enum Direccion
{
    UpDown, LeftRight, BackForward
}
public class PlataformasMoviles : MonoBehaviour
{
    public Direccion opcion;
    public float limiteA;
    public float limiteB;
    public float velocidadDeMovimiento;
    private Vector3 direccion;

    void Update()
    {
        //Segun que opcion de plataforma se quiere va a llamar al método Movimiento
        //y determinara los valores para que se mueva segun se requiera
        switch (opcion)
        {
            case Direccion.UpDown:
                Movimiento(transform.position.y, Vector3.down, Vector3.up);
                break;
            case Direccion.LeftRight:
                Movimiento(transform.position.x, Vector3.left, Vector3.right);
                break;
            case Direccion.BackForward:
                Movimiento(transform.position.z, Vector3.back, Vector3.forward);
                break;
        }
    }

    /// <summary>
    /// Mueve a la plataforma segun los parametros determinados
    /// </summary>
    /// <param name="posicion">eje x, y o z actual a comparar con los limites dados</param>
    /// <param name="direccionA">Primer direccion en cual se movera la plataforma</param>
    /// <param name="direccionB">Segunda direccion en cual se movera la plataforma</param>
    void Movimiento(float posicion, Vector3 direccionA, Vector3 direccionB)
    {
        if (posicion >= this.limiteA)
        {
            this.direccion = direccionA;
        }
        if (posicion <= this.limiteB)
        {
            this.direccion = direccionB;
        }
        transform.Translate(this.direccion * this.velocidadDeMovimiento * Time.deltaTime);
    }

    /// <summary>
    /// Determinara si el jugador esta tocando o no la plataforma
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            // Hace que el jugador sea hijo de la plataforma
            collision.gameObject.transform.parent = transform;

            // Calcula la posición relativa del jugador en la plataforma
            Vector3 posicionRelativa = collision.gameObject.transform.position - transform.position;

            // Actualiza la posición del jugador en función del movimiento de la plataforma
            collision.gameObject.transform.position = transform.position + posicionRelativa;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            // Hace que el jugador deje de ser hijo de la plataforma
            collision.gameObject.transform.parent = null;
        }
    }
}
