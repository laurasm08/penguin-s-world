using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private GameObject personaje;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((personaje.transform.position.y > 0) && (personaje.transform.position.y < 14))
        {
            transform.position = new Vector3(transform.position.x, personaje.transform.position.y, transform.position.z); //Para que la camara coja la posicion del personaje y le siga a el.

        }
    }
}
