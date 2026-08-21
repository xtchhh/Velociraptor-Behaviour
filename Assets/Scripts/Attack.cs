using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private GameObject enemy;
    public AudioSource attackSound;
    public float attackDist;
    public int damage;
    private int enemyHealth = 3;

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {
        AttackAction();
    }

    void AttackAction()
    {
        Debug.DrawRay(this.transform.position + (1f * this.transform.up), this.transform.forward, Color.red);

        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            attackSound.Play();
            if (InView())
            {
                enemyHealth -= damage;
                if (enemyHealth <= 0)
                {
                    Destroy(enemy);
                }
            }
        }
    }

    bool InView()
    {
        if (Physics.Raycast(this.transform.position + (1f * this.transform.up), this.transform.forward, attackDist))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
