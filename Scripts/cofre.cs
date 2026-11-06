using UnityEngine;

public class cofre : MonoBehaviour
{
    public delegate void Recuperar();
    public event Recuperar OnRecuperar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter()
    {
        OnRecuperar?.Invoke();
    }

    public void OnPointerExit()
    {

    }
}