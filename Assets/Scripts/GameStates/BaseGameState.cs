using UnityEngine.InputSystem;

public class BaseGameState : IGameState
{
    public readonly GameStateController gameStateController;

    public BaseGameState(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
        if (this.gameStateController.state != null) this.gameStateController.state.End();
        Start();
    }

    public virtual void Start() { }

    public virtual void OnUpdate(float dt) { }

    public virtual void HandleMovementInput(InputAction.CallbackContext context) { }
    public virtual void HandleInteractInput(InputAction.CallbackContext context) { }
    public virtual void HandleEscapeInput(InputAction.CallbackContext context) { }

    public virtual void End() { }
}
