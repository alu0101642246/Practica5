using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float speed = 50f;
    public float limit = 0.3f;
    Camera main_camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        main_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = main_camera.transform.forward;
        if (Mathf.Abs(forward.y) > limit)
        {
            Vector3 direccion = new Vector3(forward.x, 0f, forward.z).normalized;
            transform.position += direccion * speed * Time.deltaTime;
        }
    }

}
