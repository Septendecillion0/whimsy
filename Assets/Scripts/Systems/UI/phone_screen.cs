using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class phone_screen : MonoBehaviour, IPointerClickHandler
{
    private RectTransform uiElement;
    public bool is_open = false;
    public bool is_moving = false;
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public float duration = 1.0f;

    private static readonly List<RaycastResult> _raycastResults = new List<RaycastResult>();

    void Start()
    {
        uiElement = gameObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!is_open || is_moving) return;
        if (Mouse.current == null) return;
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;

        Vector2 screenPos = Mouse.current.position.ReadValue();
        if (!IsPointerOverPhone(screenPos))
        {
            ClosePhoneView();
        }
    }

    private bool IsPointerOverPhone(Vector2 screenPos)
    {
        if (EventSystem.current == null) return false;

        PointerEventData ped = new PointerEventData(EventSystem.current) { position = screenPos };
        _raycastResults.Clear();
        EventSystem.current.RaycastAll(ped, _raycastResults);

        foreach (RaycastResult r in _raycastResults)
        {
            if (r.gameObject == gameObject || r.gameObject.transform.IsChildOf(transform))
                return true;
        }
        return false;
    }
    public void OpenPhoneView()
    {
        is_open = true;
        StartCoroutine(MoveAndScalePhone(new Vector2(0, 0), new Vector2(1.5f, 1.5f)));
    }

    public void ClosePhoneView()
    {
        is_open = false;
        StartCoroutine(MoveAndScalePhone(new Vector2(600, -760), new Vector2(1, 1)));
    }

    private IEnumerator MoveAndScalePhone(Vector2 target_position, Vector2 target_scale)
    {
        is_moving = true;
        Vector2 start_position = uiElement.anchoredPosition;
        Vector2 start_scale = uiElement.localScale;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float percentage = elapsed / duration;
            // Use curve to smooth the percentage (0 to 1)
            uiElement.anchoredPosition = Vector2.Lerp(start_position, target_position, curve.Evaluate(percentage));
            uiElement.localScale = Vector2.Lerp(start_scale, target_scale, curve.Evaluate(percentage));
            yield return null;
        }
        uiElement.anchoredPosition = target_position;
        uiElement.localScale = target_scale;
        is_moving = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (is_moving || is_open) return;
        OpenPhoneView();
    }


}
