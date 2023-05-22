using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   private int sceneIndex;

   [SerializeField] private TextMeshProUGUI levelProgress;

   public void Start()
   {
      int allScene = SceneManager.sceneCountInBuildSettings;
      sceneIndex = PlayerPrefs.GetInt("Level", 1);
      levelProgress.text = sceneIndex + " / " + allScene;
   }

   public void StartGame()
   {
      SceneManager.LoadScene(sceneIndex);
   }
}
