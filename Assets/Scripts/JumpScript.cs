using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private bool canJump = false;
    private bool isJumpPressed = false;

    private JumpScript aboveKnight = null;

    private Rigidbody rb;
    private Vector3 up = new Vector3(0, 1, 0);

    // Temporary way to bind which key to use with that knight
    public enum keyCode
    {
        a, 
        z,
        e,
        r,
        space
    }

    public keyCode keyBind;

    // bottom knight -> 1, top knight -> 5
    public int stackNumber;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canJump){
            //Debug.Log(name + " can jump");
            isJumpPressed = Input.GetKeyDown(keyBind.ToString());
            if(isJumpPressed)
            {
                //Debug.Log(name + " jumping");
                Jump(4.5f);
            }
        }

    }

    // Add vertical velocity to make the knight jump, jump height scale with the force -> jumps higher with more force
    // a force value of 4.5f is equal to one unit jump
    public void Jump(float force)
    {
        rb.velocity = up * force;

        
        if(aboveKnight != null)
        {
            aboveKnight.Jump(force);
        }
    }

    // Something enter the hitbox under the knight -> he is standing on something / someone -> he can jump
    void OnTriggerEnter(Collider other) 
    {
        JumpScript otherKnight = other.GetComponent<JumpScript>();
        if(otherKnight)
        {
            //Debug.Log(name + " is triggeredEnter by " + otherKnight.name);
            // if otherKnight.stackNumber is lesser than this knight's stackNumber then it mean that either this knight fell on another knight
            // under him (after a jump) or that after this knight's jump the knight under him jumped too and now this knight can jump again
            if(otherKnight.stackNumber < stackNumber)
            {
                canJump = true;
                //Debug.Log(name + " can now jump! thx " + otherKnight.name);
            }
            // If it's greater, then, we have to keep the other knight reference to make him jump when this knight jump
            else
            {
                aboveKnight = otherKnight;
                Debug.Log("aboveKnight of " + name + " is now " + aboveKnight.name);
                aboveKnight.Jump(rb.velocity.y);
            }
        }

        
        if(other.tag == "Ground")
        {
            canJump = true;
            //Debug.Log(name + " can now jump! thx ground!");
        }

        //Debug.Log(other.gameObject.name + " is now in contact with " + name);
        
    }

    void OnTriggerExit(Collider other) 
    {
        JumpScript otherKnight = other.GetComponent<JumpScript>();
        if(otherKnight)
        {
            if(otherKnight.stackNumber < stackNumber)
            {
                canJump = false;
                //Debug.Log(name + " can't jump without " + otherKnight.name);
            }
            else
            {
                aboveKnight = null;
                Debug.Log("aboveKnight of " + name + " is now null");
            }
        }
        
        // if bottom knight is no longer in contact with the ground -> can't jump
        if(other.tag == "Ground")
        {
            canJump = false;
            //Debug.Log(name + " can't jump if not on ground!");
        }

        //Debug.Log(other.gameObject.name + " is no longer in contact with " + name);
    }
}
