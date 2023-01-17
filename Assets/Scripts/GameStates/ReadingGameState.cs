using UnityEngine.InputSystem;

public class ReadingGameState : BaseGameState
{
    public ReadingGameState(GameStateController gameStateController) : base(gameStateController)
    {
    }

    public override void Start()
    {
        gameStateController.messagePanel.gameObject.SetActive(true);
    }

    public override void OnUpdate(float dt)
    {
        //gameStateController.InputHandler.HandleInteractInput();
    }

    public override void HandleInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            gameStateController.messagePanel.Interact(context);
    }

    public override void End()
    {
        gameStateController.messagePanel.gameObject.SetActive(false);
    }
}
