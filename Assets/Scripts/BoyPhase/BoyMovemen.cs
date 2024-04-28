using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class BoyMovement : MonoBehaviour
{
    private SpriteRenderer _playerSpriteRenderer;
    private Rigidbody2D _playerRigidBody;
    private Animator _playerAnimator;

    private bool isGrounded;
    private bool isRunning;

    private float jumpCooldown;

    public Slider moneySlider;
    public Slider pageSlider;

    //Jump
    private bool _isJumpQueued = false;

    public LayerMask layerMask;
    public float speed;
    public float jumpForce;
    public static int money = 0;
    public static int pages = 0;

    //sound effects
    public AudioSource jumpAudioSource;
    public AudioSource moneyAudioSource;


    void Start()
    {
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        

    }

    void Update()
    {
        CheckForQueuingJump();
        UpdateMoney();

    }
    void FixedUpdate()
    {
        playerMovement();
        JumpIfQueued();
        CheckGrounded();
    }

    void playerMovement()
    {
        float velocityY = _playerRigidBody.velocity.y;
        Vector3 velocity = new Vector3(0, 0, 0);
        bool isWalking = false;

        if (Input.GetKey(KeyCode.D))
        {
            if (isRunning)
            {
                velocity += Vector3.right * 2;
                _playerAnimator.SetBool("isRunning", true);
            }
            else
            {
                velocity += Vector3.right;
            }
            _playerSpriteRenderer.flipX = false;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (isRunning)
            {
                velocity += Vector3.left * 2;
                _playerAnimator.SetBool("isRunning", true);
            }
            else
            {
                velocity += Vector3.left;
            }
            _playerSpriteRenderer.flipX = true;
            isWalking = true;
        }



        // Apply the determined velocity, adjusted for frame time
        _playerRigidBody.velocity = speed * Time.fixedDeltaTime * velocity;
        _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, velocityY);

        // Update the Animator's isWalking parameter
        _playerAnimator.SetBool("isWalking", isWalking);
    }

    void JumpIfQueued()
    {
        if (_isJumpQueued && jumpCooldown < 1) 
        {
            _isJumpQueued = false;
            _playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            _playerAnimator.SetTrigger("isJumping");

            jumpAudioSource.time = 0.2f;
            jumpAudioSource.Play(); //play the jump sound effect

            jumpCooldown = 1f;
        }
    }

    void CheckForQueuingJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _isJumpQueued = true;
            jumpCooldown -= Time.deltaTime;
        }
    }

    void CheckForRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            _playerAnimator.SetBool("isRunning", false);
        }
    }

    void CheckGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f, layerMask))
        {
            isGrounded = true;
            
        }
        else
        {
            StartCoroutine(Co_CoyoteTimer());
            //isGrounded = false;
        }
        _playerAnimator.SetBool("isGrounded", isGrounded);
    }

    public void decreaseHealth()
    {
        _playerAnimator.SetTrigger("isHurting");
    }

    public static int IncreaseMoney()
    {
        return money++;
    }

    public static int CheckMoney()
    {
        return money;
    }

    public static int CheckPages()
    {
        return pages;
    }

    public static int IncreasePages()
    {
        return pages++;
    }

    void UpdateMoney()
    {
        float money = Character.CheckMoney();
        moneySlider.value = money;
    }
    void UpdatePages()
    {
        float pages = CheckPages();
        pageSlider.value = pages;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            collision.gameObject.SetActive(false);
            Character.money += 5;
            UpdateMoney();
            Debug.Log("money is: " + Character.money);
            moneyAudioSource.time = 0.4f;
            moneyAudioSource.Play(); //play money collecting sfx

        }
    }

    IEnumerator Co_CoyoteTimer()
    {
        yield return new WaitForSecondsRealtime(0.12f);
        isGrounded = false;
    }


}
