using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("Start");
    }
}
