using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    private float speed = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(((GameObject.Find("HunterObject").transform.position)), (GameObject.Find("PlayerObject").transform.position), speed * Time.deltaTime);

        
    }

    private void OnCollisionEnter2D(Collision2D otherObj)
    {
         StartCoroutine(waiter());

    IEnumerator waiter()
    {
        if (otherObj.gameObject.CompareTag("Player")) {
            print("collision");
            yield return new WaitForSeconds(1);
            //this.transform.position = new Vector3(-26.77f,6.64f,0);
            //otherObj.transform.position = new Vector3(0,0,0);
        }
    }

    }
}
