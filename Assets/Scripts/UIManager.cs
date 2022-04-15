using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    



    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        
    }
}
