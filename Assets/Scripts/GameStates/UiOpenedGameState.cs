using UnityEngine.InputSystem;

public class UiOpenedGameState : BaseGameState
{
    public UiOpenedGameState(GameStateController gameStateController) : base(gameStateController)
    {
        gameStateController.currentUi.ToggleCanvas();
    }

    public override void HandleEscapeInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            gameStateController.ResetState();
    }

    public override void End()
    {
        gameStateController.currentUi.ToggleCanvas();
    }
}
