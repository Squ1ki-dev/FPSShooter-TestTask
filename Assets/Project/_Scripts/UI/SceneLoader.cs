using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SceneLoader : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _buttonClickAudio;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    public void OpenScene(int sceneIndex)
    {
        StartCoroutine(WaitSoundAndLoadScene(sceneIndex));
    }

    private IEnumerator WaitSoundAndLoadScene(int sceneIndex)
    {
        _audioSource.PlayOneShot(_buttonClickAudio);
        yield return new WaitForSeconds(_buttonClickAudio.length);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame() => Application.Quit();
}
