using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
  public List<Enemy> currentEnemies;
  public Enemy currentTarget;

  public GameObject turret;
  private LineRenderer lineRenderer;
    public int health = 5;

  void Start()
  {
    lineRenderer = GetComponent<LineRenderer>();
  }

  void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
  }

  void Update()
  {
    if (currentTarget)
    {
      lineRenderer.SetPosition(0, turret.transform.position);
      lineRenderer.SetPosition(1, currentTarget.transform.position);
    }
  }

  void OnTriggerEnter(Collider collider)
  {
    Enemy newEnemy = collider.GetComponent<Enemy>();
    currentEnemies.Add(newEnemy);

    Debug.Log("Entered: " + currentEnemies[0]);
    currentEnemies[0].DeathEvent.AddListener(delegate { BookKeeping(newEnemy);});

    EvaluateTarget(newEnemy);

    //Debug.Log($"{collider.name} has entered");
  }

  void OnTriggerExit(Collider collider)
  {
    Enemy enemyLeaving = collider.GetComponent<Enemy>();

        //enemyLeaving.DeathEvent.RemoveListener(delegate { BookKeeping(enemyLeaving);}); //unsubscribing to the DeathEvent for this enemy .... don't care anymore :(

    Debug.Log("Amount: " + currentEnemies.Count);
    currentEnemies.Remove(enemyLeaving);  // clean up book
    EvaluateTarget(enemyLeaving);

  }

  private void BookKeeping(Enemy enemy)
  {
    Debug.Log("Book amount: " + currentEnemies[0]);
    currentEnemies.Remove(enemy);
    EvaluateTarget(enemy);

  }


  private void EvaluateTarget(Enemy enemy)
  {
    if (currentTarget == enemy)
    {
      currentTarget = null;
      lineRenderer.enabled = false;
    }


    if (currentTarget == null && currentEnemies.Count > 0)
    {
      currentTarget = currentEnemies[0];
      lineRenderer.enabled = true;
    }
  }
}
