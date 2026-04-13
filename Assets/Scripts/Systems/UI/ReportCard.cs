using UnityEngine;
using TMPro;

public class ReportCard : MonoBehaviour
{
    public TextMeshProUGUI correct_reports;
    public TextMeshProUGUI incorrect_reports;
    public TextMeshProUGUI vampires_reported;
    public TextMeshProUGUI missed_violations;
    public TextMeshProUGUI vampires_recorded;
    public TextMeshProUGUI villagers_lost;
    public void UpdateValues()
    {
        villagers_lost.text = ScoreManager.Instance.villagers_lost.ToString();
        vampires_reported.text = (ScoreManager.Instance.correct_reports + ScoreManager.Instance.incorrect_reports).ToString();
        correct_reports.text = ScoreManager.Instance.correct_reports.ToString();
        incorrect_reports.text = ScoreManager.Instance.incorrect_reports.ToString();
        missed_violations.text = (ScoreManager.Instance.total_violations - ScoreManager.Instance.correct_reports).ToString();
        vampires_recorded.text = ScoreManager.Instance.vampires_recorded.ToString();
    }

}
