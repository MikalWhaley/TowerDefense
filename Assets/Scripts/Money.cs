using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int balance = 0;

    public TextMeshProUGUI displayMoney;

    // Start is called before the first frame update
    void Start()
    {
        displayMoney.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addmoney()
    {
        balance += 100;
        displayMoney.text = balance.ToString();
    }
}
