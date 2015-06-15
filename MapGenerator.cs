using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
    public int maxRooms = 10;
    public Transform roomPrefab;
    public Room[,] map;

    private int roomNumber = 0;
    private int roomX;
    private int roomY;

    void Start()
    {
        StartCoroutine(GenerateMap());
    }

    IEnumerator GenerateMap()
    {
        map = new Room[maxRooms, maxRooms];
        int direction = 0;

        if (direction == 0) //centre
        {
            roomX = maxRooms / 2;
            roomY = maxRooms / 2;

            Room r = new Room(roomNumber, roomX, roomY, roomPrefab, transform);
            map[roomX, roomY] = r;
            roomNumber++;
            r.instance.GetComponent<SpriteRenderer>().color = Color.red;
        }

        while (roomNumber > 0 && roomNumber <= maxRooms)
        {
            if (roomNumber < maxRooms)
            {
                direction = Random.Range(1, 5);

                if (direction == 1 && GetRoom(roomX, roomY + 1) == null) //up
                {
                    print("Dir = up");
                    roomY += 1;
                }
                else if (direction == 2 && GetRoom(roomX + 1, roomY) == null) //right
                {
                    print("Dir = right");
                    roomX += 1;
                }
                else if (direction == 3 && GetRoom(roomX, roomY - 1) == null) //down
                {
                    print("Dir = down");
                    roomY -= 1;
                }
                else if (direction == 4 && GetRoom(roomX - 1, roomY) == null) //left
                {
                    print("Dir = left");
                    roomX -= 1;
                }
                 if (GetRoom(roomX, roomY) != null) continue;

                Room r = new Room(roomNumber, roomX, roomY, roomPrefab, transform);
                map[roomX, roomY] = r;
                roomNumber++;

            }

            if (roomNumber == maxRooms)
            {
                direction = Random.Range(1, 5);

                if (direction == 1 && GetRoom(roomX, roomY + 1) == null) //up
                {
                    print("Dir = up");
                    roomY += 1;
                }
                else if (direction == 2 && GetRoom(roomX + 1, roomY) == null) //right
                {
                    print("Dir = right");
                    roomX += 1;
                }
                else if (direction == 3 && GetRoom(roomX, roomY - 1) == null) //down
                {
                    print("Dir = down");
                    roomY -= 1;
                }
                else if (direction == 4 && GetRoom(roomX - 1, roomY) == null) //left
                {
                    print("Dir = left");
                    roomX -= 1;
                }

                if (GetRoom(roomX, roomY) != null) continue;

                Room r = new Room(roomNumber, roomX, roomY, roomPrefab, transform);
                map[roomX, roomY] = r;
                roomNumber++;
                r.instance.GetComponent<SpriteRenderer>().color = Color.green;
               

            }




            yield return new WaitForSeconds(0.1f);
        }
    }

    Room GetRoom(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < maxRooms && y < maxRooms)
            return map[x, y];
        return new Room();
    }
    

}
