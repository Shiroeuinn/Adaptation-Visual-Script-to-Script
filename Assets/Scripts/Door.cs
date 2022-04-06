using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] BoxCollider2D boxCollider2D; // Represents the BoxCollider2D of the Door.
    [SerializeField] SpriteRenderer spriteRenderer; // Represents the SpriteRenderer of the Door.
    [SerializeField] Sprite doorOpen; // Represents the Sprite of the Door when it's open.

    /*
        Checks if the Player collide with the Door with his "hasKey" property set to "true". If he is, desactivates the BoxCollider of the Door and set the "doorOpen" Sprite. 
    */
    private void OnCollisionEnter2D (Collision2D _collideWith) {
        if (_collideWith.gameObject.CompareTag ("Player")) {
            if (PlayerController.player.hasKey) {
                boxCollider2D.enabled = false;
                spriteRenderer.sprite = doorOpen;
                PlayerController.player.hasKey = false;
            } else {
                Debug.Log ("Warning: Missing key to open the door");
            }
        }
    }
}