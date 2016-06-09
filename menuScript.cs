using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exittext;

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = true;
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;

        startText = startText.GetComponent<Button>();
        exittext = exittext.GetComponent<Button>();
	}
	
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exittext.enabled = false;
    }

    public void noPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exittext.enabled = true;
    }
    
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }
    
    public void ExitVR()
    {
        Application.Quit();
    }
}
