using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad = 100f;
    [SerializeField] private float fuerza = 300f;

    //Creo una funcion para que se destruta la bala 
    internal void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroySelf", 2); //A los 2 seg de crear la bala se destruye.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime); //hacemos que gire a la derecha y lo multiplicamos por la velocidad y por lo que dura el frame.
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Caja"))
        {
            Rigidbody2D rb = target.GetComponent<Rigidbody2D>();
            Vector2 direccion = (target.transform.position - transform.position).normalized;
            rb.AddForce(direccion * fuerza, ForceMode2D.Force);
            DestroySelf();
        }        
    }
}
