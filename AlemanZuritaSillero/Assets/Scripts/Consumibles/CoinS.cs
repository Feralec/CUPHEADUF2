using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinS : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IncreaseCoins.numbersOfCoins += 1;
        Destroy(gameObject);
    }
}
