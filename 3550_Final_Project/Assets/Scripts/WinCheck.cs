using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
      ScoreKeeper scorekeeper = collider.GetComponent<ScoreKeeper>();

      if (scorekeeper != null)
      {
          //Debug.Log(scorekeeper.score);
          if(scorekeeper.score >= 10)
          {
            //change scene to win
            SceneManager.LoadScene("YouWin");
          }
      }

    }
}
