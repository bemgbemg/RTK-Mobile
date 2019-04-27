using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class MapData : MonoBehaviour {
    #region
    public TextAsset MapInfo;
    private JsonData jsonData;
    public TextAsset Mapping;
    private JsonData MappingData;
    public TextAsset InfoData;
    public JsonData Info;
    #endregion

    public GameObject Map;

    #region
    public string Red;
    public string Green;
    public string Blue;
    public string Alpha;
    public int ThisObject;
    #endregion

    #region
    public int money;
    public int food;
    public int man;
    public int royalty;
    public int sodiler;
    public int develop;
    public string City;
    public string Major;
    public int CountryID;
    public bool Done;
    public string[] Mans;//武将
    public string[] Nears;//邻省
    #endregion

    public string countryname;//颜色判定国家
    public string displaycountryname;

    
    // Use this for initialization

    void Start () {
        Done = false;
        ThisObject = int.Parse(this.gameObject.name);
        jsonData = JsonMapper.ToObject(MapInfo.text);
        Info = JsonMapper.ToObject(InfoData.text);
        MappingData = JsonMapper.ToObject(Mapping.text);

        LoadColor();
        LoadData();
    }

    void LoadColor()
    {
        Red = jsonData[ThisObject][5].ToString();
        Green = jsonData[ThisObject][6].ToString();
        Blue = jsonData[ThisObject][7].ToString();
        Alpha = jsonData[ThisObject][8].ToString();
        this.gameObject.GetComponent<Image>().color = new Color32(byte.Parse(Red), byte.Parse(Green), byte.Parse(Blue), byte.Parse(Alpha));
        countryname = (Red.ToString() + "," + Green.ToString() + "," + Blue.ToString() + "," + Alpha.ToString());
    }
	
    void LoadData()
    {
        money = int.Parse(MappingData[ThisObject][4].ToString());
        food = int.Parse(MappingData[ThisObject][3].ToString());
        man = int.Parse(MappingData[ThisObject][1].ToString());
        royalty = int.Parse(MappingData[ThisObject][5].ToString());
        sodiler = int.Parse(MappingData[ThisObject][6].ToString());
        develop = int.Parse(MappingData[ThisObject][2].ToString());
        City = MappingData[ThisObject][0].ToString();
        Major = jsonData[ThisObject][1].ToString();
        for (int i = 0; i < Info.Count; i++)
        {
            if (Info[i][0].ToString() == countryname)
            {
                CountryID = i;
            }
        }
        displaycountryname = Info[CountryID][1].ToString();
        Mans = jsonData[ThisObject][9].ToString().Split(',');
        Nears = MappingData[ThisObject][8].ToString().Split(',');
    }
    void Update()
    {
        
    }
}
