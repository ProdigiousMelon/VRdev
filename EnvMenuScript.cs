using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvMenuScript : MonoBehaviour {

    public Canvas envMenu;
    public Dropdown WTdropdown;
    public Dropdown FTdropdown;
    public Button Next;
    public Button Back;
    public Material WoodMat;
    public Material MetalMat;
    public MeshRenderer rend;
    public GameObject cube;
    public GameObject fan;
    public bool pause = false;
    public float speed = 5f;


	// Use this for initialization
	void Start () {

        //gets the menu component and hides it
        envMenu = envMenu.GetComponent<Canvas>();
        envMenu.enabled = false;

        //grab components
        WTdropdown = WTdropdown.GetComponent<Dropdown>();
        FTdropdown = FTdropdown.GetComponent<Dropdown>();
        Next = Next.GetComponent<Button>();
        Back = Back.GetComponent<Button>();
        cube = cube.GetComponent<GameObject>();
        fan = fan.GetComponent<GameObject>();

        //allows the cube's texture to be editted
        rend.enabled = true;
        rend = cube.GetComponent<MeshRenderer>();

        WoodMat = (Material)Resources.Load("WoodMat.mat", typeof(Material));
        MetalMat = (Material)Resources.Load("MetalMat.mat", typeof(Material));

        //add listner for the WT dropdown menu
        WTdropdown.onValueChanged.AddListener(delegate { setWallTexture(WTdropdown); });
    }
    void Update()
    {
        EscapeMenu();
        rotateFan(fan);
    }
    void OnGUI()
    {
        if(Time.timeScale == 0)
        {
            envMenu.enabled = true;
        }
        else
        {
            envMenu.enabled = false;
        }
    }

    public void backPress()
    {
        Application.LoadLevel(0);
    }
    public void setWallTexture(Dropdown WTdropdown)
    {
        if(WTdropdown.value == 0)
        {
            cube.GetComponent<Renderer>().material = WoodMat; 
        }
        else if(WTdropdown.value == 1)
        {
            cube.GetComponent<Renderer>().material = MetalMat;
        }
    }
    public void rotateFan(GameObject Fan)
    {
        Fan.transform.Rotate(0, 0, speed);

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            speed++;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            speed--;
        }
    }
    //handles the escape menu
    public void EscapeMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pause)
            {
               // envMenu.enabled = true;
                Time.timeScale = 0;
                pause = true;
                speed = 0;
            }
            else
            {
              //  envMenu.enabled = false;
                Time.timeScale = 1;
                pause = false;
            }
        }


    }


}
