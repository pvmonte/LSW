using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] protected RectTransform inventoryWindowParent;
    [SerializeField] protected InventoryWindow window;
    protected RectTransform windowRctTransform;
    [SerializeField] protected Vector3 windowPosition = new Vector3(0, -30, 0);

    protected void OnEnable()
    {
        window.transform.SetParent(inventoryWindowParent);

        if (windowRctTransform == null)
            windowRctTransform = window.GetComponent<RectTransform>();

        windowRctTransform.anchoredPosition = windowPosition;
    }
}
