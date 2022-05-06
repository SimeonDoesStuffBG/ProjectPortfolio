using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantValues : MonoBehaviour
{
    private static int money = 75;

    public  static void OnStart()
    {
        money = 75;
    }
    public static void AddMoney(int moneyAdded){
        money += moneyAdded;
        UI_Functions.SetMoney();
    }

    public static void SubtractMoney(int moneyTaken){
        if (moneyTaken <= money){
            money -= moneyTaken;
            UI_Functions.SetMoney();
        }
    }

    public static string GetMoney(){
        return money.ToString();
    }
    public static bool CanAfford(int moneyTested){
        return moneyTested <= money;
    } 
}
