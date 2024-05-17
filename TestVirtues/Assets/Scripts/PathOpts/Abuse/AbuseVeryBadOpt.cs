using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbuseVeryBadOpt : MonoBehaviour
{
    SceneManagerr sceneManager;
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "after arriving home you turn on the tv", "", "saw on the news that the victim was", " ", "raped and murdered now the feeling", " ", "of guilty starts to overwhelm your mind", " ", "and bad thougths start to torment you" };
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
        yield return new WaitForSeconds(23f);
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
