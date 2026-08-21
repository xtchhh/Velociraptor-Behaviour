using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Roar : MonoBehaviour
{
    public AudioSource[] roars = new AudioSource[3];

    void Update()
    {
        RoarAction();
    }

    void RoarAction()
    {
        int randomRoar = Random.Range(0, roars.Length);

        if (Gamepad.current.squareButton.wasPressedThisFrame)
        {
            roars[randomRoar].Play();
            //Debug.Log(roars[randomRoar]);
        }
    }
}
