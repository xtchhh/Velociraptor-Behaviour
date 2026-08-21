using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class VelociraptorController : MonoBehaviour
{
    public float moveSpeed;
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    private float gravity = -9.41f;
    private float jumpMultiplier = -2.5f;
    private float gravityMultiplier = 1.75f;
    public float jumpHeight;
    private bool grounded;
    public Camera playerCamera;
    public VelociraptorInputActions input;
    private CharacterController vController;
    private Vector3 velocity;

    void Awake()
    {
        input = new VelociraptorInputActions();
        vController = GetComponent<CharacterController>();
        input.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        VelociraptorRun();
        Gravity();
        Jump();

        if (grounded)
        {
            Debug.Log($"The player IS grounded, your current velocity is {velocity.y}, character controller velocity is: {vController.velocity}");
        }
        else
        {
            Debug.Log($"The player is NOT grounded, your current velocity is {velocity.y}, character controller velocity is: {vController.velocity}");
        }
    }

    void MovementInput()
    {
        Vector2 move = input.Player.Move.ReadValue<Vector2>();
        grounded = vController.isGrounded;

        float Yinput = move.y;
        float Xinput = move.x;

        Vector3 forwardDirection = playerCamera.transform.forward;
        forwardDirection.y = 0f;
        forwardDirection = forwardDirection.normalized;

        Vector3 rightDirection = playerCamera.transform.right;

        Vector3 forwardRelative = forwardDirection * Yinput;
        Vector3 rightRelative = rightDirection * Xinput;

        Vector3 direction = forwardRelative + rightRelative;
        Vector3 finalDirection = (direction * moveSpeed) + (velocity.y * Vector3.up);

        vController.Move(finalDirection * Time.deltaTime);

        if (move.sqrMagnitude > 0.01)
        {
            this.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

    void VelociraptorRun()
    {
        if (Gamepad.current.leftStickButton.isPressed)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }

    void Gravity()
    {    
        if (grounded)
        {
            velocity.y += 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;

            if (vController.velocity.y < 0)
            {
                velocity.y += gravity * gravityMultiplier * Time.deltaTime;
            }
        }
    }

    void Jump()
    {
        if (Gamepad.current.aButton.wasPressedThisFrame && grounded)
        {
           velocity.y = Mathf.Sqrt(jumpHeight * jumpMultiplier * gravity);
        }
    }
}
