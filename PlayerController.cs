using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody myBody;

    public float forward_Speed = 8f, move_Speed = 8f, jump_Force = 300f;

    private Vector3 moveDirection = Vector3.zero;
    private float movement_Z;

    private bool canMove;
    private AudioSource audioFX;


    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        audioFX = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        Invoke("ActivateMovement", 2f);
       
    }

    void FixedUpdate()
    {
        CharacterMove();
        CharacterJump();

    }

    void CharacterMove()
    {

        if (!canMove)
            return;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {

            movement_Z = -move_Speed;

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {

            movement_Z = move_Speed;

        }
        else
        {
            movement_Z = 0f;
        }

        moveDirection = new Vector3(forward_Speed, myBody.velocity.y, movement_Z);

        myBody.velocity = moveDirection;

    }

    void CharacterJump()
    {

        if (Input.GetButtonDown("Jump"))
        {

            if (myBody.velocity.y == 0f)
            {

                myBody.AddForce(Vector3.up * jump_Force, ForceMode.Impulse);

            }

        }

    }

    void ActivateMovement()
    {
        canMove = true;
    }

    void EndGame()
    {
        SceneManager.LoadScene("HighScores");
    }

    void OnCollisionEnter(Collision target)
    {

        if (target.gameObject.tag == "KillZone")
        {

            if (!canMove)
                return;

            myBody.velocity = Vector3.zero;

            canMove = false;
            audioFX.Play();

            Invoke("EndGame", 2f);

        }

    }

} 
