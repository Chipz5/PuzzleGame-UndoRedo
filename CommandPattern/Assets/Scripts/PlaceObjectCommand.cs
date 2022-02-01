using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//command to place and delete 
public class PlaceObjectCommand : ICommand
{
    Vector3 position;
    Color color;
    Transform platform;
    public PlaceObjectCommand(Vector3 position, Color color, Transform platform)
    {
        this.position = position;
        this.color = color;
        this.platform = platform;
    }
    public void Execute()
    {
        ObjectPlacer.PlaceObject(position, color, platform);
    }

    public void Undo()
    {
        ObjectPlacer.RemoveObject(position, color);
    }
}
