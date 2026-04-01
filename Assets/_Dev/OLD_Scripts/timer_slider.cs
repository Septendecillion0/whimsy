using UnityEngine;
using UnityEngine.UI;

public class OLD_timer_slider : MonoBehaviour
{

    private bool time_out = false;
    public Slider TimerBarSlider;
    public float MaxTime = 10f;
    private float timeLeft;

    void Start()
    {
        timeLeft = MaxTime;
        TimerBarSlider.maxValue = MaxTime;
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
                //TimerBarSlider.gameObject.SetActive(false);
                Debug.Log("Time is up!");
            }
        }
    }
}
