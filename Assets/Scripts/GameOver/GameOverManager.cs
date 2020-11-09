using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Button start;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = start.GetComponent<Button>();

        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene("SampleScene");

    }
}
