using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Time;

    private void Start()
    {
        Score.text = GameManager.Instance.score.ToString();
        
        float min = GameManager.Instance.minutes;
        float sec = GameManager.Instance.seconds;

        Time.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
