using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Purse : MonoBehaviour
{
  public int currentCash = 1000;

  public TextMeshProUGUI purseText;
    public EnemyManager e;
    static int currentEnemies = 0;
    public AudioClip death;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        SetCash();
        source = GetComponent<AudioSource>();

        e = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();


        foreach (Group group in e.enemyWave.enemyGroups)
        {
            currentEnemies += group.amountOfEnemies;
        }


    }

    public void removeEnemy()
    {
        currentEnemies -= 1;
        source.PlayOneShot(death, 1F);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentEnemies == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void SetCash()
    {
      purseText.text = $"${currentCash}";
    }

    public void AddCash(int amountOfCash)
    {
      currentCash += amountOfCash;
      SetCash();
    }

    public bool PlaceTower(int amountOfCashRequired)
    {
      if (currentCash - amountOfCashRequired >= 0)  // Do I have enough cash?
      {
        currentCash -= amountOfCashRequired; //Update Purse Amount
        SetCash();  // Update GUI
        return true;  // Yea!! Tower can be added
      }

      return false;  //Not enough ... we broke
    }
}
