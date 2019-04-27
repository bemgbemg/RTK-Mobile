using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;
using System.IO;

public class GameFunction : MonoBehaviour {
    //Jsondata
    #region
    private TextAsset lll;
    private TextAsset www;
    private TextAsset zzz;
    public JsonData MapData;
    public JsonData PicData;
    public JsonData InfoData;
    #endregion 

    //Display UI
    #region
    public Text ingameyear;//年显示
    public Text ingamemonth;//月显示
    public Text City;
    public Text showmoney;
    public Text showfood;
    public Text showman;
    public Text showdevelop;
    public Text showroyalty;
    public Text showsodiler;
    public Text showtrusty;
    public Image major;
    #endregion

    //Time
    #region
    public int year; //年份
    public int month; //月
    #endregion

    //Sounds
    public AudioSource ClickButton;

    public GameObject Gamer;
    public bool starting;
    public GameObject PanelOfChooseKing;
    public GameObject ProFileList;
    public GameObject NumberInputter;
    public GameObject Map;
    public GameObject DisplayText;
    public Text ChooseThisKing;
    public Text UI;
    public int playing;

	public GameObject CountryGrid;
	public GameObject Country;
    private GameObject CountryClone;
    public GameObject MapPanel;

    public int ControlCountry;

    public int MaxPlayer;
    public int Player;
    public int Controlling;
    public int MaxControlling;
    public int Ontheplayer;

    public int wu;
    public int zhi;
    public int mei;
    public int InputtedNumber;

    //Double Click
    public float Interval = 0.5f;
    private float firstClicked = 0;
    private float secondClicked = 0;

    //GameFunctions
    #region
    public bool KaiFa;
    public bool ShiShe;
    public bool ShuSong;

    #endregion

    // Use this for initialization
    void Start () {
        
        KaiFa = false;
        ShiShe = false;
        ShuSong = false;

        Controlling = 0;
        starting = true;

        //JsonLoad
        #region
        lll = Resources.Load<TextAsset>("Countries189");
        www = Resources.Load<TextAsset>("MapData");
        zzz = Resources.Load<TextAsset>("CountOfCountries189");
        MapData = JsonMapper.ToObject(www.text);
        PicData = JsonMapper.ToObject(lll.text);
        InfoData = JsonMapper.ToObject(zzz.text);
        #endregion

        MaxPlayer = InfoData.Count;
        CountryStart();
        SetTime();
    }

    void SetTime()
    {
        year = int.Parse(PicData[0][11].ToString());
        month = int.Parse(PicData[0][12].ToString());
    }
	
	void CountryStart()
    {
        int ID = 0;
        for (int i = 0; i < InfoData.Count; i++)
        {
            CountryClone = Instantiate(Country);
            CountryClone.transform.SetParent(CountryGrid.transform);
            CountryClone.GetComponent<Country>().Set = ID;
            CountryClone.name = ID.ToString();
            ID = ID + 1;
        }
    }

    // Update is called once per frame
    void Update () {
        ingameyear.text = year.ToString();
        ingamemonth.text = month.ToString();
        MaxControlling = CountryGrid.transform.Find(Player.ToString()).GetComponent<Country>().controlscount - 1;
        if (starting == true)
        {
            Gamer.SetActive(false);
        }
        if(Player == playing)
        {

        }
        else
        {
            Bot();
        }
    }

    void Bot()
    {
        Player = Player + 1;
    }

    public void PressMap()
    {
        var MapInfo = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        showmoney.text = (MapInfo.GetComponent<MapData>().money).ToString();
        showfood.text = (MapInfo.GetComponent<MapData>().food).ToString();
        showman.text = (MapInfo.GetComponent<MapData>().man).ToString();
        showdevelop.text = (MapInfo.GetComponent<MapData>().develop).ToString();
        showsodiler.text = (MapInfo.GetComponent<MapData>().sodiler).ToString();
        showroyalty.text = (MapInfo.GetComponent<MapData>().royalty).ToString();
        showtrusty.text = CountryGrid.transform.Find((MapInfo.GetComponent<MapData>().CountryID).ToString()).GetComponent<Country>().Trusty.ToString();
        City.text = MapInfo.GetComponent<MapData>().City;
        major.sprite = Resources.Load<Sprite>(MapInfo.GetComponent<MapData>().Major);
    }//点击地图

    public void StartGame()
    {
        if (starting == true)
        {
            Gamer.SetActive(false);
            var Country = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            if (bool.Parse(PicData[int.Parse(Country.name)][3].ToString()) == true)
            {
                PanelOfChooseKing.SetActive(true);
                ChooseThisKing.text = string.Format("你选择了{0}势力，确定吗？", PicData[int.Parse(Country.name)][4].ToString());
                playing = Country.GetComponent<MapData>().CountryID;
                starting = false;
                Ontheplayer = int.Parse(CountryGrid.transform.Find(playing.ToString()).GetComponent<Country>().controls[0]);
            }
            //难易度设置（未完成）
            //确认界面（未完成）
        }
    }

    public void StartedGame()
    {
        Player = 0;
    }

