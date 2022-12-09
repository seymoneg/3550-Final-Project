using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
 //You may consider adding a rigid body to the zombie for accurate physics simulation
 //This will be the zombie's speed. Adjust as necessary.
 public float speed = 0.2f;
 void Start ()
 {
      //At the start of the game, the zombies will find the gameobject called wayPoint.
 
 }
 
 void Update ()
 {
      //wayPointPos = new Vector3(PlayerObject.transform.position.x, transform.position.y, wayPoint.transform.position.z);
      //Here, the zombie's will follow the waypoint.
      
      transform.position = Vector3.MoveTowards(((GameObject.Find("PillarObject").transform.position)), (GameObject.Find("PlayerObject").transform.position), speed * Time.deltaTime);
      //transform.position=GameObject.Find("PlayerObject").transform.position;
 }
}