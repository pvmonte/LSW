using UnityEngine.InputSystem;

public class StandardGameState : BaseGameState
{
    public StandardGameState(GameStateController gameStateController) : base(gameStateController)
    {
    }

    public override void HandleMovementInput(InputAction.CallbackContext context)
    {
        gameStateController.player.HandleMovement(context);
    }

    public override void HandleInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            gameStateController.player.Interact(context);
    }

    public override void HandleEscapeInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            gameStateController.OpenCanvasUi(gameStateController.inventoryCanvas);
    }
}
