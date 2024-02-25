using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScrene : MonoBehaviour
{
    public string sceneBuildIndex;
    public Vector2 playerPos;
    // public VectorValue playerStorage;
    
    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");
        if (other.tag == "Player") {
            print("Hit" + sceneBuildIndex);
            // playerStorage.initialValue = playerPos;
            SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
