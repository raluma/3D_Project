using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody physics;
    private MeshCollider meshCollider;
    private BoxCollider boxCollider;

    public float speed = 2.0f;

    public float jumpForce = 4f;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        meshCollider = GetComponent<MeshCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento 
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        animator.SetFloat("X", x);
        animator.SetFloat("Y", 1);
        transform.Translate(new Vector3(x, 0.0f, 1) * Time.deltaTime * speed);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 0.1f)
        {
            animator.SetBool("Jump", true);
            physics.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        } else
        {
            animator.SetBool("Jump", false);
        }

        // Deslizamiento
        if (y == -1)
        {
            animator.SetBool("Slide", true);
            meshCollider.enabled = false;
            boxCollider.enabled = true;   
        } else
        {
            animator.SetBool("Slide", false);
            meshCollider.enabled = true;
            boxCollider.enabled = false;
        }

        if (transform.position.z <= -194f)
        {
            Debug.Log("You win!");
        } else if (transform.position.y < -2f)
        {
            Debug.Log("Game Over!");
        }
    }
}