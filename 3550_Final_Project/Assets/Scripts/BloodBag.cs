using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreKeeper scorekeeper = other.GetComponent<ScoreKeeper>();
        print("oop");

        if (scorekeeper != null)
        {
            print("this works");
            scorekeeper.collected();
            gameObject.SetActive(false);
        }
    }
}
