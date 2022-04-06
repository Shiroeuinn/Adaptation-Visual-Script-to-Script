using UnityEngine.SceneManagement;
using UnityEngine;

public class HUDLoader : MonoBehaviour
{
    /*
        Load the HUD over the current Scene.
    */
    private void Start() {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }
}
