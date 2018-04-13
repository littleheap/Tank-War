using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FollowTarget : MonoBehaviour {

    public Transform player1;
    public Transform player2;

    private Vector3 offset;
    private Camera camera;

    public static int round = 1;
    public static int green = 0;
    public static int red = 0;

	// Use this for initialization
	void Start () {
        offset = transform.position - (player1.position + player2.position) / 2;
        camera = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        if (player1 == null || player2 == null) return;

        /*
        if (player1 == null) {
            transform.position = player2.position + offset;
            return;
        }

        if (player2 == null){
            transform.position = player1.position + offset;
            return;
        }
        */

        transform.position = (player1.position + player2.position) / 2 + offset;
        float distance = Vector3.Distance(player1.position, player2.position);
        float size = distance * 3.0f;
        camera.fieldOfView = size;

        
    }

    private void OnGUI()
    {
        string text = "Round:" + round + "\n" + "Green Score:" + green + "\n" + "Red Score:" + red;
        GUIStyle style = new GUIStyle();
        style.normal.background = null;
        style.normal.textColor = new Color(256, 256, 256);
        style.fontSize = 40;
        GUI.Label(new Rect(0, 0, 200, 200), text, style);

        string script = "Use 'WASD' to control Green Tank direction \n and ‘Space’ to shot" + "\n" + "Use '↑↓←→' to control Red Tank direction \n and ‘L’ to shot";
        GUIStyle scriptstyle = new GUIStyle();
        scriptstyle.normal.background = null;
        scriptstyle.normal.textColor = new Color(256, 256, 256);
        scriptstyle.fontSize = 20;
        GUI.Label(new Rect(Screen.width - 400, 0, 300, 200), script, scriptstyle);

        if (GUI.Button(new Rect(Screen.width - 70, Screen.height * 0.2f, 60, 30), "Pause")) {
            Time.timeScale = 0;
        }
        if (GUI.Button(new Rect(Screen.width - 70, Screen.height * 0.2f+35, 60, 30), "Resume")){
            Time.timeScale = 1;
        }
        if (GUI.Button(new Rect(Screen.width - 70, Screen.height * 0.2f + 70, 60, 30), "Restart")){
            round = 1;
            green = 0;
            red = 0;
            SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(Screen.width - 70, Screen.height * 0.2f + 105, 60, 30), "Quit")){
            Application.Quit();
        }
    }
}
