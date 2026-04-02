using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public GameObject PorchSceneUI;

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

    public void ShowPorchScene()
    {
        PorchSceneUI.SetActive(true);
    }

}
