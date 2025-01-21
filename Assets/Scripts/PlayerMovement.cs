using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        // Input de movimento
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Ground Check
        // Physics.Raycast(<origem do raio>, <direção do raio>, <comprimento do raio>, <objeto que será verificado>);
        grounded = Physics.Raycast(this.transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        // Ground Dragging
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else 
        {
            rb.linearDamping = 0;
        }

        // Controle de velocidade
        SpeedControl();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized *  moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        // Pega a velocidade atual
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Limita a velocidade caso passe da moveSpeed do player
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
