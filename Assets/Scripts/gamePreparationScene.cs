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
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void startGame() {
        SceneManager.LoadScene("GamePlay");
    }

    public void gameDescriptionScene() {
        SceneManager.LoadScene("GameDescription");
    }
}