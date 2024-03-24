using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int GAME_TIME = 60;
    public TextMeshProUGUI textUI;
    public GameObject cameraPoint, Player, NPCs;
    public Image Fade;

    public List<string> quests = new List<string>() { "Cauldron", "Tree", "Cat", "Ring" } ;

    private bool gameEnd = false;
    private int currentTime;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine
        currentTime = GAME_TIME;
        gameEnd = false;
        StartCoroutine(Counter());
    }

    public class Lost : INteractable
    {
        public void Interact(GameObject player)
        {
            Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
            timer.GameReset("Main");
        }
    }

    public class Win : INteractable
    {
        public void Interact(GameObject player)
        {
            Timer timer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
            timer.GameReset("Win");
        }
    }

    public void Finish(string quest)
    {
        quests.Remove(quest);
    }

    public void AddQuest(string quest)
    {
        quests.Add(quest);
    }

    private void Check()
    {
        Camera mainCamera = Camera.main;
        mainCamera.transform.localPosition = cameraPoint.transform.localPosition;
        NPCs.SetActive(true);
        Dialogue dialogue = Player.GetComponent<Dialogue>();

        if (quests.Contains("Cauldron"))
        {
            dialogue.AddDialogue(new List<string>() { "...", "We found a cauldron!", "She is a Witch!"}, new Lost());
        }else if (quests.Contains("Tree"))
        {
            dialogue.AddDialogue(new List<string>() { "...", "We found a potion bottle!", "She is a Witch!" }, new Lost());
        }
        else if (quests.Contains("Cat"))
        {
            dialogue.AddDialogue(new List<string>() { "...", "We found a cat!", "She is a Witch!" }, new Lost());
        }
        else if (quests.Contains("Ring"))
        {
            dialogue.AddDialogue(new List<string>() { "...", "We found a magic circle!", "She is a Witch!" }, new Lost());
        }
        else if (quests.Contains("Witch"))
        {
            dialogue.AddDialogue(new List<string>() { "...", "We found a clone of witch!", "She is a Witch!" }, new Lost());
        }
        else
        {
            dialogue.AddDialogue(new List<string>() { "...", "We don't found anything.", "She isn't a Witch." }, new Win());
        }
    }

    public bool isGameEnd()
    {
        return gameEnd;
    }

    public void GameReset(string sence)
    {
        gameEnd = true;
        StartCoroutine(UIFade(sence));
    }

    IEnumerator UIFade(string sence)
    {
        for(int i = 0; i < 256; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            Fade.color = new Color32(0, 0, 0, (byte)(i));
        }
        SceneManager.LoadScene(sence);
    }

    IEnumerator Counter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (gameEnd)
            {
                break;
            } 

            currentTime = currentTime - 1;
            if(currentTime < 0 )
            {
                gameEnd = true;
                Check();
                break;
            }

            textUI.text = currentTime.ToString();
        }

    }
}
