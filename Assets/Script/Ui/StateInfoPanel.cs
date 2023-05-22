using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateInfoPanel : MonoBehaviour
{
   public GameObject stateInfoPanelText;
   public GameObject nextLevelButton;
   public TextMeshProUGUI sceneText;
   public int sceneIndex;

   public void OpenScene()
   {
     SceneManager.LoadScene(sceneIndex);
   }
}
