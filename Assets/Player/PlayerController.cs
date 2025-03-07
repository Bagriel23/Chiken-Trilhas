using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput inputAction;

    public float speed = 2.7f;
    public float jumpForce = 5.0f;

    public GameObject shootPrefab;
    public float shootForce = 10.0f;

    private bool canJump = true;
    private bool canAttack = true;

    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rb;

    void Awake()
    {
        inputAction = new PlayerInput();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    void Update()
    {
        HandlerMovementAction();
        HandlerJumpAction();
        HandleAttack();

    }

    void HandlerMovementAction()
    {
        var movementInput = inputAction.Player.Movement.ReadValue<Vector2>();

        //        Debug.Log("Movement Input" + movementInput);

        transform.position += new Vector3(movementInput.x, 0, 0) * Time.deltaTime * speed;

        animator.SetBool("b_isWalking", movementInput.x != 0);


        if (movementInput.x != 0)
        {
            sprite.flipX = movementInput.x < 0;
        }
    }

    void HandlerJumpAction()
    {
        var jumpPressed = inputAction.Player.Jump.triggered;

        canJump = Mathf.Abs(rb.velocity.y) <= 0.001f;
        if (canJump && jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void HandleAttack()
    {
        var atackPressed = inputAction.Player.Attack.IsPressed();
        if (canAttack && atackPressed)
        {
            canAttack = false;

            animator.SetTrigger("t_attack");
        }
    }

    public void ShootNewEgg()
    {
        var newShot = GameObject.Instantiate(shootPrefab);
        newShot.transform.position = transform.position;

        Vector2 shotDirection = new Vector2(sprite.flipX ? 1 : -1, 0);
        newShot.GetComponent<Rigidbody2D>().AddForce(shotDirection * shootForce, ForceMode2D.Impulse);
        newShot.GetComponent<SpriteRenderer>().flipY = !sprite.flipX;
    }
    
    public void SetCanAttack()
    {
        canAttack = true;
    }

}