using UnityEngine;
using System.Collections;

public class WorldModel : IWorldModel{

    public Vector3 size { get; set; }

    public WorldModel()
	{
        Debug.Log("WorldModel Constructor");
        size = new Vector3(10, 10, 60);
	}
}
