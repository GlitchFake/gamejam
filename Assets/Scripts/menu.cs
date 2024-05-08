using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu : MonoBehaviour
{
      private void OnMouseDown()
    {
        // Load the "Level1" scene
        SceneManager.LoadScene("Level1");
    }

}
