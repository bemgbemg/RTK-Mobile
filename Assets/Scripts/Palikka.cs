using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Palikka : MonoBehaviour {

    public JsonData jsonData;
    public TextAsset www;
    public int ID;
    public int CG;//事典
    public Text Name;
    public Text Wu;
    public Text Zhi;
    public Text Mei;
    public Text age;

    public GameObject Profile;
    Image Pic;
    public Sprite AllPic;
    public string CGID;

    // Use this for initialization

    void Start () {
        CGID = string.Format("{0}", ID);
        Pic = Profile.GetComponent<Image>();
        AllPic = Resources.Load<Sprite>(CGID);
        LoadInfo();
    }

    // Update is called once per frame
    void Update() {

    }

    public void LoadInfo()
    {
        jsonData = JsonMapper.ToObject(www.text);
        Name.text = jsonData[ID][0].ToString();
        CG = int.Parse(jsonData[ID][1].ToString());
        Wu.text = jsonData[ID][2].ToString();
        Zhi.text = jsonData[ID][3].ToString();
        Mei.text = jsonData[ID][4].ToString();
        age.text = jsonData[ID][5].ToString();
        Pic.sprite = AllPic;
    }
}
