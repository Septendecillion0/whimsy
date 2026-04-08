using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public GameObject PorchSceneUI;
    public GameObject MessagePanel;
    private bool message_displaying = false;
    public List<string> message_queue = new List<string>();
    public List<Color> message_colors = new List<Color>();

    //private int TEST_counter = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate managers
        }
    }

    void Update()
    {
        if (!message_displaying && message_queue.Count > 0)
        {
            message_displaying = true;
            DisplayMessage(message_queue[0], message_colors[0]);
            message_queue.RemoveAt(0);
            message_colors.RemoveAt(0);
        }
    }

    public void OnSpacePressed(InputAction.CallbackContext context)
    {
        // if (context.started)
        // {
        //     Debug.Log("Space pressed");
        //     SendMessage("Message " + TEST_counter, Color.orange);
        //     TEST_counter++;
        // }
    }

    public void ShowPorchScene()
    {
        PorchSceneUI.SetActive(true);
    }

    public void SendMessage(string message, Color? color = null)
    {
        message_queue.Add(message);
        message_colors.Add(color ?? Color.gray);
    }

    public void DisplayMessage(string message, Color color)
    {
        if (MessagePanel.GetComponent<CanvasGroup>() != null)
        {
            MessagePanel.SetActive(true);
            MessagePanel.GetComponent<Image>().color = message_colors[0];
            MessagePanel.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = message;
            StartCoroutine(FadeOut(3f));
        }
    }

    private IEnumerator FadeOut(float duration)
    {
        CanvasGroup canvasGroup = MessagePanel.GetComponent<CanvasGroup>();
        float startAlpha = 1f;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            // Interpolate alpha from 1 to 0 over the duration
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, time / duration);
            yield return null;
        }

        canvasGroup.alpha = 0; // Ensure it's fully transparent
        //Debug.Log("Message Over");
        message_displaying = false;
        MessagePanel.SetActive(false);
    }

}
