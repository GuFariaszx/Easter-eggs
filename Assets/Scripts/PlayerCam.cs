using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    private float xRotation;
    private float yRotation;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {        
        // INPUTS DO MOUSE

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Rotação em volta do eixo Y, significa HORIZONTALMENTE
        yRotation += mouseX;

        // Rotação em volta do eixo X, significa VERTICALMENTE
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        // ROTAÇÃO e CAMERA

        this.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        this.orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
