using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}
    public GameObject titleScreen;
    public GameObject creditsScreen;
    public GameObject tutorialScreen;
    public GameObject endScreen;
    public GameObject maze1;
    public GameObject maze2;
    public GameObject maze3;
    public GameObject canvas;
    public GameObject eventSystem;
    public GameObject curtain;
    private bool raiseLower = false;


// Reused from previous lab

    void Awake() {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                DontDestroyOnLoad(canvas);
                DontDestroyOnLoad(eventSystem);
            } else {
                Destroy(gameObject);
                Destroy(canvas);
                Destroy(eventSystem);
            }

        }

    IEnumerator ColorLerpFunction(bool fadeout, float duration)
    {
        float time = 0;
        raiseLower = true;
        Image curtainImg = curtain.GetComponent<Image>();
        Color startValue;
        Color endValue;
        if (fadeout) {
            startValue = new Color(0, 0, 0, 0);
            endValue = new Color(0, 0, 0, 1);
        } else {
            startValue = new Color(0, 0, 0, 1);
            endValue = new Color(0, 0, 0, 0);
        }

        while (time < duration)
        {
            curtainImg.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        curtainImg.color = endValue;
        raiseLower = false;
    }

     IEnumerator LoadYourAsyncScene(string scene)
     {
        StartCoroutine(ColorLerpFunction(true, 1));

        while (raiseLower)
        {
            yield return null;
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        StartCoroutine(ColorLerpFunction(false, 1));
    }

    public void TutorialScreen() {
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void CreditsScreen() {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void ReturnToStartScreen() {
        creditsScreen.SetActive(false);
        tutorialScreen.SetActive(false);
        titleScreen.SetActive(true);
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
