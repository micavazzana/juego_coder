using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text cantidadDeGemas;
    public Text tiempo;
    public Image vida;
    private float vidaActual;
    private float maxVida;

    void Start()
    {
        tiempo.text = "";
        cantidadDeGemas.text = "0";
        maxVida = 100f;
    }

    void Update()
    {
        tiempo.text = $"{(int)Tiempo.time}";
        cantidadDeGemas.text=$"{ContadorDeRecoleccion.contadorDeGemas}";
        vidaActual = Jugador.vida;
        vida.fillAmount = vidaActual / maxVida;
    }
}
