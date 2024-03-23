using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Keep this if you're using other UI elements like Button
using TMPro; // Add this for TextMeshPro
using UnityEngine.SceneManagement;

public class SlideShowController : MonoBehaviour
{
    public Sprite[] slides; // Assign all your slides here in the inspector
    public string[] slideTexts; // Texts for each slide
    public Button finishButton; // Assign your button here in the inspector
    public Image displayImage; // Assign your UI Image component in the inspector
    public TextMeshProUGUI displayText; // Change this line for TextMeshPro
    
    private int currentSlideIndex = 0;

    void Start()
    {
        finishButton.gameObject.SetActive(false); // Ensure the button is hidden initially
        if(slides.Length > 0)
        {
            displayImage.sprite = slides[currentSlideIndex]; // Display the first slide
            displayText.text = slideTexts[currentSlideIndex]; // Display the first slide's text
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown) // Check for mouse click or any key press
        {
            currentSlideIndex++;
            if (currentSlideIndex >= slides.Length)
            {
                finishButton.gameObject.SetActive(true);
                displayText.gameObject.SetActive(false); // Optionally hide the text when finished
            }
            else
            {
                displayImage.sprite = slides[currentSlideIndex];
                displayText.text = slideTexts[currentSlideIndex]; // Update the slide's text
            }
        }
    }
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