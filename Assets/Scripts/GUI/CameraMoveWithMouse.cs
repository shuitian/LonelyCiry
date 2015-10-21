using UnityEngine;
using System.Collections;

public class CameraMoveWithMouse : MonoBehaviour {

    public Camera camera;
    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;
    public bool left, right, up, down;
    public float moveSpeed = 1;
	// Update is called once per frame
	void Update () {
        print(Input.mousePosition);
        print(Screen.height);
        print(Screen.width);
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        if (x <= 0)
        {
            left = true;
            right = false;
        }
        else if (x >= Screen.width)
        {
            right = true;
            left = false;
        }
        else
        {
            right = false;
            left = false;
        }
        if (y <= 0)
        {
            down = true;
            up = false;
        }
        else if (y >= Screen.height)
        {
            up = true;
            down = false;
        }
        else
        {
            down = false;
            up = false;
        }
        if (left || right || down || up)
        {
            Move(left, right, down, up);
        }
	}

    void Move(bool left, bool right, bool down, bool up)
    {
        Vector3 direct = new Vector3(0,0,0);
        if (left)
        {
            direct.x = -moveSpeed;
        }
        else if (right)
        {
            direct.x = moveSpeed;
        }
        if (down)
        {
            direct.z = -moveSpeed;
        }
        else if (up)
        {
            direct.z = moveSpeed;
        }
        camera.transform.position += direct*Time.deltaTime;
        if (camera.transform.position.x > maxX)
        {
            camera.transform.position += new Vector3(maxX - camera.transform.position.x, 0, 0);
        }
        if (camera.transform.position.x < minX)
        {
            camera.transform.position += new Vector3(minX - camera.transform.position.x, 0, 0); 
        }
        if (camera.transform.position.z > maxZ)
        {
            camera.transform.position += new Vector3(0, 0, maxZ - camera.transform.position.z);
        }
        if (camera.transform.position.z < minZ)
        {
            camera.transform.position += new Vector3(0, 0, minZ - camera.transform.position.z);
        }
    }
}
