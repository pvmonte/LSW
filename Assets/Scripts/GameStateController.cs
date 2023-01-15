using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance;
    public GameState state;
    [SerializeField] private Player _player;
    [SerializeField] private MessagePanel _messagePanel;
    [SerializeField] public PlayerInput playerInput;    

    public Player player => _player;
    public MessagePanel messagePanel => _messagePanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetState();
    }

    private void Update()
    {
        state.OnUpdate(Time.deltaTime);
    }

    public void HandleMovementInput(InputAction.CallbackContext context)
    {
        state.HandleMovementInput(context);        
    }

    public void HandleInteractInput(InputAction.CallbackContext context)
    {
        state.HandleInteractInput(context);
    }

    public void ResetState()
    {
        state = new StandardGameState(this);
    }

    public void StartNewState(GameState neweState)
    {
        state = neweState;
    }
}

public interface GameState
{
    void Start();
    void OnUpdate(float dt);
    void HandleMovementInput(InputAction.CallbackContext context);
    void HandleInteractInput(InputAction.CallbackContext context);
    void End();
}

public class BaseGameState : GameState
{
    public readonly GameStateController gameStateController;

    public BaseGameState(GameStateController gameStateController)
    {
        this.gameStateController = gameStateController;
        if(this.gameStateController.state != null) this.gameStateController.state.End();
        Start();
    }

    public virtual void Start() { }

    public virtual void OnUpdate(float dt) { }

    public virtual void HandleMovementInput(InputAction.CallbackContext context) { }

    public virtual void HandleInteractInput(InputAction.CallbackContext context) { }

    public virtual void End() { }
}

public class StandardGameState : BaseGameState
{
    public StandardGameState(GameStateController gameStateController) : base(gameStateController)
    {
    }

    public override void Start()
    {

    }

    public override void OnUpdate(float dt)
    {
        
    }



    public override void HandleMovementInput(InputAction.CallbackContext context)
    {
        gameStateController.player.HandleMovement(context);
    }

    public override void HandleInteractInput(InputAction.CallbackContext context)
    {
        gameStateController.player.Interact(context);
    }

    public override void End()
    {

    }
}

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
        gameStateController.messagePanel.Interact(context);
    }

    public override void End()
    {
        gameStateController.messagePanel.gameObject.SetActive(false);
    }
}
