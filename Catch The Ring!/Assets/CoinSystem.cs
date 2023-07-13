using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] private int coins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {
            Debug.Log("+Coin");
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
