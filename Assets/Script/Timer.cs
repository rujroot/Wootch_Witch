using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public int GAME_TIME = 60;
    public TextMeshProUGUI textUI;
    private int currentTime;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine
        currentTime = GAME_TIME;
        StartCoroutine(Counter());
    }

    IEnumerator Counter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            currentTime = currentTime - 1;
            if(currentTime < 0 )
            {
                SceneManager.LoadScene("Main");
                break;
            }

            textUI.text = currentTime.ToString();
        }

    }
}
