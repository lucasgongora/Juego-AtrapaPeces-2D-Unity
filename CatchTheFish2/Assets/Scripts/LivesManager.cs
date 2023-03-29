using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    private int liveCounter = 5;
    private GameObject[] livesImageUI;
    private Color UIImageColor;
    private GameObject panelLives;
    
    void Awake()
    {
        instance = this;
        //livesImageUI = GameObject.FindGameObjectsWithTag("LiveImageUI");
        UIImageColor = new Color(1, 1, 1, 0.2f);
    }

    private void Start()
    {
        panelLives = GameObject.Find("PanelLives");
        livesImageUI = new GameObject[panelLives.transform.childCount];
        for (int i = 0; i < panelLives.transform.childCount; i++)
        {
            livesImageUI[i] = GameObject.Find("Live" + (i + 1));
        }
    }
    public void RemoveLife()
    {
        if (liveCounter > 0)
        {
            liveCounter--;
            SetLiveImageUI();
        }
        if (liveCounter <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    private void SetLiveImageUI()
    {
        livesImageUI[liveCounter].GetComponent<Image>().color = UIImageColor;    
    }

}
