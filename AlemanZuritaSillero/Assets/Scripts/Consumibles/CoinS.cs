using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinS : MonoBehaviour
{
    public GameObject coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(coinSound);
            IncreaseCoins.numbersOfCoins += 1;
            Destroy(gameObject);
        }
    }
}
