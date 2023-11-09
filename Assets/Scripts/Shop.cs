using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TextMeshProUGUI coins;
    public TextMeshProUGUI distance;
    public TextMeshProUGUI undead;
    public TextMeshProUGUI coinsTotal;


    // confirm shop
    Image[] allImages;
    TextMeshProUGUI[] allText;

    int countCoins = 0;
    int countDistance = 0;
    int countUnDead = 0;
    void Start()
    {
        if (PlayerManager.language == "pl")
            coinsTotal.text = "Monet : " + PlayerManager.totalCoins;
        else
            coinsTotal.text = "Coins : " + PlayerManager.totalCoins;
        allImages = FindObjectsOfType<Image>();
        allText = FindObjectsOfType<TextMeshProUGUI>();

        foreach (Image image in allImages)
        {
            if (image.CompareTag("ShopConfirm"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("ShopConfirm"))
            {
                text.enabled = false;
            }
        }

        foreach (Image image in allImages)
        {
            if (image.CompareTag("ShopCancel"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("ShopCancel"))
            {
                text.enabled = false;
            }
        }
    }

    void Update()
    {

    }

    public void IncreaseCoins()
    {
        countCoins++;
        coins.text = countCoins.ToString();
    }

    public void DecreaseCoins()
    {
        if (countCoins <= 0)
        {}
        else
            countCoins--;

        coins.text = countCoins.ToString();
    }

    public void IncreaseDistance()
    {
        countDistance++;
        distance.text = countDistance.ToString();
    }

    public void DecreaseDistance()
    {
        if (countDistance <= 0)
        { }
        else
            countDistance--;

        distance.text = countDistance.ToString();
    }

    public void IncreaseUnDead()
    {
        countUnDead++;

        undead.text = countUnDead.ToString();
    }

    public void DecreaseUnDead()
    {
        if (countUnDead <= 0)
        { }
        else
            countUnDead--;

        undead.text = countUnDead.ToString();
    }


    public void BuyCoinsPowerUp()
    {

        if (countCoins == 0)
        {

        }
        else if (PlayerManager.totalCoins >= 50 * countCoins)
        {
            PlayerManager.totalCoins = PlayerManager.totalCoins - (50 * countCoins);
            PlayerManager.powerUpCoins = PlayerManager.powerUpCoins + countCoins;
            Debug.Log("Pomyslnie, obecny stan : " + PlayerManager.powerUpCoins);
            ShopShowInformation();
            if (PlayerManager.language == "pl")
                coinsTotal.text = "Monet : " + PlayerManager.totalCoins;
            else
                coinsTotal.text = "Coins : " + PlayerManager.totalCoins;
        }
        else
        {
            Debug.Log("Brak monet.");
            ShopCancel();
        }
    }

    public void BuyDistancePowerUp()
    {
        if (countDistance == 0)
        {

        }
        else if (PlayerManager.totalCoins >= 50 * countDistance)
        {
            PlayerManager.totalCoins = PlayerManager.totalCoins - (50 * countDistance);
            PlayerManager.powerUpDistance = PlayerManager.powerUpDistance + countDistance;
            Debug.Log("Pomyslnie, obecny stan : " + PlayerManager.powerUpDistance);
            ShopShowInformation();
            if (PlayerManager.language == "pl")
                coinsTotal.text = "Monet : " + PlayerManager.totalCoins;
            else
                coinsTotal.text = "Coins : " + PlayerManager.totalCoins;
        }
        else
        {
            Debug.Log("Brak monet.");
            ShopCancel();
        }
    }

    public void BuyUnDeadPowerUp()
    {
        if (countUnDead == 0)
        {

        }
        else if (PlayerManager.totalCoins >= 50 * countUnDead)
        {
            PlayerManager.totalCoins = PlayerManager.totalCoins - (50 * countUnDead);
            PlayerManager.powerUpUnDead = PlayerManager.powerUpUnDead + countUnDead;
            Debug.Log("Pomyslnie, obecny stan : " + PlayerManager.powerUpUnDead);
            ShopShowInformation();
            if (PlayerManager.language == "pl")
                coinsTotal.text = "Monet : " + PlayerManager.totalCoins;
            else
                coinsTotal.text = "Coins : " + PlayerManager.totalCoins;
        }
        else
        {
            Debug.Log("Brak monet.");
            ShopCancel();
        }
    }

    public void ShopShowInformation()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("ShopConfirm"))
            {
                image.enabled = true;
            }
        }
        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("ShopConfirm"))
            {
                text.enabled = true;
            }
        }
    }

    public void ShopCancel()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("ShopCancel"))
            {
                image.enabled = true;
            }
        }
        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("ShopCancel"))
            {
                text.enabled = true;
            }
        }
    }

    public void ShopConfirmInformation()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("ShopConfirm") || image.CompareTag("ShopCancel"))
            {
                image.enabled = false;
            }
        }
        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("ShopConfirm") || text.CompareTag("ShopCancel"))
            {
                text.enabled = false;
            }
        }
    }
}
