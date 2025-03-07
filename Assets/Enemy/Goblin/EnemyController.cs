using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform[] destinations;

    Animator animator;
    SpriteRenderer sprite;

    int curreentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destinations.Length == 0)
        {
            animator.SetBool("b_isWalking", false);
            return;
        }

        animator.SetBool("b_isWalking", true);

        var currentDestination = destinations[curreentIndex];

        sprite.flipX = currentDestination.position.x < transform.position.x;

        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentDestination.position) <= 0.1f)
        {
            curreentIndex = (curreentIndex + 1) % destinations.Length;
        }
    }
}
