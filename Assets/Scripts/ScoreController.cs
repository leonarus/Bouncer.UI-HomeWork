using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _redScore;
    [SerializeField] private TextMeshProUGUI _yellowScore;
    [SerializeField] private TextMeshProUGUI _greenScore;
    [SerializeField] private TextMeshProUGUI _playerScore;
    
    public void UpdateScore(char color, char action)
    {
        switch (color)
        {
            case 'r' : ChangeValue(_redScore, action);
                break;
            case 'y' : ChangeValue(_yellowScore, action);
                break;
            case 'g' : ChangeValue(_greenScore, action);
                break;
            case 'c' : ChangeValue(_playerScore, action);
                break;
        }
    }

    private void ChangeValue(TextMeshProUGUI text, char action)
    {
        switch (action)
        {
            case '+': text.text = Convert.ToString(Convert.ToInt32(text.text) + 1);
                break;
            case '-': text.text = Convert.ToString(Convert.ToInt32(text.text) - 1);
                break;
        }
    }
}
