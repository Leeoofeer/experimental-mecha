using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbuseGoodOpt : MonoBehaviour
{
    SceneManagerr sceneManager;
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "the abuser beats you up and run away", "", "the victim is unharmed and untouched", " ", "by the other side you have some broken", " ", "bones but the victim thanks you for ", " ", " everything and takes you to the hospital" };
        sceneManagerComponent2.letter = sceneManager.letter;
        sceneManagerComponent2.cursor = sceneManager.cursor;
        sceneManagerComponent2.typeSound = sceneManager.typeSound;
        sceneManagerComponent2.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent2.characters = sceneManager.characters;
        sceneManagerComponent2.showCursor = false;
        StartCoroutine(TurnOnEndButton());
    }

    IEnumerator TurnOnEndButton()
    {
        yield return new WaitForSeconds(22f);
        endButton.SetActive(true);
    }

    public void NextButton()
    {
        if (PlayerPrefs.GetInt("Karma") == 0)
        {
            SceneManager.LoadScene("NeutralDecisions");
        }
        else if (PlayerPrefs.GetInt("Karma") > 0 && PlayerPrefs.GetInt("Karma") <= 2)
        {
            SceneManager.LoadScene("GoodDecisions");
        }
        else if (PlayerPrefs.GetInt("Karma") > 2)
        {
            SceneManager.LoadScene("BestDecisions");
        }
        else if (PlayerPrefs.GetInt("Karma") >= -2 && PlayerPrefs.GetInt("Karma") < 0)
        {
            SceneManager.LoadScene("NotThatBadDecision");
        }
        else if (PlayerPrefs.GetInt("Karma") < -2)
        {
            SceneManager.LoadScene("BadDecision1");
        }
    }



}

