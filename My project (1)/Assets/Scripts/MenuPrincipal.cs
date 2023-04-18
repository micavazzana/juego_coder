using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    //Carga el primer nivel
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    //Sale del juego
    public void Salir()
    {
        Application.Quit();
    }

    //Vuelve al menu principal
    public void VolverAMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Al reintentar el nivel vuelve a cargar el nivel indicado
    public void VolverAIntentar(int level)
    {
        SceneManager.LoadScene(level);
    }
}
