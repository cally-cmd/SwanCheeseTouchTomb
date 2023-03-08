using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public int level;

    public void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.CompareTag("PlayerSwan")) {
            if (level == 1) {
                GameManager.Instance.loadMaze2();
            } else if (level == 2) { 
                GameManager.Instance.loadMaze3();
            } else {
                print("to do still");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
