using UnityEngine;

public class Enemy : MonoBehaviour {

    /*
        Represents the Alive super state of an Enemy.
    */
    private void Alive () {

    }

    /*
        Represents the Dead super state of an Enemy.
    */
    private void Dead () {

    }

    /*
        Represents the Patrol super state of an Enemy.
    */
    private void Patrol () {

    }

    /*
        Represents the Chase state of an Enemy.
    */
    private void Chase () {

    }

    /*
        Represents the State of Enemy who can damaging the Player.
    */
    private void OnCollisionEnter2D (Collision2D _collideWith) {
        if (_collideWith.gameObject.CompareTag ("Player")) {
            PlayerController.player.Damage(1);
        }
    }

}