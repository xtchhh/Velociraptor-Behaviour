using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject rotatePoint;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(rotatePoint.transform.position, Vector3.up, 25 * Time.deltaTime);
    }
}
