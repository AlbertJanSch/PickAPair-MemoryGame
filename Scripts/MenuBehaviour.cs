/* Pick a Pair - Memory Game
 * MenuBehaviour.cs Script
 * Albert-Jan Scherrenburg
 * Student Number 1684118 */

// Used Libraries
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Very simple script that are called by Menu buttons to switch between scenes
public class MenuBehaviour : MonoBehaviour {
    public void TriggerMenuBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Level");
                break;
            case (1):
                Application.Quit();
                break;
            case (2):
                SceneManager.LoadScene("Menu");
                break;
        }
    }
}
