using UnityEngine;
using TMPro;

//[RequireComponent(typeof(TMP_Text))]
public class ScoreBoard : MonoBehaviour
{
    private int _score;
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _scoreText.text = "Start";
    }

    public void IncreaseScore(int amountToIncrease)
    {
        _score += amountToIncrease;
        _scoreText.text = _score.ToString();
    }
}