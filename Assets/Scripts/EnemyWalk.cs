using Unity.Mathematics;
using UnityEngine;

public class EnenyWalk : MonoBehaviour {
    private float speed = 2f;

    private void Update (float _direction) {
        float direction = Normalize(_direction);
        float movement = direction * speed;
    }

    private float Normalize (float _f) {
        if (_f > 0) {
            return 1f;

        } else if (_f < 0) {
            return -1f;

        } else {
            return 0;
        }
    }
}