using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    private CharacterController playerController;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Gamepad.current.dpad.down.wasPressedThisFrame)
        {
            playerController.SimpleMove(respawnPoint.position);
        }  
    }
}
