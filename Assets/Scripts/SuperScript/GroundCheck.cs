using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private static bool grounded; // Defines if the "_target" GameObject is grounded.

    /*
        Checks if the "_target" GameObject  is grounded using CircleCast, and return a boolean defining if the "_target" GameObject  is grounded or not.
    */
    public static bool CheckForGround (Vector2 _offset, float _radius, float _distance, Transform _target) {
        Vector2 targetPositionToVector2 = _target.position;
        Vector2 circleCastOffset = targetPositionToVector2 + _offset;
        RaycastHit2D raycast = Physics2D.CircleCast (circleCastOffset, _radius, new Vector2 (0, -1), _distance, LayerMask.GetMask ("Platforms"));

        if (raycast.collider != null) {
            grounded = true;
            return grounded;
        }
        return false;
    }
}