using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        int numMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
