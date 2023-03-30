using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpSpeed;
    public float dashSpeed;

    bool canDash;
    float playerDirection;

    public int jumpsAllowed;
    int jumpsLeft;

    public bool isAttacking;

    public Rigidbody playerRigidbody;
    public GameObject playerMesh;
    public Animator playerAnimator;

    public GameObject levelCompletedMenu;
    public GameObject levelFailedMenu;

    public GameObject knight_body;
    public GameObject knight_head;
    public GameObject knight_leftArm;
    public GameObject knight_rightArm;
    public GameObject knight_weapon;

    public GameObject wizard_body;
    public GameObject wizard_head;
    public GameObject wizard_leftArm;
    public GameObject wizard_rightArm;
    public GameObject wizard_weapon;

    private string role;
    [SerializeField] public int coin = 0;


    // Start is called before the first frame update
    void Start()
    {
        jumpsLeft = jumpsAllowed;
        playerDirection = 1f;
        isAttacking = false;
        role = "wizard";

        if(string.Compare(role, "wizard") == 0)
        {
            knight_body.SetActive(false);
            knight_head.SetActive(false);
            knight_leftArm.SetActive(false);
            knight_rightArm.SetActive(false);
            knight_weapon.SetActive(false);
        }
        else if(string.Compare(role, "knight") == 0)
        {
            wizard_body.SetActive(false);
            wizard_head.SetActive(false);
            wizard_leftArm.SetActive(false);
            wizard_rightArm.SetActive(false);
            wizard_weapon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //Jump and Dash
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerJump();

                playerAnimator.SetBool("isJumping", true);
                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isRunning", false);
                playerAnimator.SetBool("isDashing", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                StartCoroutine(toggleDash());
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerAnimator.SetTrigger("attack1");
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                if (string.Compare(role, "knight") == 0)
                {
                    playerAnimator.SetTrigger("attack2");
                }
                else if (string.Compare(role, "wizard") == 0)
                {
                    // for wizard, attack animation is all same(atk anim 1)
                    playerAnimator.SetTrigger("attack1");
                }
            }

            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerDirection = -1f;

                //playerMesh.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);

                playerMesh.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                playerDirection = 1f;

                //playerMesh.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);

                playerMesh.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
        }
    }

    
    void FixedUpdate()
    {
        if (PhotonNetwork.IsMasterClient)
        {

            if (Input.GetKey(KeyCode.LeftShift) && PhotonNetwork.IsMasterClient)
            {
                playerRigidbody.velocity = new Vector3(0f, playerRigidbody.velocity.y, Input.GetAxis("Horizontal") * (walkSpeed + sprintSpeed));

                if (playerRigidbody.velocity.magnitude != 0f)
                {
                    playerAnimator.SetBool("isRunning", true);
                    playerAnimator.SetBool("isWalking", false);
                }
            }
            else
            {
                playerRigidbody.velocity = new Vector3(0f, playerRigidbody.velocity.y, Input.GetAxis("Horizontal") * walkSpeed);

                if (playerRigidbody.velocity.magnitude != 0f)
                {
                    playerAnimator.SetBool("isWalking", true);
                    playerAnimator.SetBool("isRunning", false);
                }
            }
        }

        if (canDash)
        {
            playerDash();
            playerAnimator.SetBool("isDashing", true);
        }
        
    }

    //Jump and Dash

    void playerJump()
    {
        if(jumpsLeft > 0)
        {
            playerRigidbody.velocity = Vector3.up * jumpSpeed;
            jumpsLeft--;
            Debug.Log("Jumped!");
        }

    }

    void playerDash()
    {
        playerRigidbody.AddForce(0, 0, dashSpeed * playerDirection, ForceMode.Impulse);
    }

    IEnumerator toggleDash()
    {
        canDash = true;
        yield return new WaitForSeconds(.4f);
        canDash = false;
        playerAnimator.SetBool("isDashing", false);        
    }

    //Level Completed and Failed Coroutine

    IEnumerator LevelCompleted()
    {
        levelCompletedMenu.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LevelFailed()
    {
        levelFailedMenu.SetActive(true);
        playerMesh.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //Ground and Enemy Check
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Breakable" || collision.gameObject.tag == "UnBreakable" || collision.gameObject.tag == "MovingPlatform" +
            "")
        {
            //Debug.Log("Is Grounded!");
            jumpsLeft = jumpsAllowed;

            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isDashing", false);
		}

        if (collision.gameObject.tag == "LevelExit") 
        {
            Debug.Log("Level Completed!");

            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isDashing", false);

            StartCoroutine(LevelCompleted());
		}

        if (collision.gameObject.tag == "FallTrigger") 
        {
            Debug.Log("Level Failed!");

            StartCoroutine(LevelFailed());
		}

        /*
        if (collision.gameObject.tag == "Enemy") 
        {
            if(!isControlable)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                StartCoroutine(GameOver());
            }
        }
        */
        
	}


    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "Coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "CoinPile")
        {
            coin += 10;
            Destroy(collision.gameObject);
        }
    }
}