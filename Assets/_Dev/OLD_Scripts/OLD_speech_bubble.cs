using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class speech_bubble : MonoBehaviour
{

    public bool time_out = false;
    public Slider TimerBarSlider;
    public TextMeshProUGUI textMeshProUGUI;
    public float MaxTime = 10f;
    private float timeLeft;

    void Start()
    {
        timeLeft = MaxTime;
        TimerBarSlider.maxValue = MaxTime;

        textMeshProUGUI.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_out == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                TimerBarSlider.value = timeLeft;
            }
            else
            {
                time_out = true;
                TimerBarSlider.gameObject.SetActive(false);
                textMeshProUGUI.color = Color.gray;
                Debug.Log("Time is up!");
            }
        }
    }

    public void SetText(string text)
    {
        textMeshProUGUI.text = text;
    }
}
