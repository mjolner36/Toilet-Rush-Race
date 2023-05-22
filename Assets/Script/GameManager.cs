using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera camera;

    [Header("Level Objects")] 
    [SerializeField] private PlayerPlace[] places;

    [SerializeField] private PlayerBase[] playerBases;
    private PlayerSO[] playersSO;
    [SerializeField] public int linesToStart = 2;

    [Header("Canvas")] [SerializeField] private StateInfoPanel stateInfoPanel;


    public int finishDrawLine = 0;

    private void Awake()
    {
        Instance = this;
        playersSO = Resources.LoadAll<PlayerSO>("");
    }

    private void Start()
    {
        camera = Camera.main;
        foreach (var place in places)
        {
            place.endDraw += Play;
            foreach (var playerSO in playersSO)
            {
                if (place.ID() != playerSO.id) continue;
                place.Init(playerSO);
                break;
            }
        }

        foreach (var playerBase in playerBases)
        {
            foreach (var playerSO in playersSO)
            {
                if (playerBase.ID() != playerSO.id) continue;
                playerBase.Init(playerSO);
                break;
            }
        }
    }

    public void WinState()
    {
        stateInfoPanel.gameObject.SetActive(true);
        stateInfoPanel.stateInfoPanelText.GetComponent<TextMeshProUGUI>().text = "You Win";
        stateInfoPanel.sceneText.text = "Next Level";
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            stateInfoPanel.sceneIndex = 0;
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
            return;
        }

        stateInfoPanel.sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.Save();
    }

    public void LoseState()
    {
        foreach (var place in places)
        {
            Destroy(place.gameObject);
        }

        stateInfoPanel.gameObject.SetActive(true);
        stateInfoPanel.stateInfoPanelText.GetComponent<TextMeshProUGUI>().text = "You Lose";
        stateInfoPanel.sceneIndex = SceneManager.GetActiveScene().buildIndex;
        stateInfoPanel.sceneText.text = "Repeat";
    }

    private void Play()
    {
        finishDrawLine++;
        if (linesToStart != finishDrawLine) return;
        foreach (var place in places)
        {
            place.GetComponent<Animator>().SetBool("moving", true);
            place.StartMove();
        }
    }
}