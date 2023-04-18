using UnityEngine;

public class PlataformasInvisibles : MonoBehaviour
{
    public GameObject plataforma;
    public bool empiezaVisible;
    public float intervaloDeTiempo;
    private float tiempoTranscurrido;

    private void Start()
    {
        tiempoTranscurrido = 0f;
        plataforma.SetActive(empiezaVisible);
    }
    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        
        if (tiempoTranscurrido >= intervaloDeTiempo)
        {
            empiezaVisible = !empiezaVisible;
            plataforma.SetActive(empiezaVisible);
            tiempoTranscurrido = 0;
        }
    }
}
