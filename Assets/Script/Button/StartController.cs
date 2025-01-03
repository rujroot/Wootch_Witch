using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Keep this if you're using other UI elements like Button
using TMPro; // Add this for TextMeshPro
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public Sprite[] slides;
    public string[] slideTexts;
    public Button startButton; // Use a start button to initiate the slideshow
    public Image displayImage;
    public Image startImage;
    public Image preStartImage;
    public TextMeshProUGUI displayText;

    public AudioClip audioClip;
    public AudioSource audioSource;

    private int currentSlideIndex = 0;

    void Start()
    {
        // Initially hide slideshow elements and the finish button
        startImage.gameObject.SetActive(true);
        preStartImage.gameObject.SetActive(true);
        displayImage.gameObject.SetActive(false);
        displayText.gameObject.SetActive(false);

        // Optional: Disable startButton here if it should not be reactivated
        startButton.gameObject.SetActive(true);
    }

    // This method is triggered by the start button
    public void StartSlideshow()
    {
        displayImage.gameObject.SetActive(true);
        displayText.gameObject.SetActive(true);
        startImage.gameObject.SetActive(false);
        preStartImage.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false); // Optionally hide the start button

        audioSource.clip = audioClip;
        audioSource.Play();

        if(slides.Length > 0)
        {
            displayImage.sprite = slides[currentSlideIndex];
            displayText.text = slideTexts[currentSlideIndex];
        }
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.anyKeyDown) && displayImage.gameObject.activeSelf) // Ensure slideshow has started
        {
            currentSlideIndex++;
            if (currentSlideIndex >= slides.Length)
            {
                //displayImage.gameObject.SetActive(false); // Optionally hide the slideshow elements
                //displayText.gameObject.SetActive(false);
                SceneManager.LoadScene("Main");
            }
            else
            {
                displayImage.sprite = slides[currentSlideIndex];
                displayText.text = slideTexts[currentSlideIndex];
            }
        }
    }
}
