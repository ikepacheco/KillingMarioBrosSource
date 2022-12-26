using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class Mario : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb2d;
    SpriteRenderer sprtrndr;
    BoxCollider2D bc2d;

    [Header("Dead Target")]
    public Transform target;

    [Header("Movement Player")]
    public static bool grounded;
    public static bool jump;
    public float jumpPower;
    public float maxspeedX;
    public float jumpTime;

    [Header("Android mode")]
    public GameObject canvas;

    [Header("Pause mode")]
    public GameObject hudPause;
    public GameObject buttonPause;

    float speed;
    float timeCounter = 0;
    float timeToCount = 2.64f;
    float timer = 0;
    float fixedTime;
    float jumpTimecounter;
    float h;
    float speedfixed;
    bool died;
    bool paused;
    Button btnPause;


    DebugMode.Level level;
    DebugMode.SO so;
    States.STATE_HUD STATE_HUD;
    States.STATE_GAME STATE_GAME;


    // Start is called before the first frame update
    void Start()
    {
        so.GetSO();

        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprtrndr = GetComponent<SpriteRenderer>();
        bc2d = GetComponent<BoxCollider2D>();
        level.Name = SceneManager.GetActiveScene().name;
        btnPause = buttonPause.gameObject.GetComponent<Button>();

        if (Time.timeScale == 0) 
        {
            Time.timeScale = 1;
        }

        if (so.windows)
        {
            canvas.SetActive(so.android);
        }
        else if (so.webgl)
        {
            canvas.SetActive(so.android);
        }
        else
        {
            canvas.SetActive(so.android);
        }

        if (level.Name == "Nivel1")
        {
            if (DebugMode.debug_mode)
            {
                transform.position = new Vector3(-11.5f, -2.09f, -1);
            }
        }
        else if (level.Name == "Nivel2") { 
            if (DebugMode.debug_mode) {
                transform.position = new Vector3(-11.5f, -1, -1);
            }
        }
    }
    void FixedUpdate()
    {
        if (_STATE_GAME() == (int)States.STATE_GAME.GAMING) // gaming
        {
            movementOnGaming();
        }
        if (_STATE_GAME() == (int)States.STATE_GAME.DIED) // died
        {
            stateDying();
        }

    }
    // Update is called once per frame
    void Update()
    {
        checkInput();

        if (_STATE_GAME() == (int)States.STATE_GAME.PAUSE)
        {
            hudPause.SetActive(true);
        }

        if (_STATE_GAME() == (int)States.STATE_GAME.GAMING)
        {
            hudPause.SetActive(false);
        }
    }
    void movementOnGaming()
    {
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        //ANDROID
        if (so.android) MoveOnAndroid();
        //PC
        h = Input.GetAxis("Horizontal");
        if (so.windows == true)
        {
            if (grounded == false)
            {
                speed = 25f;
            }
            else if (grounded == true)
            {
                speed = 35f;
            }
        }
        if (so.webgl == true)
        {
            if (grounded == false)
            {
                speed = 25f;
            }
            else if (grounded == true)
            {
                speed = 35f;
            }
        }
        rb2d.AddForce(Vector2.right * speed * 3 * h);
        rb2d.velocity = new Vector2(rb2d.velocity.x * 0.74333f, rb2d.velocity.y);

        //rb2d.velocity = new Vector2(speed * h, rb2d.velocity.y);
        //arreglar el maximo de velocidad para que no acelere siempre
        speedfixed = Mathf.Clamp(rb2d.velocity.x, -maxspeedX, maxspeedX);
        rb2d.velocity = new Vector2(speedfixed, rb2d.velocity.y);
        if (Input.GetKey(KeyCode.UpArrow) && jump == true)
        {
            AudioManager.PlaySound("jumpsound");
            if (jumpTimecounter > 0)
            {
                rb2d.AddForce(Vector2.up * jumpPower * 2);
                jumpTimecounter -= Time.deltaTime;
            }
            else
            {
                jump = false;
            }
        }
        if (Mathf.Abs(rb2d.velocity.x) <= 0.0001f)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
    void stateDying()
    {
        anim.SetBool("grounded", false);
        anim.SetBool("rotate", false);
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(bc2d);
        AudioManager.camsound.Stop();
        if (timeCounter == 0) AudioManager.audioeffects.Stop();
        AudioManager.PlaySound("deadsound");
        timeCounter += (Time.deltaTime / 100);
        if (timeCounter <= timeToCount)
        {
            target.position = Vector3.MoveTowards(target.position, new Vector3(target.position.x, target.position.y - 1f, target.position.z), speed / 4f * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed / 4f * Time.deltaTime);
            timer++;
            fixedTime = timer / 50;
        }
        if (fixedTime >= timeToCount)
        {
            SceneManager.LoadScene(level.Name);
        }
    }
    int _STATE_GAME()
    {
        STATE_GAME = States.STATE_GAME.LOADING;
        died = anim.GetBool("died");

        if (died)
            STATE_GAME = States.STATE_GAME.DIED;
        if (!died)
            STATE_GAME = States.STATE_GAME.GAMING;
        if (paused)
            STATE_GAME = States.STATE_GAME.PAUSE;

        return (int)STATE_GAME;
    }
    void checkInput()
    {
        if(_STATE_GAME() == (int)States.STATE_GAME.GAMING) { 
            //pasar variable de velocidad para activar animacion de movimiento
            anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
            //revisar velocidad y rotacion para animacion de rotacion
            checkVelocityX(rb2d.velocity.x);
            //PC
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
            {
                jump = true;
                jumpTimecounter = jumpTime;
                rb2d.velocity = (Vector2.up * jumpPower);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                jump = false;
            }

            //ANDROID
            if (so.android) CheckInputAndroidJump();


            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //Debug.Log("se presiono la tecla abajo");
            }
            anim.SetBool("grounded", grounded);
        }
        //cerrar juego al presionar escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_STATE_GAME() == (int)States.STATE_GAME.PAUSE)
            {
                paused = false;
                Time.timeScale = 1;
                btnPause.interactable = true;
            }
            else
            {
                paused = true;
                Time.timeScale = 0;
                btnPause.interactable = false;
            }
        }
    }
    
    void checkVelocityX(float vel_x)
    {
        //revisar direccion izquierda
        if (vel_x <= 0)
        {
            //PC
            //Debug.Log("se presiono la tecla izquierda");
            //caminando hacia la izquierda revisa si presionas hacia la derecha para rotar
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                anim.SetBool("rotate", true);
                //transform.localScale = new Vector3(1, 1, 1);
                sprtrndr.flipX = false;
            }
            //arreglar rotacion en caso de seguir hacia la izquierda
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                //transform.localScale = new Vector3(-1, 1, 1);
                sprtrndr.flipX = true;
            }
            //ANDROID
            if (so.android) CheckVelAndroidLeft();

        }
        //revisar direccion derecha
        else if (vel_x >= 0)
        {
            //PC
            //Debug.Log("se presiono la tecla derecha");
            //caminando hacia la derecha revisa si presionas hacia la izquierda para rotar
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("rotate", true);
                //transform.localScale = new Vector3(-1, 1, 1);
                sprtrndr.flipX = true;
            }
            //arreglar rotacion en caso de seguir hacia la derecha
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                //transform.localScale = new Vector3(1, 1, 1);
                sprtrndr.flipX = false;
            }
            //ANDROID
            if (so.android) CheckVelAndroidRight();
        }
        //en caso el personaje se este frenando desactivar la animacion de rotacion
        if (Mathf.Abs(vel_x) <= 1f)
        {
            anim.SetBool("rotate", false);
        }
        //Debug.Log(Input.GetAxis("Horizontal"));
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    
    void OnBecameInvisible()
    {
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(target.position, 0.15f);
    }
    public void closeButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void resumeButton()
    {
        STATE_GAME = States.STATE_GAME.GAMING;
        hudPause.SetActive(false);
        paused = false;
        Time.timeScale = 1;
        btnPause.interactable = true;
    }
    public void androidPauseButton()
    {
        STATE_GAME = States.STATE_GAME.PAUSE;
        hudPause.SetActive(true);
        paused = true;
        Time.timeScale = 0;
        btnPause.interactable = false;
    }
    void MoveOnAndroid()
    {
        //ANDROID
        h = CrossPlatformInputManager.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed * h);

        if(so.windows == false) { 
            if (grounded == false)
            {
                //speed = 20f;
                speed = 78.5f;
            }
            else if (grounded == true)
            {
                //speed = 30f;
                speed = 115f;
            }
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x * 0.94333f, rb2d.velocity.y);
        //rb2d.velocity = new Vector2(speed * h, rb2d.velocity.y);
        //arreglar el maximo de velocidad para que no acelere siempre
        speedfixed = Mathf.Clamp(rb2d.velocity.x, -maxspeedX, maxspeedX);
        rb2d.velocity = new Vector2(speedfixed, rb2d.velocity.y);
        if (CrossPlatformInputManager.GetButton("Jump") && jump == true)
        {
            if (jumpTimecounter > 0)
            {
                rb2d.AddForce(Vector2.up * jumpPower * 2);
                jumpTimecounter -= Time.deltaTime;
            }
            else
            {
                jump = false;
            }
        }
    }
    void CheckInputAndroidJump()
    {
        //ANDROID
        if (CrossPlatformInputManager.GetButtonDown("Jump") && grounded)
        {
            // Debug.Log("se presiono la tecla arriba");
            jump = true;
            jumpTimecounter = jumpTime;
            rb2d.velocity = (Vector2.up * jumpPower);
        }
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }
    void CheckVelAndroidLeft()
    {
        //ANDROID
        if (CrossPlatformInputManager.GetAxis("Horizontal") == 1f)
        {
            anim.SetBool("rotate", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        //arreglar rotacion en caso de seguir hacia la izquierda
        if (CrossPlatformInputManager.GetAxis("Horizontal") == -1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void CheckVelAndroidRight()
    {
        //ANDROID
        if (CrossPlatformInputManager.GetAxis("Horizontal") == -1f)
        {
            anim.SetBool("rotate", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //arreglar rotacion en caso de seguir hacia la derecha
        if (CrossPlatformInputManager.GetAxis("Horizontal") == 1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
}
