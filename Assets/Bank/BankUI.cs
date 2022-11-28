using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BankUI : MonoBehaviour
{
    BankHandler bank;
    TMP_Text textMesh;

    void Start()
    {
        bank = FindObjectOfType<BankHandler>();
        textMesh = GetComponent<TMP_Text>();
        Debug.Log(textMesh);
        Debug.Log(bank);
    }

    public void DisplayBankBalance(int value)
    {
        textMesh.text = "Gold: " + value.ToString();
    }

}
