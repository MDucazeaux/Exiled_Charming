using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{
    int h = 6;
    int v = 5;

    public int z;
    public GameObject tileSelected = null;

    private GameObject cursor;
    private GameObject player;
    private float timerCursor = 0.3f;

    private bool mouseCursor = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<attackType>().gameObject;
        cursor = GameObject.FindGameObjectWithTag("Cursor").gameObject;

        Cursor.visible = false;

    }

    void Update()
    {
        setCursorPos();
        checkTile();
    }

    private void setCursorPos()
    {
        // add the changes to the actual cursor position
        timerCursor -= Time.deltaTime;

        if (timerCursor <= 0)
        {
            timerCursor = 0;
        }

        if (Input.GetAxis("Horizontal") > 0 && timerCursor <= 0)
        {
            mouseCursor = false;
            h += 1;
            timerCursor = 0.3f;
        }
        else if (Input.GetAxis("Horizontal") < 0 && timerCursor <= 0)
        {
            mouseCursor = false;
            h -= 1;
            timerCursor = 0.3f;
        }
        if (Input.GetAxis("Vertical") > 0 && timerCursor <= 0)
        {
            mouseCursor = false;
            v += 1;
            timerCursor = 0.3f;
        }
        else if (Input.GetAxis("Vertical") < 0 && timerCursor <= 0)
        {
            mouseCursor = false;
            v -= 1;
            timerCursor = 0.3f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseCursor = true;
        }

        if (mouseCursor)
        {
            cursor.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 0.1f, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 0.2f, z);
        }

        if (!mouseCursor)
        {
            cursor.transform.position = new Vector3(h, v, z);
        }
    }
    private void checkTile()
    {
        if (tileSelected != null)
        {
            if (tileSelected.GetComponent<highlight1>())
            {
                tileH1();
            }

            if (tileSelected.GetComponent<highlight2>())
            {
                tileH2();
            }
        }
        else if (tileSelected == null)
        {
        }
    }

    private void tileH1()
    {
        if (tileSelected.GetComponent<highlight1>().colliderGO != null)
        {
            player.GetComponent<attackType>().tile = tileSelected.GetComponent<highlight1>().colliderGO;

            if (Input.GetKeyUp(KeyCode.JoystickButton0) && choicesPlayer.Instance.choice == 2)
            {
                Debug.Log("attaque 1");
                player.GetComponent<attackType>().atkNb = 1;
            }
        }
        else if (tileSelected.GetComponent<highlight1>().colliderGO == null)
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton0) && choicesPlayer.Instance.choice == 2)
            {
                Debug.Log("empty tile");
                player.GetComponent<attackType>().emptyTile();
            }
        }
    }
    
    private void tileH2()
    {
        if (tileSelected.GetComponent<highlight2>().colliderGO != null)
        {
            player.GetComponent<attackType>().tile = tileSelected.GetComponent<highlight2>().colliderGO;

            if (Input.GetKeyUp(KeyCode.JoystickButton0) && choicesPlayer.Instance.choice == 3)
            {
                Debug.Log("attaque 2");
                player.GetComponent<attackType>().atkNb = 2;
            }
        }
        else if (tileSelected.GetComponent<highlight2>().colliderGO == null)
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton0) && choicesPlayer.Instance.choice == 3)
            {
                Debug.Log("empty tile");
                player.GetComponent<attackType>().emptyTile();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tile")
        {
            tileSelected = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        tileSelected = null;
    }
} 
