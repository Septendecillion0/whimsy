using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public int encounter_count = 0;
    public int total_violations = 0;
    public int correct_reports = 0;
    public int incorrect_reports = 0;
    public int missed_violations = 0;
    public int vampires_recorded = 0;
    public int villagers_lost = 0;


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

}
