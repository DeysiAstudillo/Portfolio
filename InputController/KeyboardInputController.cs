using UnityEngine;
using UnityEditor;

public class KeyboardInputController : InputController
{
    public MovementDirection getMovementDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            return MovementDirection.LEFT;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            return MovementDirection.RIGHT;
        } else {
            return MovementDirection.STRAIGHT;
        }
    }
}