using UnityEngine.InputSystem;

public interface IGameState
{
    void Start();
    void OnUpdate(float dt);
    void HandleMovementInput(InputAction.CallbackContext context);
    void HandleInteractInput(InputAction.CallbackContext context);
    void HandleEscapeInput(InputAction.CallbackContext context);
    void End();
}
