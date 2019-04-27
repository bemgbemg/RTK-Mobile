using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public int BGMSound;
    public int InGameSound;

    public Slider BGMSlider;
    public Slider SoundSlider;

    // Use this for initialization
    void Start () {
        BGMSound = 1;
        InGameSound = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BGMsetting()
    {
        BGMSound = (int)BGMSlider.value;
    }
}
