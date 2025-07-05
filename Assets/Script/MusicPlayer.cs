using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("MusicPlayer initialized and playing.");
            }
            else
            {
                Debug.LogWarning("AudioSource is null!");
            }

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Loaded scene: " + scene.name);
        if (audioSource != null)
        {
            Debug.Log("Music isPlaying: " + audioSource.isPlaying);
        }
        else
        {
            Debug.LogWarning("AudioSource is missing!");
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
