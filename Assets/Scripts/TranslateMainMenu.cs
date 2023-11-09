using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TranslateMainMenu : MonoBehaviour
{

    public TextMeshProUGUI play;
    public TextMeshProUGUI bestscore;
    public TextMeshProUGUI statistics;
    public TextMeshProUGUI mission;
    public TextMeshProUGUI reward;
    public TextMeshProUGUI reward2;
    public TextMeshProUGUI reward3;
    public TextMeshProUGUI quit;
    public TextMeshProUGUI read;
    public TextMeshProUGUI read2;
    public TextMeshProUGUI language;
    public TextMeshProUGUI language2;
    public TextMeshProUGUI language3;
    public TextMeshProUGUI language4;
    public TextMeshProUGUI shop;

    void Start()
    {

    }


    void Update()
    {
        Translate();
    }

    void Translate()
    {
        if (PlayerManager.language == "pl")
        {
            play.text = "Zagraj";
            bestscore.text = "Najlepsze wyniki";
            statistics.text = "Statystyki";
            mission.text = "Zadania";
            reward.text = "Dzienna nagroda";
            reward2.text = " Pomyslnie odebrano nagrode.\r\n        Twoja nagroda to :";
            quit.text = "Wyjdz";
            read.text = "Wczytaj postep";
            read2.text = "   \r\n\r\n                  Sukces !\r\n    Pomyslnie wczytano dane.";
            language.text = "Jezyk";
            shop.text = "Sklep";
            language2.text = "Angielski";
            language3.text = "Polski";
            language4.text = "            Wybierz jezyk";

        }
        else
        {
            play.text = "Play";
            bestscore.text = "Best Score";
            statistics.text = "Statistics";
            mission.text = "Mission";
            reward.text = "Daily reward";
            reward2.text = " Successfully received award.\r\n           Your reward is :";
            quit.text = "Quit";
            read.text = "Load";
            read2.text = "   \r\n\r\n                  Succes !\r\n    Data loaded successfully.";
            language.text = "Language";
            shop.text = "Shop";
            language2.text = "English";
            language3.text = "Polish";
            language4.text = "           Choose language";
        }
    }
}
