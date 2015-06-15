using UnityEngine;
using System.Collections;

public class Room
{
    public int id;
    public int x;
    public int y;
    public Transform prefab;
    public GameObject door;

    public float width;
    public float height;

    public Transform instance;

    public Room()
    {
        id = -1;
        x = 0;
        y = 0;
        prefab = null;
    }

    public Room(int id, int x, int y, Transform prefab, Transform parent)
    {
        this.id = id;
        this.x = x;
        this.y = y;
        this.prefab = prefab;
        this.width = prefab.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2;
        this.height = prefab.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * 2;
        instance = GameObject.Instantiate(prefab, new Vector3(x * width, y * height, 0), Quaternion.identity) as Transform;
        instance.SetParent(parent);

        
    }
}
