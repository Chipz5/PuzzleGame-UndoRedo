using UnityEngine;

public class AudioPlayer :  MonoBehaviour, IObserver
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Invoker").GetComponent<AudioSource>();
    }
    public void OnNotify(int id)
    {
        audioSource.Play();
    }

}
