using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // language
    Image[] allImages;
    TextMeshProUGUI[] allText;
    void Start()
    {
        allImages = FindObjectsOfType<Image>();
        allText = FindObjectsOfType<TextMeshProUGUI>();

        foreach (Image image in allImages)
        {
            if (image.CompareTag("Language"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("Language"))
            {
                text.enabled = false;
            }
        }
    }


    void Update()
    {

    }

    public void ShowLanguage()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("Language"))
            {
                image.enabled = true;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("Language"))
            {
                text.enabled = true;
            }
        }
    }

    public void LanguagePolish()
    {
        PlayerManager.language = "pl";
        Close();
    }

    public void LanguageEnglish()
    {
        PlayerManager.language = "en";
        Close();
    }

    void Close()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("Language"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("Language"))
            {
                text.enabled = false;
            }
        }
    }
}
