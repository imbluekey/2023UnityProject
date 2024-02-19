using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    private Player player;

    public float playerSpeed = 20f; // Default Value of Player Speed is 1.0
    public float runningSpeed = 1.5f;
    public float dashSpeed = 3f;
    private float xInput, yInput;
    private float tapThresold = 0.5f;

    private bool isRunning;
    private bool isDashing;
    public bool canActive;
    int count = 0;

    Vector2 newVelocity;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        player = GetComponent<Player>();

        isRunning = false;
        isDashing = false;
        canActive = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tapThresold > 0 && count == 1 && canActive)
            {
                if (player.nowStamina > 30)
                {
                    isDashing = true;
                    Debug.Log("Dash");
                }
            }
            else
            {
                tapThresold = 1f;
                count += 1;
                Debug.Log("try");
            }
        }
        if (tapThresold > 0)
        {
            tapThresold -= 1 * Time.deltaTime;
        }
        else
        {
            count = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift) && canActive)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    { // Using FixedUpdate at playerMove.
      // Using Update can cause difference of velocity due to the frame rate of users PC.
        xInput = 0f; yInput = 0f;
        /*
         * Initianlizing the xInput and yInput to 0 
         * not to move while not pressing keys 
         */
        //dash agian
        if (Input.GetKey(KeyCode.W))
        {
            yInput += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        { // When Pressing Down Arrow
            yInput -= 1f;
            //Debug.Log("Player : GetKey > DOWN");
        }
        if (Input.GetKey(KeyCode.D))
        { // When Pressing Right Arrow
            xInput += 1f;
            playerSprite.flipX = false; // Player Component watches rightside.
            //Debug.Log("Player : GetKey > RIGHT");
        }
        if (Input.GetKey(KeyCode.A))
        { // When Pressing Left Arrow
            xInput -= 1f;
            playerSprite.flipX = true; // Player Component watches leftside
            //Debug.Log("Player : GetKey > LEFT");
        }
        newVelocity = new Vector2(xInput, yInput);
        // Makes the Vector2 Instance that contains the direction of Player
        if (isDashing)
        {
            newVelocity = newVelocity.normalized * playerSpeed * dashSpeed;
            isDashing = false;
            player.useStamina(30f);
            count = 0;
        }
        else
        {
            if (isRunning )
            {
                newVelocity = newVelocity.normalized * playerSpeed * runningSpeed;
                player.useStamina(0.5f);
            }
            else
            {
                newVelocity = newVelocity.normalized * playerSpeed;
            }
        }
        //Debug.Log("Player : Vector2 size > " + newVelocity.magnitude);
        if (newVelocity.magnitude > 0f)
        {
            playerAnimator.SetBool("PlayerRun", true);
        }
        else
        {
            playerAnimator.SetBool("PlayerRun", false);
        }
        // There can be a problem that players moves as speed of root 2 because of the Pythagorean theorem.
        // To avoid this, I tried Vector Nomalization that sets the size of vector into 1.
        // After that I multiplies the playerSpeed that can be changed by us. 
        playerRigidbody.velocity = newVelocity;
    }

    private void OnTriggerStay2D(Collider2D collision)
    { //when the arrow collise with the objects....
        Debug.Log("충돌 발생!");
        
    }
    

}
