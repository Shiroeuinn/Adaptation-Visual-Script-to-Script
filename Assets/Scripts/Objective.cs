using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {
 
    public string sceneToLoad; // Represents the next Scene to be load. 

    /*
        Load the scene defined in "sceneToLoad" if the player collide with the objective.
    */
    private void OnCollisionEnter2D (Collision2D _collideWith) {
        if (_collideWith.gameObject.CompareTag ("Player")) {
            PlayerPrefs.SetString(sceneToLoad, "Unlocked");
            SceneManager.LoadScene(sceneToLoad); 
        }
    }
}