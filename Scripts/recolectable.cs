using UnityEngine;

public class recolectable : MonoBehaviour
{
    public float umbral = 30f;
    public float speed = 40f;
    GameObject player;
    GameObject cofre;
    bool mirado = false;
    bool recolectado = false;
    bool recuperando = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        cofre = GameObject.FindWithTag("Cofre");
        cofre.GetComponent<cofre>().OnRecuperar += IrAlJugador;
    }

    // Update is called once per frame
    void Update()
    {
        if (!recolectado && mirado && Vector3.Distance(transform.position, player.transform.position) < umbral)
        {
            recolectado = true;
        }

        if (recuperando)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (recolectado)
        {
            IrAlCofre();
        }
    }

    void IrAlCofre()
    {
        transform.position = Vector3.MoveTowards(transform.position, cofre.transform.position, speed * Time.deltaTime);
    }

    void IrAlJugador()
    {
        if (recolectado)
        {
            recuperando = true;
        }
    }

    void OnDestroy()
    {
        if (cofre != null)
        {
            cofre.GetComponent<cofre>().OnRecuperar -= IrAlJugador;
        }
    }

    public void OnPointerEnter()
    {
        mirado = true;
    }

    public void OnPointerExit()
    {
        mirado = false;
    }
}