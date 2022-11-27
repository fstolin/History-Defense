using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankHandler : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; }  }

    private void Awake()
    {
        currentBalance = startingBalance;
    }


    // Deposit to the bank
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    // Withdraw from the bank
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}
