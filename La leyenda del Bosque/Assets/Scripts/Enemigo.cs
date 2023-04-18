using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    public LayerMask playerLayer;
    public float velocidadDeMovimiento;
    public float rangoDeAlerta;
    private bool estaAlerta;
    public float stopDistance;
    public GameObject fxNubeDePolvo;
    public Animator animator;

    [Header("Variables de Audio")]
    public AudioSource _audSource;
    public AudioClip muerteEnemigo;

    private void Start()
    {
        estaAlerta = false;
    }
    void FixedUpdate()
    {
        MoverPersonajeLerp(player);
        //Si el enemigo cae por el precipicio deja de existir
        if (transform.position.y < -10)
        {
            Destruir();
        }
    }

    /// <summary>
    /// Mueve al enemigo segun un rango de alerta. 
    /// Calcula la distancia que tiene al jugador para definir en que punto parar
    /// y en base a la posicion del jugador establece su propia posicion y hacia donde mira
    /// </summary>
    /// <param name="p"></param>
    public void MoverPersonajeLerp(GameObject p)
    {
        Vector3 posicionJugador = new Vector3(p.transform.position.x, transform.position.y, p.transform.position.z);
        float distancia = Vector3.Distance(p.transform.position, transform.position);

        estaAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, playerLayer);
        if (estaAlerta && distancia >= stopDistance)
        {
            transform.LookAt(posicionJugador);
            transform.position = Vector3.Lerp(transform.position, posicionJugador, Time.deltaTime * velocidadDeMovimiento);
            animator.SetBool("seEstaMoviendo", true);
        }
        else
        {
            animator.SetBool("seEstaMoviendo", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador realiza su ataque colisiona con un collider del jugador.
        //Al contacto con este se realiza la animacion de muerte, un fx de humito
        //y se llama a Destruir despues de un cierto tiempo para dar un minimo tiempo a la animacion
        if (other.gameObject.CompareTag("AtaqueJugador"))
        {
            animator.SetBool("estaMuerto", true);
            Instantiate(fxNubeDePolvo, other.transform.position, Quaternion.identity);
            Invoke("Destruir", 0.5f);
            _audSource.clip = muerteEnemigo;
            _audSource.Play();
        }
    }

    /// <summary>
    /// Destruye al objeto
    /// </summary>
    void Destruir()
    {
        Destroy(this.gameObject);
    }
}

