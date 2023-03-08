using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivation : MonoBehaviour
{

    public int level = 1;


    public void OnTriggerEnter2D(Collider2D collider2D) {
        print("Entered..");
        if (collider2D.CompareTag("PlayerSwan")) {
            if (level == 1) {
                GameManager.Instance.DialogShow("Try to reach the end of the maze while avoiding mean ducks.");
            } else if (level == 2) {
                GameManager.Instance.DialogShow("The fowl are faster in this area. Be wary!");
            } else {
                GameManager.Instance.DialogShow("You're nearing the end, but this area is overrun with fowl.");
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collider2D) {
        if (collider2D.gameObject.CompareTag("PlayerSwan")) {
            GameManager.Instance.DialogHide();
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
