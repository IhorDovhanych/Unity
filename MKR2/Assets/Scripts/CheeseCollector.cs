using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheeseCollector : MonoBehaviour
{
    private int points = 0;
    public TMP_Text pointsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            points++;
            Destroy(other.gameObject);
            pointsText.text = "Сиру зібрано: " + points.ToString();
        }
    }
}




