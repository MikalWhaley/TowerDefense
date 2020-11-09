using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastTower : MonoBehaviour
{
    public GameObject tower;
    public int health = 5;
    public Tower towerClass;
    public int currentEnemies;
    public Purse purse;

    public AudioClip death;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Cylinder");
        purse = GameObject.Find("Purse").GetComponent<Purse>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Damage taken");
        health -= 1;
        if(health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log(health);
        
        source.PlayOneShot(death, 1F);
        Destroy(collision.gameObject);
        purse.removeEnemy();
    }
}
