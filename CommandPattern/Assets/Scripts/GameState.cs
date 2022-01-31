
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    List<IObserver> observers;
    int numberOfObservers;
    IObserver audioObserver;
    IObserver cheat;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject("AudioPlayer");
        audioObserver = gameObject.AddComponent<AudioPlayer>();
        gameObject = new GameObject("Cheat");
        cheat = gameObject.AddComponent<Cheat>();
        addObserver(audioObserver);
        addObserver(cheat);
    }

    public void Awake()
    {
        observers = new List<IObserver>();
        numberOfObservers = 0;
    }
    void addObserver(IObserver observer)
    {
        observers.Add(observer);
        numberOfObservers++;
    }

    void removeObserver(IObserver observer)
    {
        observers.Remove(observer);
        numberOfObservers--;
    }

    public void notify(int checkpointNo)
    {
        for (int i = 0; i < numberOfObservers; i++)
        {
            observers[i].OnNotify(checkpointNo);
        }
    }

    ~GameState()
    {
        for (int i=0; i< observers.Count;++i)
        {
            removeObserver(observers[i]);
        }
        observers.Clear();
    }

}
