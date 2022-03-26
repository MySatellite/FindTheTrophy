using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamePreparationScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("GameDescription");
        }
    }

    public void startGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void gameDescriptionScene() {
        SceneManager.LoadScene("GameDescription");
    }
}