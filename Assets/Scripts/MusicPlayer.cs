using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        int numberMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numberMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}