using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{

    public static MainMenu Instance;
    private bool isLoading = false;

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

        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        if (isLoading) return;
        StartCoroutine(LoadScene(1));
    }


    private IEnumerator LoadScene(int index)
    {
        isLoading = true;

        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        op.allowSceneActivation = false;

        while (op.progress < 0.9f)
        {
            yield return null;
        }

        op.allowSceneActivation = true;

        isLoading = false;
    }

}
