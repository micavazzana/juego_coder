using UnityEngine;

public static class Tiempo 
{
    public static float time;

    /// <summary>
    /// Resta una unidad de tiempo siempre que este sea mayor a cero
    /// </summary>
    public static void Temporizador()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Suma un bonus de tiempo segun lo establecido por parametro
    /// </summary>
    /// <param name="bonus">cantidad de bonus a sumar</param>
    public static void Bonus(float bonus)
    {
        time += bonus;
    }

}
