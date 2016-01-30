using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    //public Sprite[] mapSprites = new Sprite[9];
    public GameObject[] prefabs = new GameObject[9];
    private GameObject[] mapObjects = new GameObject[9];

    private int currentLevel = 4;

    // Use this for initialization
    void Start () {
        mapObjects[currentLevel] = Instantiate(prefabs[currentLevel]);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += 75.0f;
        pos.y += 75.0f;

        pos.x /= 50.0f;
        pos.y /= 50.0f;

        int x = (int)pos.x;
        int y = (int)pos.y;

        y -= 2;
        y = Mathf.Abs(y);

        int newLevel = y * 3 + x;

        if (newLevel != currentLevel)
        {
            loadLevel(newLevel);
            currentLevel = newLevel;
        }

        int needX = 0;
        if (transform.position.x > 10.0f)
            needX = 1;
        else if (transform.position.x < -10.0f)
            needX = -1;

        int needY = 0;
        if (transform.position.y > 10.0f)
            needY = -1;
        else if (transform.position.y < -10.0f)
            needY = 1;

        if (needX < 0)
        {
            loadLevel(0);
            loadLevel(3);
            if (needY >= 0)
                loadLevel(6);

            Destroy(mapObjects[2]);
            Destroy(mapObjects[5]);
            Destroy(mapObjects[8]);
        }
        else if (needX > 0)
        {
            loadLevel(2);
            loadLevel(5);
            if (needY >= 0)
                loadLevel(8);

            Destroy(mapObjects[0]);
            Destroy(mapObjects[3]);
            Destroy(mapObjects[6]);
        }
        else
        {
            Destroy(mapObjects[3]);
            Destroy(mapObjects[5]);
        }

        if (needY < 0)
        {
            if (needX < 0)
                loadLevel(0);
            loadLevel(1);
            if (needX >= 0)
                loadLevel(2);

            Destroy(mapObjects[6]);
            Destroy(mapObjects[7]);
            Destroy(mapObjects[8]);
        }
        else if (needY > 0)
        {
            if (needX < 0)
                loadLevel(6);
            loadLevel(7);
            if (needX >= 0)
                loadLevel(8);

            Destroy(mapObjects[0]);
            Destroy(mapObjects[1]);
            Destroy(mapObjects[2]);
        }
        else
        {
            Destroy(mapObjects[1]);
            Destroy(mapObjects[7]);
        }

        //Debug.Log("Need " + needX + " " + needY);
    }

    void loadLevel(int index)
    {
        if (mapObjects[index] == null)
            mapObjects[index] = Instantiate(prefabs[index]);
    }
}
