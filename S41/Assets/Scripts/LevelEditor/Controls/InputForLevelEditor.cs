using UnityEngine;
using System.Collections;


public class InputForLevelEditor : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 placingPos;

    public GameObject mouse;

    private bool moved;

    // Use this for initialization
    void Start()
    {

        mousePos = new Vector3(0.0f, 1.0f, 0.0f);
        placingPos = new Vector3(0.0f, 0.0f, 0.0f);
        moved = false;

    }

    // Update is called once per frame
    void Update()
    {

        InputCheck();

    }

    public void InputCheck()
    {
        if (!moved)
        {
            if (Input.GetAxis("MovingX") > 0)
            {
                mousePos = new Vector3(mousePos.x + 1.0f, 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x + 1.0f, 0.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingX") < 0)
            {
                mousePos = new Vector3(mousePos.x - 1.0f, 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x - 1.0f, 0.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingY") > 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y + 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x, placingPos.y + 1.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingY") < 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y - 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x, placingPos.y - 1.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingZ") > 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y, mousePos.z + 1.0f);
                placingPos = new Vector3(placingPos.x, placingPos.y, placingPos.z + 1.0f);
                moved = true;
            }
            else if (Input.GetAxis("MovingZ") < 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y, mousePos.z - 1.0f);
                placingPos = new Vector3(mousePos.x, mousePos.y, mousePos.z - 1.0f);
                moved = true;
            }
            mouse.transform.position = mousePos;
        }
        if (Input.GetAxis("MovingX") == 0 && Input.GetAxis("MovingY") == 0 && Input.GetAxis("MovingZ") == 0)
        {
            moved = false;
        }
    }
}
