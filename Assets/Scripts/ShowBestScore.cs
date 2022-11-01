using UnityEngine;
using TMPro;

public class ShowBestScore : MonoBehaviour
{
    public TextMeshProUGUI Text;
    private int bestScore;
    private string bestPlayer;

    private void Start()
    {
        if (ScoreManager.Instance.LastPlayerScore != 0 && ScoreManager.Instance.LastPlayerName != null)
        {
            bestScore = ScoreManager.Instance.LastPlayerScore;
            bestPlayer = ScoreManager.Instance.LastPlayerName;
            Text.SetText(bestPlayer + " " + bestScore);
        }
        else
        {
            bestScore = 0;
            bestPlayer = "Player";
        }
    }
}
