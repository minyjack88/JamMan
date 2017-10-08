using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapper : MonoBehaviour {

    public List<StringButton> buttons = new List<StringButton>();
    public List<GameObject> strings = new List<GameObject>();


    public KeyCode buttonOne = KeyCode.Q;
    public KeyCode buttonTwo = KeyCode.W;
    public KeyCode buttonThree = KeyCode.E;
    public KeyCode buttonFour = KeyCode.R;
    public KeyCode buttonFive = KeyCode.T;

    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {

        pressButtons();	

    }

    void pressButtons()
    {

        if (Input.GetKeyDown(buttonOne))
        {
            buttons[0].PressButton();
        }

        else if (Input.GetKeyUp(buttonOne))
        {
            buttons[0].DepressButton();
        }

        if (Input.GetKeyDown(buttonTwo))
        {
            buttons[1].PressButton();
        }

        else if (Input.GetKeyUp(buttonTwo))
        {
            buttons[1].DepressButton();
        }

        if (Input.GetKeyDown(buttonThree))
        {
            buttons[2].PressButton();
        }

        else if (Input.GetKeyUp(buttonThree))
        {
            buttons[2].DepressButton();
        }

        if (Input.GetKeyDown(buttonFour))
        {
            buttons[3].PressButton();
        }

        else if (Input.GetKeyUp(buttonFour))
        {
            buttons[3].DepressButton();
        }

        if (Input.GetKeyDown(buttonFive))
        {
            buttons[4].PressButton();
        }

        else if (Input.GetKeyUp(buttonFive))
        {
            buttons[4].DepressButton();
        }
    }
}
