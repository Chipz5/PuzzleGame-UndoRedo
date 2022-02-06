using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;
    static int numberOfObjects;
    public Text txt;


    public void Awake()
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
        numberOfObjects = 0;
    }

    public static void AddCommand(ICommand command)
    {
        numberOfObjects++;
        while (commandHistory.Count > counter)
        {
           commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }
    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand command = commandBuffer.Dequeue();
            command.Execute();

            commandHistory.Add(command);
            counter++;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    counter--;
                    commandHistory[counter].Undo();
                    numberOfObjects--;
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter].Execute();
                    counter++;
                    numberOfObjects++;
                }
            }
        }

        if(numberOfObjects >= 15)
        {
            ResetScene();
            SceneManager.LoadScene("Game1");
        }

        txt.text = numberOfObjects.ToString();
    }

    public void ResetScene()
    {
        ObjectPlacer.reset();
        ResetCommand();
    }

    public void ResetCommand()
    {
        counter = 0;
        commandBuffer.Clear();
        commandHistory.Clear();
    }
}
