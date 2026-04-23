using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class tutorial_document : MonoBehaviour, IPointerClickHandler
{
    private RectTransform uiElement;
    public bool is_open = false;
    public bool is_moving = false;
    public AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public float duration = 1.0f;

    public GameObject pages;
    public int current_page = 0;
    private List<GameObject> page_list = new List<GameObject>();

    private static readonly List<RaycastResult> _raycastResults = new List<RaycastResult>();

    void Start()
    {
        uiElement = gameObject.GetComponent<RectTransform>();
        foreach (Transform child in pages.transform)
        {
            page_list.Add(child.gameObject);
        }
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
        StartCoroutine(MoveAndScalePhone(new Vector2(0, -100), new Vector2(1.5f, 1.5f)));
    }

    public void ClosePhoneView()
    {
        is_open = false;
        StartCoroutine(MoveAndScalePhone(new Vector2(-600, -700), new Vector2(1, 1)));
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

    public void next_page()
    {
        pages.transform.GetChild(current_page).gameObject.SetActive(false);
        current_page = (current_page + 1) % pages.transform.childCount;
        pages.transform.GetChild(current_page).gameObject.SetActive(true);
    }

    public void previous_page()
    {
        pages.transform.GetChild(current_page).gameObject.SetActive(false);
        current_page = (current_page - 1 + pages.transform.childCount) % pages.transform.childCount;
        pages.transform.GetChild(current_page).gameObject.SetActive(true);
    }

}
