using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void clickStart()
    {
        
        GameManager.Instance.score = 0;
        GameManager.Instance.goToLevel(1);
    }

    public void clickEnd()
    {
        Application.Quit();
    }

    public void clickRestart()
    {
        GameManager.Instance.goToLevel(0);
    }

}
