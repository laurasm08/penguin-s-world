using UnityEngine;

public class Penguin : MonoBehaviour

{

    [SerializeField] private float speed = 10f; //Creo la velocidad a la que va a ir el penguin
    [SerializeField] private float jump = 5.0f; //Creo la fuerza del salto 

    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidbody;
    private bool lookingRight;
    private int saltos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        lookingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) //Si presiono la flecha derecha vas a hacer lo siguiente 
        {
            transform.Translate(speed * Time.deltaTime,0,0);
            animator.SetBool("isWalking", true);
            if (!lookingRight ) { 
                
                //Hacemos que el penguin gire complemetamente sobre su eje, el eje x (horizontal) lo dejamos igual y transformamos el eje y (vertical)
                transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0);
                lookingRight = true; 
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //Si presiono la flecha izquierda haz lo siguiente
        {
            transform.Translate(speed * Time.deltaTime,0,0);
            animator.SetBool("isWalking", true);
            if (lookingRight )
            {
                transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180,0);
                lookingRight = false;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (saltos < 2)
            {
                saltos++;
                rigidbody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
                animator.SetBool("isJumping", true);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 impactSpeed = collision.contacts[0].relativeVelocity; // relativeVelocity hace que podamos hacer que pierda una vida o se dañe al caer desde una gran altura
        Vector2 normal = collision.contacts[0].normal;

        if (normal.y > 0)
        {
            animator.SetBool("isJumping", false);
            saltos = 0;
        }
    }
}
