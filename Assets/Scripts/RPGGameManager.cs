using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        // Exit the application if the user presses the "escape" key

        // Does not work when playing from inside the Unity editor
        if (Input.GetKey("escape"))
        {
          Application.Quit();
        }
      }
}
