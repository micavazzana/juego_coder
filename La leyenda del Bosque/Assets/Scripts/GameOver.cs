using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject elementosHUD;
    public GameObject gameOver;
    public GameObject jugador;

    public AudioSource _audSource;
    public AudioSource amb;
    public AudioSource musica;
    public AudioClip _gameOverClip;

    public event Action onGameOver;

    private void Start()
    {
        onGameOver += Game_Over;
    }

    /// <summary>
    /// Si la vida del jugador queda en 0 o si cae por el precipicio o si se queda sin tiempo se llama al GameOver
    /// </summary>
    public void CheckGameOver()
    {
        if (Jugador.vida <= 0 || jugador.transform.position.y < -10 || Tiempo.time <= 0)
        {
            onGameOver?.Invoke();
        }
    }

    /// <summary>
    /// Carga la interfaz del game over desactivando los elementos del HUD y deteniendo la musica, el ambiente y el tiempo
    /// </summary>
    public void Game_Over()
    {
        gameOver.SetActive(true);
        elementosHUD.SetActive(false);
        amb.Stop();
        musica.Stop();
        _audSource.clip = _gameOverClip;
        _audSource.Play();
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Desuscribe al evento en caso de que cualquier cosa suceda
    /// </summary>
    private void OnDisable()
    {
        onGameOver -= Game_Over;
    }
}
