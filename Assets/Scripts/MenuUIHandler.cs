using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private TMP_InputField InputName;
    public Slider volumeSlider;

    private void Start()
    {
        if (volumeSlider != null) return;

        volumeSlider = GameObject.Find("Volume Slider").GetComponent<Slider>();
        InputName = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        volumeSlider.value = ScoreManager.Instance.SaveMusicVolume;

        LoadName();
    }

    private void Update()
    {
        if (volumeSlider != null)
        ScoreManager.Instance.SaveMusicVolume = volumeSlider.value;
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
        SaveName();
    }

    public void Exit()
    {
        ScoreManager.Instance.SavePlayerScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveName()
    {
        ScoreManager.Instance.CurrentPlayerName = InputName.text;
        ScoreManager.Instance.SavePlayerScore();
    }

    public void LoadName()
    {
        ScoreManager.Instance.LoadPlayerScore();
        InputName.text = ScoreManager.Instance.CurrentPlayerName;
    }
}
