using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private float speed = 300f; // Defines the multiplier applied when the player is moving.
    private float jump = 12f; // Defines the multiplier applied when the player is jumping.
    private float fallMultiplier = 4f; // Defines the multiplier applied when the player is falling.
    private float lowMultiplier = 3.5f; // Defines the multiplier applied when the player is jumping lower.
    public bool hasKey = false; // Defines if the Player has a key or not.
    public int health = 3; // Defines the health of the Player.

    public static PlayerController player = null; // Represent the playerController script itself.

    [SerializeField] private Rigidbody2D playerRigidbody2D; // Represent the Rigidbody2D component of the Player.
    [SerializeField] private SpriteRenderer spriteRenderer; // Represent the SpriteRenderer component of the Player.
    [SerializeField] private Animator animator; // Represent the Animator component of the Player.
    [SerializeField] private Transform playerTransform; // Represent the Transform component of the Player.

    /*
        Makes sure that the player's reference is created only once.
    */
    private void Awake () {
        if (player == null) {
            player = this;
        } else {
            Destroy (gameObject);
        }
    }

    private void FixedUpdate () {
        float movement = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

        MovePlayer (movement);
        Flip (movement);
        AnimatePlayerMove (movement);
    }

    private void Update () {
        bool grounded = GroundCheck.CheckForGround (Vector2.zero, 0.3f, 1.1f, playerTransform);

        Jump (grounded);
        AnimatePlayerJump (grounded);
    }

    /*
        Applies the velocity to the player's rigidbody to making him move.
    */
    private void MovePlayer (float _movement) {
        playerRigidbody2D.velocity = new Vector2 (_movement, playerRigidbody2D.velocity.y);
    }

    /*
        Correctly flips the Player's SpriteRenderer when he is moving left or right.
    */
    private void Flip (float _movement) {
        if (_movement < 0) {
            spriteRenderer.flipX = true;
        } else if (_movement > 0) {
            spriteRenderer.flipX = false;
        }
    }

    /*
        Plays the Player's walking animation when he moves.
    */
    private void AnimatePlayerMove (float _movement) {
        animator.SetFloat ("Speed", Mathf.Abs (_movement));
    }

    /*
        Check if the Player is on the ground and if he is pressing the "Jump" button. If He is, makes the player jump. 
    */
    private void Jump (bool _grounded) {
        if (Input.GetButtonDown ("Jump") && _grounded) {
            playerRigidbody2D.AddForce (new Vector2 (0, jump), ForceMode2D.Impulse);
        }

        if (playerRigidbody2D.velocity.y < 0) {
            playerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (playerRigidbody2D.velocity.y > 0 && !Input.GetButton ("Jump")) {
            playerRigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
        }
    }
    /*
        Plays the Player's jumping animation when he jumps.
    */
    private void AnimatePlayerJump (bool _grounded) {
        animator.SetBool ("Grounded", _grounded);
    }

    /* 
        Reloads the scene to simulate the Player's death.
    */
    public void Death () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    /*
        Upadates the health of the Player when he takes damages, and checks if the Player is dead or not.
    */
    public void Damage (int _damage) {
        
        health = health - _damage;

        if (health == 0) {
            Death ();
        } else {
            StartCoroutine(Hurt ());
            animator.SetTrigger ("Hurt");
        }
    }

    /*
        Makes the Player invincible for one second when he takes damages.
    */
    private IEnumerator Hurt () {
        gameObject.layer = LayerMask.NameToLayer ("PlayerInvincible");
        yield return new WaitForSeconds (1);
        gameObject.layer = LayerMask.NameToLayer ("Player");
        yield return null;
    }
}