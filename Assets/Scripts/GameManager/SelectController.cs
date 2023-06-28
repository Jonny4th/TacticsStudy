using UnityEngine;
using UnityEngine.InputSystem;

public class SelectController : MonoBehaviour
{
    [SerializeField]
    Selector selector;

    public void MoveX(InputAction.CallbackContext context)
    {
        if(selector == null) return;
        if(context.phase != InputActionPhase.Performed) return;
        var input = context.ReadValue<float>();
        selector.MoveXCoor((int)input);
    }

    public void MoveZ(InputAction.CallbackContext context)
    {
        if(selector == null) return;
        if(context.phase != InputActionPhase.Performed) return;
        var input = context.ReadValue<float>();
        selector.MoveZCoor((int)input);
    }
}
