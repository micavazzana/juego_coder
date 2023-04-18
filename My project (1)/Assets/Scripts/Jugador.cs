using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadDeMovimiento;
    public float powerSalto;
    public Animator animator;
    private Rigidbody rb;
    private bool estaEnPiso;
    private bool sePuedeMover;
    private bool puedeAtacar;
    public static float vida;
    public GameObject colliderAtaque;

    //AUDIO
    [Header("Variables de Audio")]
    public AudioSource _audSource;
    public AudioClip pasos;
    public AudioClip ataque;
    public AudioClip damage;
    public AudioClip powerUp;

    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.estaEnPiso = true;
        this.sePuedeMover = true;
        this.puedeAtacar = true;
        vida = 100f;
    }

    void FixedUpdate()
    {
        if(sePuedeMover)
        {
            Movimiento();
            Salto();
        }
        Ataque();        
    }

    /// <summary>
    /// Mueve al jugador segun un input seteando animaciones segun se mueva o no.
    /// </summary>
    void Movimiento()
    {
        //Movimiento
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;
        transform.position = transform.position + direccion * this.velocidadDeMovimiento * Time.deltaTime;

        //Animaciones y rotacion      
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("estaCaminando", true);
            transform.rotation = Quaternion.LookRotation(direccion);
            //StartAudioClip(pasos); 
        }
        else
        {
            animator.SetBool("estaCaminando", false);
            transform.Rotate(0f,0f,0f);
        }        
    }

    /// <summary>
    /// Hace saltar al jugador segun el input y le asigna una animacion en ese caso
    /// </summary>
    void Salto()
    {
        if (Input.GetButton("Jump") && estaEnPiso)
        {
            this.estaEnPiso = false;
            animator.SetBool("estaSaltando", true);
            this.rb.AddForce(new Vector3(0, powerSalto, 0), ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Ejecuta la animacion de ataque y reproduce su audio
    /// </summary>
    private void Ataque()
    {
        if(Input.GetButtonDown("Fire1") && puedeAtacar)
        {
            animator.SetTrigger("Ataca");
            StartAudioClip(ataque);
        }
    }

    /// <summary>
    /// Cambia estado de la variable para establecer que la animacion se reproduzca 
    /// sin que el jugador se mueva
    /// </summary>
    public void HabilitarAtaque()
    {
        this.sePuedeMover = false;
        colliderAtaque.SetActive(true);
        this.puedeAtacar = false;
    }
    /// <summary>
    /// Vuelve a habilitar la variable para que el jugador pueda moverse
    /// </summary>
    public void DesabilitarAtaque()
    {
        this.sePuedeMover = true;
        colliderAtaque.SetActive(false);
        this.puedeAtacar = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //Salto: Establece el "estaEnPiso" en true cuando el jugador esta en contacto con este.
        //Lo cambia a false cuando este salta
        if (collision.gameObject.CompareTag("Piso"))
        {
            this.estaEnPiso = true;
            animator.SetBool("estaSaltando", false);
        }
        //Vida: Resta una determinada cantidad de vida al hacer contacto con el enemigo
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            vida -= 16.7f;
            StartAudioClip(damage);
        }
        //PowerUp: Hace sonar la obtencion del bonus
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            StartAudioClip(powerUp);
        }

    }

    /// <summary>
    /// Cambia el clip que se reproducira
    /// </summary>
    /// <param name="clip"></param>
    void StartAudioClip(AudioClip clip)
    {
        _audSource.clip = clip;
        _audSource.Play();
    }
}
