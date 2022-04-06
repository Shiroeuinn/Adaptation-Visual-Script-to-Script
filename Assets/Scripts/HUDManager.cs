using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    [SerializeField] GameObject HUDKey; // Represents the HUDKey itself.
    [SerializeField] Image image; // Represents the Image component of the HUDKey.
    [SerializeField] Sprite playerHasKey; // Represents the Sprite of the HUDKey when the Player has a Key.
    [SerializeField] Sprite playerHasNoKey; // Represents the Sprite of the HUDKey when the Player has no Key.

    [SerializeField] List<GameObject> HUDHearts; // Represents the HUDHeart themselves.
    [SerializeField] Sprite HUDHeartFull; // Represents the Sprite of the HUDHeart when it is full.
    [SerializeField] Sprite HUDHeartEmpty; // Represents the Sprite of the HUDHeart when it is empty.

    /*
        Desactivates the HUDKey if there is no Key found in the scene.
    */
    private void Start () {
        if (GameObject.FindWithTag ("Key") == null) {
            HUDKey.SetActive (false);
        }
    }

    private void Update () {
        HUDKeyManager ();
        HUDHeartManager ();
    }

    /*
        Changes the HUDKey image according to the Player's "hasKey" property's value.
    */
    private void HUDKeyManager () {
        if (PlayerController.player.hasKey == true) {
            image.sprite = playerHasKey;
        } else {
            image.sprite = playerHasNoKey;
        }
    }

    /*
        Changes the HUDHearts images according to the Player's "health" property's value current state.
    */
    private void HUDHeartManager () {
        for (int HUDHeart = 0; HUDHeart < HUDHearts.Count; HUDHeart++) {
            if (PlayerController.player.health > HUDHeart) {
                HUDHearts[HUDHeart].GetComponent<Image> ().sprite = HUDHeartFull;
            } else {
                HUDHearts[HUDHeart].GetComponent<Image> ().sprite = HUDHeartEmpty;
            }
        }
    }
}