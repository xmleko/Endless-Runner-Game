using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{

    Image[] allImages;
    TextMeshProUGUI[] allText;
    public Sprite imagetruesprite;
    public Sprite imagefalseprite;
    public TextMeshProUGUI mission1;
    public Image image1;
    public TextMeshProUGUI mission2;
    public Image image2;
    public TextMeshProUGUI mission3;
    public Image image3;
    public TextMeshProUGUI mission4;
    public Image image4;
    public TextMeshProUGUI mission5;
    public Image image5;
    public TextMeshProUGUI mission6;
    public Image image6;
    int page = 1;


    void Start()
    {
        allImages = FindObjectsOfType<Image>();
        allText = FindObjectsOfType<TextMeshProUGUI>();

        foreach (Image image in allImages)
        {
            if (image.CompareTag("Mission2") || image.CompareTag("Mission3") || image.CompareTag("Mission4") || image.CompareTag("Mission5") || image.CompareTag("Mission6"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("Mission2") || text.CompareTag("Mission3") || text.CompareTag("Mission4") || text.CompareTag("Mission5") || text.CompareTag("Mission6"))
            {
                text.enabled = false;
            }
        }

        if (PlayerManager.mission1)
        {
            if (PlayerManager.language == "pl")
                mission1.text = "Status : Zaliczone";
            else
                mission1.text = "Status: Passed";
            image1.sprite = imagetruesprite;
        }
        else
        {
            if (PlayerManager.language == "pl")
                mission1.text = "Status : Niezaliczone";
            else
                mission1.text = "Status: Failed";
            image1.sprite = imagefalseprite;
        }

        if (PlayerManager.mission2)
        {
            if (PlayerManager.language == "pl")
                mission2.text = "Status : Zaliczone";
            else
                mission2.text = "Status: Passed";
            image2.sprite = imagetruesprite;
        }
        else
        {
            if (PlayerManager.language == "pl")
                mission2.text = "Status : Niezaliczone";
            else
                mission2.text = "Status: Failed";
            image2.sprite = imagefalseprite;
        }

        if (PlayerManager.mission3)
        {
            if (PlayerManager.language == "pl")
                mission3.text = "Status : Zaliczone";
            else
                mission3.text = "Status: Passed";
            image3.sprite = imagetruesprite;
        }
        else
        {
            if (PlayerManager.language == "pl")
                mission3.text = "Status : Niezaliczone";
            else
                mission3.text = "Status: Failed";
            image3.sprite = imagefalseprite;
        }

        if (PlayerManager.mission4)
        {
            if (PlayerManager.language == "pl")
                mission4.text = "Status : Zaliczone";
            else
                mission4.text = "Status: Passed";
            image4.sprite = imagetruesprite;
        }
        else
        {
            if (PlayerManager.language == "pl")
                mission4.text = "Status : Niezaliczone";
            else
                mission4.text = "Status: Failed";
            image4.sprite = imagefalseprite;
        }

        if (PlayerManager.mission5)
        {
            if (PlayerManager.language == "pl")
                mission5.text = "Status : Zaliczone";
            else
                mission5.text = "Status: Passed";
            image5.sprite = imagetruesprite;
        }
        else
        {
            if (PlayerManager.language == "pl")
                mission5.text = "Status : Niezaliczone";
            else
                mission5.text = "Status: Failed";
            image5.sprite = imagefalseprite;
        }

        if (PlayerManager.mission6)
        {
            if (PlayerManager.language == "pl")
                mission6.text = "Status : Zaliczone";
            else
                mission6.text = "Status: Passed";
            image6.sprite = imagetruesprite;
        }
        else
        {
            if (PlayerManager.language == "pl")
                mission6.text = "Status : Niezaliczone";
            else
                mission6.text = "Status: Failed";
            image6.sprite = imagefalseprite;
        }

    }

    public void ButtonNext()
    {

        page++;

        if (page > 6)
            page = 6;

        if (page == 2)
        {
            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission1"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission1"))
                {
                    text.enabled = false;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission2"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission2"))
                {
                    text.enabled = true;
                }
            }
        }

        if (page == 3)
        {
            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission2"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission2"))
                {
                    text.enabled = false;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission3"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission3"))
                {
                    text.enabled = true;
                }
            }
        }

        if (page == 4)
        {
            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission3"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission3"))
                {
                    text.enabled = false;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission4"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission4"))
                {
                    text.enabled = true;
                }
            }
        }

        if (page == 5)
        {
            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission4"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission4"))
                {
                    text.enabled = false;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission5"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission5"))
                {
                    text.enabled = true;
                }
            }
        }

        if (page == 6)
        {
            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission5"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission5"))
                {
                    text.enabled = false;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission6"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission6"))
                {
                    text.enabled = true;
                }
            }
        }

    }

    public void ButtonPrevious()
    {

        page--;

        if (page <= 0)
            page = 1;

        if (page == 1)
        {

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission1"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission1"))
                {
                    text.enabled = true;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission2"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission2"))
                {
                    text.enabled = false;
                }
            }
        }

        if (page == 2)
        {

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission2"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission2"))
                {
                    text.enabled = true;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission3"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission3"))
                {
                    text.enabled = false;
                }
            }
        }

        if (page == 3)
        {

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission3"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission3"))
                {
                    text.enabled = true;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission4"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission4"))
                {
                    text.enabled = false;
                }
            }
        }

        if (page == 4)
        {

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission4"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission4"))
                {
                    text.enabled = true;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission5"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission5"))
                {
                    text.enabled = false;
                }
            }
        }

        if (page == 5)
        {

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission5"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission5"))
                {
                    text.enabled = true;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission6"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission6"))
                {
                    text.enabled = false;
                }
            }
        }

        if (page == 6)
        {

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission5"))
                {
                    image.enabled = true;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission5"))
                {
                    text.enabled = true;
                }
            }

            foreach (Image image in allImages)
            {
                if (image.CompareTag("Mission6"))
                {
                    image.enabled = false;
                }
            }

            foreach (TextMeshProUGUI text in allText)
            {
                if (text.CompareTag("Mission6"))
                {
                    text.enabled = false;
                }
            }
        }
    }
}
