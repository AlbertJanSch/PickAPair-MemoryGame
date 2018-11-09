/* Pick a Pair - Memory Game
 * MusicPlayerScript.cs Script
 * Albert-Jan Scherrenburg
 * Student Number 1684118 */

// Used Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class used to start background Music
public class MusicPlayerScript : MonoBehaviour {
    
    static MusicPlayerScript instance = null;
    
    // Checks if music is playing. If so keep it going, if not start music
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
