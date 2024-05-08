using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Check where the player clicked on the capsule
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Get the tag of the clicked GameObject
            string clickedTag = hit.collider.gameObject.tag;

            // Load the scene based on the clicked tag
            switch (clickedTag)
            {
                case "play":
                    // Load the level 1 scene
                    SceneManager.LoadScene("level1");
                    break;
                case "levels":
                    // Load the levels selection scene
                    SceneManager.LoadScene("levels");
                    break;
                 case "close":
                    // Quit the application
                    Application.Quit();
                    break;
                default:
                    // Load the scene corresponding to the clicked tag
                    SceneManager.LoadScene(clickedTag);
                    break;
            }
        }
    }
}