    public void BackToChoosing()
    {
        PanelOfChooseKing.SetActive(false);
        starting = true;
        playing = 0;
        Player = 0;
        MaxControlling = 0;
        Ontheplayer = 0;
    }

    public void Next()
    {
        if(Controlling == MaxControlling)
        {
            Controlling = 0;
        }
        else
        {
            Controlling = Controlling + 1;
        }
        Ontheplayer = int.Parse(CountryGrid.transform.Find(Player.ToString()).GetComponent<Country>().controls[Controlling]);
    }

    public void BackToMain()
    {
        var MapInfo = CountryGrid.transform.Find(playing.ToString());
        showmoney.text = (MapInfo.GetComponent<MapData>().money).ToString();
        showfood.text = (MapInfo.GetComponent<MapData>().food).ToString();
        showman.text = (MapInfo.GetComponent<MapData>().man).ToString();
        showdevelop.text = (MapInfo.GetComponent<MapData>().develop).ToString();
        showsodiler.text = (MapInfo.GetComponent<MapData>().sodiler).ToString();
        City.text = MapInfo.GetComponent<MapData>().City;
        major.sprite = Resources.Load<Sprite>(MapInfo.GetComponent<MapData>().Major);
    }

    public void Kaifa()
    {
        KaiFa = true;
        ProFileList.SetActive(true);
        ProFileList.transform.Find("Grid").GetComponent<SelectMan>().LoadInfo();
    }
    public void Shishe()
    {
        ShiShe = true;
        ProFileList.SetActive(true);
        ProFileList.transform.Find("Grid").GetComponent<SelectMan>().LoadInfo();
    }
    public void Zhengshou()
    {
        var country = CountryGrid.transform.Find(Player.ToString());
        country.GetComponent<Country>().Trusty = country.GetComponent<Country>().Trusty - 5;
        showtrusty.text = country.GetComponent<Country>().Trusty.ToString();
        UI.text = "在" + City.text + "征收了xxx";
    }
    public void Shushong()
    {
        int count;
        var country = CountryGrid.transform.Find(Player.ToString());
        count = country.GetComponent<Country>().controlscount;
        if(count == 1)
        {

        }
        else
        {
            ShuSong = true;

        }
    }

    public void NumberInput()
    {
        var Man = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        wu = int.Parse(Man.GetComponent<Palikka>().Wu.text);
        zhi = int.Parse(Man.GetComponent<Palikka>().Zhi.text);
        mei = int.Parse(Man.GetComponent<Palikka>().Mei.text);
        if(KaiFa == true)
        {
            NumberInputter.GetComponent<Number>().Max = 100;
            NumberInputter.GetComponent<Number>().Min = 1;
        }
        if(ShiShe == true)
        {
            NumberInputter.GetComponent<Number>().Max = 10000;
            NumberInputter.GetComponent<Number>().Min = 1;
        }
        NumberInputter.SetActive(true);
    }

    public void Functions()
    {
        var MapObject = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>();
        InputtedNumber = int.Parse(NumberInputter.GetComponent<Number>().Display.text);
        if(KaiFa == true)
        {
            int before = MapObject.develop;
            double math = zhi * InputtedNumber / 1000;
            MapObject.develop = MapObject.develop + (int)Math.Ceiling(math);
            MapObject.money = MapObject.money - InputtedNumber;
            if (MapObject.develop < 100)
            {
                showdevelop.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().develop.ToString();
                UI.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的开发度上升了" + math.ToString() + Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的开发度变成了" + Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().develop.ToString();
            }
            if(MapObject.develop > 100)
            {
                MapObject.develop = 100;
                showdevelop.text = (Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().develop).ToString();
                UI.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的开发度上升了" + (100 - before).ToString() +"\n" + Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的开发度变成了100";
            }
            showmoney.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().money.ToString();
            KaiFa = false;
        }
        if (ShiShe == true)
        {
            int before = MapObject.royalty;
            double math = mei * InputtedNumber * 0.35 / 10000;
            MapObject.royalty = MapObject.royalty + (int)Math.Ceiling(math);
            MapObject.food = MapObject.food - InputtedNumber;
            if (MapObject.royalty < 100)
            {
                showroyalty.text = (Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().royalty).ToString();
                UI.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的民忠上升了" + math.ToString() + Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的民忠变成了" + Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().royalty.ToString();
            }
            if (MapObject.royalty > 100)
            {
                MapObject.royalty = 100;
                showroyalty.text = (Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().royalty).ToString();
                UI.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的民忠上升了" + (100 - before).ToString() + "\n" + Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().City + "的民忠变成了100";
            }
            showfood.text = Map.transform.Find(Ontheplayer.ToString()).GetComponent<MapData>().food.ToString();
            ShiShe = false;
        }
    }

    public void ZoomCamera()
    {
        secondClicked = Time.realtimeSinceStartup;
        var Zoom = MapPanel.GetComponent<MapZoom>();
        if (secondClicked - firstClicked < Interval)
        {
            if(Zoom.Zooming == false)
            {
                Zoom.Zooming = true;
            }
            else
            {
                Zoom.Zooming = false;
            }
            
        }
        else
        {
            firstClicked = secondClicked;
        }
    }

    public void ClickSound()
    {

    }
}

