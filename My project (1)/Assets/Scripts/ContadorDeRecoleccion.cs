using UnityEngine;

public class ContadorDeRecoleccion : MonoBehaviour
{
    public static int contadorDeGemas;
    public AudioSource _audSource;
    public AudioClip gema;

    void Start()
    {
        contadorDeGemas = 0;
    }

    /// <summary>
    /// Suma una unidad a la cantidad de gemas inicial
    /// </summary>
    public void Contador()
    {
        contadorDeGemas++;
    }

    /// <summary>
    /// Si se establece contacto con la gema, llamara al metodo que incrementa la cantidad de gemas recolectadas
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gema"))
        {
            Contador();
            _audSource.clip = gema;
            _audSource.Play();
        }
    }
}
