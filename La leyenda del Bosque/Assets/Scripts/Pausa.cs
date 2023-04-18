using UnityEngine;

public class Pausa : MonoBehaviour
{
    private bool pausaActiva;
    public GameObject menuPausa;
    public AudioSource _audSource;
    public AudioSource musica;

    private void Start()
    {
        this.pausaActiva = false;
    }
    private void Update()
    {
        TogglePausa();
    }
    /// <summary>
    /// Pone en pausa o lo activa cuando se presiona la tecla Escape
    /// </summary>
    private void TogglePausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausaActiva)
            {
                ResumirJuego();
                _audSource.Play();
                musica.Play();
            }
            else
            {
                PausarJuego();
                _audSource.Pause();
                musica.Pause();
            }
        }
    }
    /// <summary>
    /// Pausa al juego activando la interfaz de pausa y congelando el tiempo
    /// </summary>
    private void PausarJuego()
    {
        menuPausa.SetActive(true);
        this.pausaActiva = true;
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resume al juego desactivando la interfaz y devolviendo el tiempo a tiempo real
    /// </summary>
    private void ResumirJuego()
    {
        menuPausa.SetActive(false);
        this.pausaActiva = false;
        Time.timeScale = 1f;
    }
}
