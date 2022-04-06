using UnityEngine;

public class Key : MonoBehaviour
{    
    [SerializeField] private GameObject key; // Represents the key itself.

    /*
        Checks if the player collide with the Key. If he is, set the Player's "hasKey" property to "true".
    */
    private void OnCollisionEnter2D (Collision2D _collideWith) {
        if (_collideWith.gameObject.CompareTag ("Player")) {
            PlayerController.player.hasKey= true;
            GameObject.Destroy(key);
        }
    }

}
