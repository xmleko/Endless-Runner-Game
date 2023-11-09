using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    private DateTime lastReward;
    private DateTime currentTime;
    private DateTime rewardHoursInfo;
    private bool update = false;
    private readonly TimeSpan rewardTime = TimeSpan.FromHours(24);


    public TextMeshProUGUI reward;
    public TextMeshProUGUI rewardHoursInfoTxt;
    TextMeshProUGUI[] allTexts;
    Image[] allImages;
    void Start()
    {
        allTexts = FindObjectsOfType<TextMeshProUGUI>();
        allImages = FindObjectsOfType<Image>();

        foreach (Image image in allImages)
        {
            if (image.CompareTag("RewardInfo") || image.CompareTag("RewardInfo2"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("RewardInfo") || text.CompareTag("RewardInfo2"))
            {
                text.enabled = false;
            }
        }
    }

    
    void Update()
    {
        
    }

    public void CheckLastReward()
    {
        lastReward = PlayerManager.lastReward;

        currentTime = DateTime.UtcNow;
        if (currentTime - lastReward >= rewardTime)
        {
            GiveReward();
            update = true;
        }
        else
        {
            TimeSpan rewardHoursInfo = rewardTime - (currentTime - lastReward);

            TimeSpan rewardHoursInfoTo = new TimeSpan (rewardHoursInfo.Hours, rewardHoursInfo.Minutes, rewardHoursInfo.Seconds);


            foreach (Image image in allImages)
            {
                if (image.CompareTag("RewardInfo2"))
                {
                    image.enabled = true;
                    if (PlayerManager.language == "pl")
                        rewardHoursInfoTxt.text = "Nie mozesz jeszcze odebrac                     nagrody. \n" + "Czas do kolejnej nagordy : " +       rewardHoursInfoTo;
                    else
                        rewardHoursInfoTxt.text = "You can't pick up yet reward.\n" + "Come back later for:\n" + rewardHoursInfoTo;
                }
            }

            foreach (TextMeshProUGUI text in allTexts)
            {
                if (text.CompareTag("RewardInfo2"))
                {
                    text.enabled = true;
                }
            }
        }

        if (update)
        {
            PlayerManager.lastReward = currentTime;
            update = false;
        }
    }

    int RandReward(int random)
    {
        random = UnityEngine.Random.Range(0, 4);
        return random;
    }

    private void GiveReward()
    {
        int rand_reward = RandReward(0);

        if (rand_reward == 0)
        {
            if (PlayerManager.language == "pl")
                reward.text = "         Power-Up Dystans x1";
            else
                reward.text = "         Power-Up Distance x1";
            PlayerManager.powerUpDistance++;
        }
        else if (rand_reward == 1)
        {
            if (PlayerManager.language == "pl")
                reward.text = "         Power-Up Monety x1";
            else
                reward.text = "         Power-Up Coins x1";
            PlayerManager.powerUpCoins++;
        }
        else if (rand_reward == 2)
        {
            if (PlayerManager.language == "pl")
                reward.text = "         Power-Up Zycie x1";
            else
                reward.text = "         Power-Up Un-Dead x1";
            PlayerManager.powerUpUnDead++;
        }
        else if (rand_reward == 3)
        {
            if (PlayerManager.language == "pl")
                reward.text = "               Monety x10";
            else
                reward.text = "                Coins x10";

            PlayerManager.totalCoins = PlayerManager.totalCoins + 10;
        }

        foreach (Image image in allImages)
        {
            if (image.CompareTag("RewardInfo"))
            {
                image.enabled = true;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("RewardInfo"))
            {
                text.enabled = true;
            }
        }


    }

    public void RewardConfirm()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("RewardInfo") || image.CompareTag("RewardInfo2"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("RewardInfo") || text.CompareTag("RewardInfo2"))
            {
                text.enabled = false;
            }
        }
    }
}
