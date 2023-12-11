using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeGain : MonoBehaviour
{
    private GameObject player;
    private PlayerInfo playerInfo;

    private float price = 1f;
    [SerializeField] private GameObject textObject;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Play");
        playerInfo = player.GetComponent<PlayerInfo>();
        textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
        updateDisplay();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Play") && playerInfo.grass >= price)
        {
            playerInfo.gain++;
            playerInfo.grass -= price;
            price *= 1.5f;
            updateDisplay();
        }
    }

    private void updateDisplay ()
    {
        string priceStr = ""; 
        if (price > 1000000000)
        {
            priceStr = (Mathf.Floor(price / 1000000000 * 10)/10).ToString() + "b";


        } else if (price > 1000000)
        {
            priceStr = (Mathf.Floor(price / 1000000 * 10)/10).ToString() + "m";
        } else if (price > 1000)
        {
            priceStr = (Mathf.Floor(price / 1000 * 10)/10).ToString() + "k";
        } else
        {
            priceStr = (Mathf.Floor(price*10)/10).ToString();
        }

        textMeshPro.text = priceStr;
    }
}
