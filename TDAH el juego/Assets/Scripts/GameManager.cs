using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject managerObject = new GameObject("GameManager");
                _instance = managerObject.AddComponent<GameManager>();
                DontDestroyOnLoad(managerObject);
            }
            return _instance;
        }
    }
    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    // Funcionalidad abajo
    private int mainGoalClicks = 199;
    private int currentClicks = 0;
    public GameObject buttonSideQuest;
    public GameObject SideQuestContainer;
    public TextMeshProUGUI sideQuestCounter;
    private int quantitySideQuests = 0;

    public void UpdateSideQuestCounter()
    {
        quantitySideQuests++;
        sideQuestCounter.text = "Sidequest completadas: " + quantitySideQuests;
    }

    public void PlayerWalked()
    {
        
        currentClicks ++;
        Debug.Log("Player walked. Steps Walked: " + currentClicks);
        CheckCurrentClicks(currentClicks);
        if (currentClicks >= mainGoalClicks)
        {
            Debug.Log("Has ganado");
        }
    }

    private void CheckCurrentClicks(int currentClicks)
    {
        switch (currentClicks)
        {
            case 15:
                CreateSideQuest(0,1);
                break;
            case 29:
                CreateSideQuest(0,2);
                break;
            case 41:
                CreateSideQuest(0, 2);
                CreateSideQuest(1, 1);
                break;
            case 62:
                CreateSideQuest(0, 1);
                CreateSideQuest(1, 2);
                break;
            case 83:
                CreateSideQuest(0, 1);
                CreateSideQuest(2, 1);
                //CREAR BOSQUE AQUI
                break;
            case 104:
                CreateSideQuest(0, 1);
                CreateSideQuest(1, 1);
                CreateSideQuest(2, 1);
                break;
            case 115:
                CreateSideQuest(2, 2);
                break;
            case 126:
                CreateSideQuest(0, 1);
                CreateSideQuest(2, 2);
                break;
            case 137:
                CreateSideQuest(1, 1);
                CreateSideQuest(2, 2);
                //CREAR CUEVA AQUI
                break;
            case 158:
                CreateSideQuest(2, 3);
                break;
            default:
                //Debug.LogWarning("Valor de currentClicks: " + currentClicks + " no manejado en el switch.");
                break;
        }
    }

    public void CreateSideQuest(int buttonIndex, int quantity)
    {
        Debug.Log("Creando " + quantity + " sidequests de nivel " + (buttonIndex + 1));
        for (int i = 0; i < quantity; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, SideQuestContainer.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = buttonIndex;
            newButton.name = "SideQuest LvL" + (buttonIndex + 1);
        }        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { PlayerWalked(); }
    }
}
