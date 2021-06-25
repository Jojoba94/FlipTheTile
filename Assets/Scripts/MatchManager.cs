using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    [SerializeField]
    private Text _gameTimeText;

    private float _timePeriodSeconds = 600;

    private void Update()
    {
        if (_timePeriodSeconds > 0f)
        {
            _gameTimeText.text = FormatTime(_timePeriodSeconds);
            _timePeriodSeconds -= Time.deltaTime;
        }
    }

    private string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = $"{minutes:00}:{seconds:00}:{fraction:000}";
        return timeText;
    }

}
