using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClickHandler : MonoBehaviour
{
    public int indicator = 0;
    private int[] requiredClicks = { 5, 8, 13 };
    private int currentClicks = 0;
    private TextMeshProUGUI myText;
    public GameManager gameManager;
    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(HandleButtonClick);
        }
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myText.text = "Quest\r\n" + currentClicks + "/" + requiredClicks[indicator];
    }

    private void HandleButtonClick()
    {
        currentClicks++;
        int clicksNeeded = requiredClicks[indicator];
        myText.text = "Quest\r\n" + currentClicks + "/" + clicksNeeded;
        if (currentClicks >= clicksNeeded)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.UpdateSideQuestCounter(clicksNeeded);
            }
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
    }
}
