using DG.Tweening;
using UnityEngine;

public class ClickControllerTutorial : MonoBehaviour
{
    [SerializeField] private GameObject StartObject;
    [SerializeField] private GameObject EndObject;

    [SerializeField] private RectTransform UI_Element;
    [SerializeField] private Canvas _canvas;
    public Ease easing = Ease.Linear;

    private void Start()
    {
        RectTransform CanvasRect = _canvas.GetComponent<RectTransform>();

        Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(StartObject.transform.position);
        Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
        UI_Element.anchoredPosition = WorldObject_ScreenPosition;

        Vector2 viewportEndPosition = Camera.main.WorldToViewportPoint(EndObject.transform.position);
        Vector2 endObject_ScreenPosition = new Vector2(
            ((viewportEndPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((viewportEndPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

        UI_Element.DOAnchorPos(endObject_ScreenPosition, 4f, false).SetEase(easing).SetLoops(-1, LoopType.Restart);
        ;
    }
}
