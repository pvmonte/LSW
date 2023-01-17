using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance;
    public IGameState state;
    [SerializeField] private Player _player;
    [SerializeField] private MessagePanel _messagePanel;
    [SerializeField] private InventoryCanvas _inventoryCanvas;
    [SerializeField] public PlayerInput playerInput;
    public CanvasUI currentUi { get; private set; }

    public Player player => _player;
    public MessagePanel messagePanel => _messagePanel;
    public InventoryCanvas inventoryCanvas => _inventoryCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
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

    public void HandleEscapeInput(InputAction.CallbackContext context)
    {
        state.HandleEscapeInput(context);
    }

    public void ResetState()
    {
        state = new StandardGameState(this);
    }

    public void StartNewState(IGameState neweState)
    {
        state = neweState;
    }

    public void OpenCanvasUi(CanvasUI canvas)
    {
        currentUi = canvas;
        state = new UiOpenedGameState(this);
    }
}
