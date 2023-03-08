using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze1Goal : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.CompareTag("PlayerSwan")) {
            GameManager.Instance.loadMaze2();
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
