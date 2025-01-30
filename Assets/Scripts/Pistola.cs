using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] private GameObject Bala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            Instantiate(Bala, transform.position, transform.rotation); //Instacio el GameObject Bala y transformo su posicion y rotacion de la pistola.
        
        }

    }
}
