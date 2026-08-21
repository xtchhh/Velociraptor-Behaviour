using UnityEngine;
using UnityEngine.InputSystem;

public class VelociraptorAnimations : MonoBehaviour
{
    private Animator animator;
    public VelociraptorController controller;
    private CharacterController charController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.input.Player.Move.ReadValue<Vector2>().sqrMagnitude < 0.1)
        {
            animator.Play("Idle");
        }
        else
        {
            if (controller.input.Player.Move.ReadValue<Vector2>().sqrMagnitude > 0.1 && controller.moveSpeed == controller.walkSpeed)
            {
                animator.Play("Walk");
            }

            if (controller.input.Player.Move.ReadValue<Vector2>().sqrMagnitude > 0.1 && controller.moveSpeed == controller.runSpeed)
            {
                animator.Play("Run");
            }
        }
        if (Gamepad.current.aButton.wasPressedThisFrame && charController.isGrounded)
        {
            animator.SetTrigger("jump");
        }

        if (Gamepad.current.squareButton.wasPressedThisFrame)
        {
            animator.SetTrigger("roar");
        }

        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            animator.SetTrigger("attack");
        }

    }

    /*
     if player gives no input - play idle anim so sqrMag of move vector
    if player gives input and is moveSpeed = walkSpeed, play walk anim
    if player presses x, play jump animation
    if player presses square, play attack animation
     */

}
