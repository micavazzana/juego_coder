using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject elementosHUD;
    public GameObject gameOver;
    public GameObject jugador;

    public AudioSource _audSource;
    public AudioSource _audSourceGral;
    public AudioSource musica;
    public AudioClip _gameOverClip;

    private void Update()
    {
        //Si la vida del jugador queda en 0 o si cae por el precipicio o si se queda sin tiempo
        if (Jugador.vida <= 0 || jugador.transform.position.y < -10 || Tiempo.time <= 0)
        {
            _audSourceGral.Stop();
            musica.Stop();
            Game_Over();
        }
    }

    /// <summary>
    /// Carga la interfaz del game over desactivando los elementos del HUD y deteniendo el tiempo
    /// </summary>
    public void Game_Over()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        elementosHUD.SetActive(false);
        _audSource.clip = _gameOverClip;
        _audSource.Play();
    }
}
