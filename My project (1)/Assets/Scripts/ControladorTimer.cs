using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTimer : MonoBehaviour
{
    public float timer;

    /// <summary>
    /// Inicializa el timer segun lo provisto
    /// </summary>
    void Start()
    {
        Tiempo.time = timer;
    }
    /// <summary>
    /// Llama al metodo Temporizador de la clase Tiempo para inicializar el contador
    /// </summary>
    void Update()
    {
        Tiempo.Temporizador();
    }
}
