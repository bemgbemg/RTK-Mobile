using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Country : MonoBehaviour {

    private TextAsset InfoData;
    private JsonData Info;

    public int Set;
    public int ID;
    public string Name;
    public string Color;
    public string Control;
    public int Trusty;//信用度

    public string[] controls;
    public int controlscount;
    // Use this for initialization
    void Start () {
        Trusty = 50;
        InfoData = Resources.Load<TextAsset>("CountOfCountries189");
        Info = JsonMapper.ToObject(InfoData.text);
        ID = Set;
        Name = Info[Set][1].ToString();
        Color = Info[Set][0].ToString();
        Control = Info[Set][2].ToString();
        controls = Control.Split(',');
        controlscount = controls.Length;

        //foreach (var controls in controls)
        //{
            //Debug.Log($"{controls}");
        //}
    }
}
