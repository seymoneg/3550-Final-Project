using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    // public variables appear as properties in Unity's inspector window
    public float movementSpeed = 3.0f;
    //private float timer = .5f;
    private Animation anim;

    // holds 2D points; used to represent a character's location in 2D space, or where it's moving to
    Vector2 movement = new Vector2();

    // holds reference to the animator component in the game object
    Animator animator;

    // used to refer to the animation parameter that will be updated
    // use a variable to refer to this instead of hard-coding this name each time it's needed
    string animationState = "AnimationState";
    string alive = "alive";

    // reference to the character's Rigidbody2D component
    Rigidbody2D rb2D;

    // enumerated constants to correspond to the values assigned to the animations
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5,
    }



    // use this for initialization
    private void Start()
    {
        // get references to game object components so they don't have to be grabbed each time they are needed
        animator = GetComponent<Animator>();
        anim = gameObject.GetComponent<Animation>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // called once per frame
    private void Update()
    {
        // update the animation state machine

        UpdateState();
    }



    // called at fixed intervals by the Unity engine
    // update may be called less frequently on slower hardware when frame rate slows down
    void FixedUpdate()
    {
        MoveCharacter();
    }



    private void UpdateState()
    {
        // determine if GetAxisRaw returns -1, 0 or 1, and which axis
        // and change the state of the specified animation parameter accordingly
        if (movement.x > 0)
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        else if (movement.x < 0)
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        else if (movement.y > 0)
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        else if (movement.y < 0)
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        else
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
    }

    private void MoveCharacter()
    {
        // get user input
        // GetAxisRaw parameter allows us to specify which axis we're interested in
        // Returns 1 = right key or "d" (up key or "w")
        //        -1 = left key or "a"  (down key or "s")
        //         0 = no key pressed
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // keeps player moving at the same rate of speed, no matter which direction they are moving in
        movement.Normalize();

        // set velocity of RigidBody2D and move it
        rb2D.velocity = movement * movementSpeed;
    }

    private void OnCollisionEnter2D(Collision2D otherObj)
    {
    if (otherObj.gameObject.CompareTag("enemy")) {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {

        print("Died to:" + otherObj.gameObject);
        rb2D.bodyType = RigidbodyType2D.Static;
        animator.SetBool(alive, true);
        yield return new WaitForSeconds(1);



        RestartLevel();



    }
    }



    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
