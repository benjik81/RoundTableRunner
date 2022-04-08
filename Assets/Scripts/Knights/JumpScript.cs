using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private Animator anim;

    private bool canJump = false;
    private bool isJumpPressed = false;

    private JumpScript aboveKnight = null;

    private Rigidbody rb;
    private Vector3 up = new Vector3(0, 1, 0);

    // Temporary way to bind which key to use with that knight
    /*
    public enum keyCode
    {
        a, 
        z,
        e,
        r,
        d,
        f,
        j,
        k,
        space
    }
    public keyCode keyBind;
    */
    private int groundNumber = 0;

    public GameDataScript gameData;

    // bottom knight -> 1, top knight -> 5
    public int stackNumber;

    private CharacterController _character_controller;
    private PlayerScript parent;

    private void Awake()
    {
        _character_controller = GetComponent<CharacterController>();
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    void Start()
    {
        stackNumber = (int)transform.position.y;
        rb = GetComponentInParent<Rigidbody>();
        if(transform.parent.name != "Crown"){
            anim = GetComponentInParent<Animator>();
        }
        parent = GetComponentInParent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -20f, 0);
        if(canJump){
            //isJumpPressed = Input.GetKeyDown(keyBind.ToString());
            isJumpPressed = GetGameDataKey();
            if(isJumpPressed)
            {
                SetAnim(1f); //Anim Jump
                Jump(7.7f);
            }
        }
    }

    private bool GetGameDataKey()
    {
        switch (transform.parent.name)
        {
            case "Arthur":
                return Input.GetKeyDown(gameData.arthurKeyCode);
                break;
            case "Perceval":
                return Input.GetKeyDown(gameData.percevalKeyCode);
                break;
            case "Lancelot":
                return Input.GetKeyDown(gameData.lancelotKeyCode);
                break;
            case "Gauvain":
                return Input.GetKeyDown(gameData.gauvainKeyCode);
                break;
            default:
                //Debug.Log("Who tf are you? " + name + "? That's pretty sus...");
                return false;
        }
    }

    // Add vertical velocity to make the knight jump, jump height scale with the force -> jumps higher with more force
    // a force value of 4.5f is equal to one unit jump
    public void Jump(float force)
    {
        rb.velocity = up * force;

        // If another knight is above this knight when this knight jumps, make that knight jumps too 
        if(aboveKnight != null)
        {
            aboveKnight.Jump(force);
        }
    }

    // 0->Idle / 1->Jump / 2->Running / 3->Hit
    private void SetAnim(float numAnim)
    {
        if(transform.parent.name != "Crown"){
            // Don't play another animation if this knight is currently dying
            if(!parent.isDying)
            {
                anim.SetFloat("Blend", numAnim);
                //Debug.Log(transform.parent.name + " is now playing anim number " + numAnim);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        JumpScript otherKnight = other.GetComponent<JumpScript>();
        if(otherKnight)
        {
            // if otherKnight.stackNumber is lower than this knight's stackNumber then it means that either this knight fell on a knight
            // under him (after a jump) or that after this knight's jump the knight under him jumped too and now this knight can jump again
            if(otherKnight.stackNumber < stackNumber)
            {
                SetAnim(0f);
                canJump = true;
            }
            // If it's greater, it means that a knight above is now standing on top of this one
            // we have to keep the new knight reference to make him jump when this knight jump
            else
            {
                aboveKnight = otherKnight;
                aboveKnight.Jump(rb.velocity.y);
            }
        }

        // Now standing on smt with "Ground tag" -> can jump
        if(other.tag == "Ground")
        {
            SetAnim(2f);
            groundNumber += 1;
            canJump = true;
        }

        if(other.tag == "Obstacle")
        {
            // Standing on an obstacle -> can jump again
            if(other.gameObject.transform.position.y < transform.position.y)
            {
                SetAnim(2f);
                canJump = true;
            }
        }
    }

    void OnTriggerExit(Collider other) 
    {
        JumpScript otherKnight = other.GetComponent<JumpScript>();
        if(otherKnight)
        {
            // if otherKnight.stackNumber is lower than this knight's stackNumber then it mean that this knight just jumped and
            // doesn't have a support to jump from anymore
            if(otherKnight.stackNumber < stackNumber)
            {
                canJump = false;
            }
            // the knight above jumped, delete it's stocked reference, so if this knight jumps before the one above fall back, 
            // the one above don't jump a second time
            else
            {
                aboveKnight = null;
            }
        }
        
        // knight is no longer in contact with the ground -> can't jump
        if(other.tag == "Ground")
        {
            groundNumber -= 1;
            if(groundNumber == 0)
            {
                canJump = false;
            }
        }

        // Not standing on an obstacle anymore -> can't jump
        if(other.tag == "Obstacle")
        {
            canJump = false;
        }
    }
}
