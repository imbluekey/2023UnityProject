using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    public float playerSpeed = 1f; // Default Value of Player Speed is 1.0
    private float xInput, yInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();  
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
        if (Input.GetKey(KeyCode.W))
        { // When pressing Upper Arrow
            yInput = 1f;
            Debug.Log("Player : GetKey > UP");
        }
        else if(Input.GetKey(KeyCode.S))
        { // When Pressing Down Arrow
            yInput = -1f;
            Debug.Log("Player : GetKey > DOWN");
        }
        if (Input.GetKey(KeyCode.D))
        { // When Pressing Right Arrow
            xInput = 1f;
            playerSprite.flipX = false; // Player Component watches rightside.
            Debug.Log("Player : GetKey > RIGHT");
        }
        else if (Input.GetKey(KeyCode.A))
        { // When Pressing Left Arrow
            xInput = -1f;
            playerSprite.flipX = true; // Player Component watches leftside
            Debug.Log("Player : GetKey > LEFT");
        }



        //float xSpeed = xInput * playerSpeed;
        //float ySpeed = yInput * playerSpeed;   
        //대각선으로 가면 루트 2만큼 속도가 나오니, 이때는 속도를 1로 만들게 조정할것. 
        Vector2 newVelocity = new Vector2(xInput, yInput); 
        // Makes the Vector2 Instance that contains the direction of Player 
        newVelocity = newVelocity.normalized * playerSpeed;
        Debug.Log("Player : Vector2 size > " + newVelocity.magnitude);
        if(newVelocity.magnitude > 0f )
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
    
}
