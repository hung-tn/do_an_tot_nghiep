using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    public GameSession gameSession;
    public GameOver gameOver;
    public bool isAlive = true;
    public static PlayerMove instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator =  GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
     
    }

    void Update()
    {
        if (!isAlive)
        {
            return;
        }

        Run();
        FlipSprite();
        Climbing();
        Die();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }


    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {

            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
    void Climbing()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;

        myRigidbody.gravityScale = 0f;
        bool playerClimbSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerClimbSpeed);
    }


    void OnFire (InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        myAnimator.SetTrigger("Trigger");
        Instantiate(bullet, gun.position, transform.rotation);
    }
    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazads")))
        {
            gameOver = GetComponent<GameOver>();
            gameOver = FindObjectOfType<GameOver>();
            gameSession = FindAnyObjectByType<GameSession>();
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            if (gameSession.Health <= 0 )
            {
                isAlive = false;
                myAnimator.SetTrigger("Death");
                myRigidbody.velocity = deathKick;
                gameOver.OnPlayerDeath();
            }
        }
    }

    void OnHp(InputValue value)
    {
        if (gameSession.hpItem > 0 && gameSession.currentHealth < gameSession.maxHealth)
        {
            gameSession.hpItem--;
            gameSession.currentHealth += 20;
            if (gameSession.currentHealth > gameSession.maxHealth) gameSession.currentHealth = gameSession.maxHealth;
            gameSession.hpText.text = "HP: " + gameSession.hpItem;
            gameSession.healthBarText.text = "HP " + gameSession.currentHealth + " / " + gameSession.maxHealth; ;
            gameSession.healthBarSlider.value = gameSession.currentHealth;
        }
    }

    void OnMp(InputValue value)
    {
        if (gameSession.mpItem > 0 && gameSession.currentMana < gameSession.maxMana)
        {
            gameSession.mpItem--;
            gameSession.currentMana += 20;
            if (gameSession.currentMana > gameSession.maxMana) gameSession.currentMana = gameSession.maxMana;
            gameSession.mpText.text = "MP: " + gameSession.mpItem;
            gameSession.manaBarText.text = "MP " + gameSession.currentMana + " / " + gameSession.maxMana;
            gameSession.manaBarSlider.value = gameSession.currentMana;
        }
    }
}
