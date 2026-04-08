using UnityEngine;
using TMPro;

public class ReportCard : MonoBehaviour
{
    public TextMeshProUGUI total_violations;
    public TextMeshProUGUI correct_reports;
    public TextMeshProUGUI incorrect_reports;
    public TextMeshProUGUI missed_violations;


    public TextMeshProUGUI vampires_recorded;
    public TextMeshProUGUI villagers_lost;
    public void UpdateValues()
    {
        villagers_lost.text = ScoreManager.Instance.villagers_lost.ToString();
        total_violations.text = ScoreManager.Instance.total_violations.ToString();
        correct_reports.text = ScoreManager.Instance.correct_reports.ToString();
        incorrect_reports.text = ScoreManager.Instance.incorrect_reports.ToString();
        missed_violations.text = ScoreManager.Instance.missed_violations.ToString();
        vampires_recorded.text = ScoreManager.Instance.vampires_recorded.ToString();
    }

}
