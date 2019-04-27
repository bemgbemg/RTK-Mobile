using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

public class Wujiang : MonoBehaviour {
    public Transform grid;//父对象
    public GameObject button;
    public GameObject buttonc;
    public int ID;


    //private Palikka palikka;
    private void Awake()
    {
        //palikka = GetComponent<Palikka>();//其它变量Palikka.cs
    }
    // Use this for initialization
    void Start () {
            ID = 0;
            for (ID = 0; ID < 594; ID++)
            {
                buttonc = Instantiate(button);
                buttonc.transform.SetParent(grid);
                buttonc.GetComponent<Palikka>().ID = ID;
            }
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
