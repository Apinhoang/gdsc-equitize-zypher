using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyButton : MonoBehaviour
{
    public Text moneyText; // Reference to the Text component displaying the current money count
    public int moneyAmount = 100; // Amount of money to add when the button is clicked

    public void AddMoney()
    {
        // Add the moneyAmount to the current money count
        int currentMoney = int.Parse(moneyText.text);
        currentMoney += moneyAmount;
        moneyText.text = currentMoney.ToString();
    }
}