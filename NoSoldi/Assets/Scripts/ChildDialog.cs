using System.Collections;
using UnityEngine;
using TMPro;

public class ChildDialog : MonoBehaviour
{
    public TextMeshProUGUI parentsDialog;
    public string[] dLines;
    public float textSpeed;
    private int index;

    void Start()
    {
        parentsDialog.text = "";
        StartDialog();
    }

    

    void StartDialog()
    {
        index = 0;
        StartCoroutine(DisplayLine());
    }

    IEnumerator DisplayLine()
    {
        foreach (char c in dLines[index].ToCharArray())
        {
            parentsDialog.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(2); 
        NextLine(); 
    }

    void NextLine()
    {
        if (index < dLines.Length - 1)
        {
            index++;
            parentsDialog.text = "";
            StartCoroutine(DisplayLine());
        }
        else
        {
            parentsDialog.text = "";
            gameObject.SetActive(false);
        }
    }
}
