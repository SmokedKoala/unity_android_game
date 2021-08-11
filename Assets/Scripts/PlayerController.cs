using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    //  Физический компонент твердого тела для 2D спрайтов.
    private Rigidbody2D _rigidbody2D;
    private bool _facingRight;
    // проверка, приземлился ли персонаж
    private bool _isGrounded;
    // Компонент Transform определяет Position (положение), 
    // Rotation (вращение), и Scale (масштаб) каждого объекта в сцене
    public Transform feetPos;
    // насколько близко игрок должен находиться к земле
    public float checkRadius;
    // слой, от которого персонаж должен оттолкнуться
    public LayerMask whatIsGround;
    
    private Animator _anim;
    public Joystick jostick;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = jostick.Horizontal;
        // Вектор скорости твердого тела
        _rigidbody2D.velocity = new Vector2(moveInput * speed, _rigidbody2D.velocity.y);
        if ((_facingRight && moveInput > 0) || (!_facingRight && moveInput < 0))
        {
            Flip();
        }

        if (moveInput == 0)
        {
            _anim.SetBool("isRunning", false);
        }
        else
        {
            _anim.SetBool("isRunning", true);
        }
    }

    private void Update()
    {
        float verticalMove = jostick.Vertical;
        _isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (_isGrounded && verticalMove >= 0.5f){
            _rigidbody2D.velocity = Vector2.up * jumpForce;
            _anim.SetTrigger("takeOff");
        }

        if (_isGrounded)
        {
            _anim.SetBool("isJumping", false);
        }
        else
        {
            _anim.SetBool("isJumping", true);
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
