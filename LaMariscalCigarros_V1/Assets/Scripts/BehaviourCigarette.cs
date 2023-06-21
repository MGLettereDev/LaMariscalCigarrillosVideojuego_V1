using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourCigarette : MonoBehaviour
{
    Rigidbody2D rigidbody;

    private cigarrilloScript gameManager;
    public Animator animator;

    private void Awake()
    {
        gameManager = cigarrilloScript.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gameManager.fallingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        animator.Play("EliminarCigarrillo");
        gameManager.AumentarPuntaje();
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.DisminuirVida();
        Destroy(gameObject);
    }

}
