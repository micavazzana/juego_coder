using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int siguienteNivel;
    public GameObject success;
    public GameObject elementosHUD;

    public AudioSource _audSource;
    public AudioSource _audSourceGral;
    public AudioSource musica;
    public AudioClip successClip;

    //Llama a mostrar una interfaz de exito al llegar el jugador y pasa de nivel
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            _audSource.clip = successClip;
            _audSourceGral.Stop();
            musica.Stop();
            _audSource.Play();
            Exito();
        }
    }

    //Muestra la interfaz de exito 
    void Exito()
    {
        success.SetActive(true);
        elementosHUD.SetActive(false);
        Invoke("SiguienteNivel", 2f); 
    }

    //Carga el siguiente nivel
    public void SiguienteNivel()
    {
        SceneManager.LoadScene(this.siguienteNivel);
    }
}
