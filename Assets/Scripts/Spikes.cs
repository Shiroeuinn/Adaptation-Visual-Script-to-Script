using UnityEngine;

public class Spikes : MonoBehaviour {

    /*
        Runs the "Death()" static function of PlayerController if the player collide with spikes.
    */
    private void OnCollisionEnter2D (Collision2D _collideWith) {
        if (_collideWith.gameObject.CompareTag ("Player")) {
            PlayerController.player.Death ();
        }
    }
}