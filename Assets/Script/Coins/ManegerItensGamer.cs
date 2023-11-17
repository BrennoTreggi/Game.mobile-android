using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Script.Ultts.Singleton;

public class ManegerItensGamer : Singleton<ManegerItensGamer>
{
    [Header("Foguete")]

    public SO_Float foguete;
    public TextMeshProUGUI Text_Foguete;

    [Header("Coins")]

    public SO_Inst_Coins coins;
    public TextMeshProUGUI Text_Coins;


    private void Start()
    {
        Reset();

    }

     private void Reset()
    {
        foguete.value = 0;
        coins.valor = 0;
        UpdateUI();
       
    }

    public void AdsCoin(int amount = 50) 
    {
        coins.valor += amount;
        UpdateUI();

    }

    public void Adsfoguete(int amout = 500)
    {


        foguete.value += amout;
        UpdateUI();

    }




    private void UpdateUI()
    {
        //TextMeshProUGUI.text = coins.ToString();
       //UIGameManeger.UpdateTextCoins(coins.ToString());
   

    }

}
