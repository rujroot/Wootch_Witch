using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlideShowController : MonoBehaviour
{
    public Sprite[] slides; // Assign all your slides here in the inspector
    public Button finishButton; // Assign your button here in the inspector
    public Image displayImage; // Assign your UI Image component in the inspector
    private int currentSlideIndex = 0;

    void Start()
    {
        //UpdateSlidesVisibility();
        finishButton.gameObject.SetActive(false); // Ensure the button is hidden initially
        if(slides.Length > 0)
        {
            displayImage.sprite = slides[currentSlideIndex]; // Display the first slide
        }
    }

    /*void UpdateSlidesVisibility()
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == currentIndex); // Only the current slide is active
        }
    }*/

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown) // Check for left mouse click
        {
            currentSlideIndex++;
            if (currentSlideIndex >= slides.Length)
            {
                //SceneManager.LoadScene("Start");
                // Optionally, do something when all slides have been shown, like loading a new scene
                // UnityEngine.SceneManagement.SceneManager.LoadScene("YourNextSceneName");
                //currentSlideIndex = 0; // Loop back to the first slide
                finishButton.gameObject.SetActive(true);
            }else{
                displayImage.sprite = slides[currentSlideIndex];
            }
            
        }
    }

    /*public void NextSlide()
    {
        if (currentIndex < slides.Length - 1)
        {
            currentIndex++;
            //UpdateSlidesVisibility();
        }
        else
        {
            // All slides are shown, show the button
            finishButton.gameObject.SetActive(true);
        }
    }*/
}

/*public class SlideShowController : MonoBehaviour
{
    public Sprite[] slides; // Assign your slides in the inspector
    private int currentSlideIndex = 0;
    public Image displayImage; // Assign your UI Image component in the inspector

    private void Start()
    {
        if(slides.Length > 0)
        {
            displayImage.sprite = slides[currentSlideIndex]; // Display the first slide
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown) // Check for left mouse click
        {
            currentSlideIndex++;
            if (currentSlideIndex >= slides.Length)
            {
                //SceneManager.LoadScene("Start");
                // Optionally, do something when all slides have been shown, like loading a new scene
                // UnityEngine.SceneManagement.SceneManager.LoadScene("YourNextSceneName");
                //currentSlideIndex = 0; // Loop back to the first slide
            }else{
                displayImage.sprite = slides[currentSlideIndex];
            }
            
        }
    }
}
*/