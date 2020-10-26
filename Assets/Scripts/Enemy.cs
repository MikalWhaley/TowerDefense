using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Waypoints[] navPoints;
    private Transform target;
    private Vector3 direction;
    public float amplify = 1;
    private int index = 0;
    private bool move = true;
    private int health = 3;

    public Money money;



  // Start is called before the first frame update
  void Start()
  {
        

        //Place our enemy at the start point
        transform.position = navPoints[index].transform.position;
        
        NextWaypoint();

        money = GameObject.Find("MoneyManager").GetComponent<Money>();
        //Move towards the next waypoint
        //Retarget to the following waypoint when we reach our current waypoint
        //Repeat through all of the waypoints until you reach the end
    }

  // Update is called once per frame
  void Update()
  {
    if (move)
    {
      transform.Translate(direction.normalized * Time.deltaTime * amplify);

      if ((transform.position - target.position).magnitude < .1f)
      {
        NextWaypoint();
      }
    }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                health = health - 1;
                Debug.Log(health);
                if (health < 1)
                {
                    money.addmoney();
                    Destroy(gameObject);
                }
            }
        }

    }


    private void NextWaypoint()
  {
    if (index < navPoints.Length - 1)
    {
      index += 1;
      target = navPoints[index].transform;
      direction = target.position - transform.position;
    }
    else
    {
      move = false;
    }
  }


}
