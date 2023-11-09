using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TranslateShop : MonoBehaviour
{

    public TextMeshProUGUI back;
    public TextMeshProUGUI succes;
    public TextMeshProUGUI fail;

    void Start()
    {
        Translate();
    }


    void Update()
    {
        
    }

    void Translate()
    {
        if (PlayerManager.language == "pl")
        {
            back.text = "Wstecz";
            succes.text = "Pomyslnie zakupiles przedmiot.";
            fail.text = "Nie posiadasz wystarczajacej \r\n              ilosci monet.";
        }
        else
        {
            back.text = "Back";
            succes.text = "     You have successfully \n        purchased the item.";
            fail.text = "  You don't have enough coins.";
        }
    }
}
