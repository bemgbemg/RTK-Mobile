using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectMan : MonoBehaviour {

    public GameObject Button;
    private GameObject ButtonClone;

    public GameObject Main;
    public GameObject ProfilesList;
    public GameObject Map;
    public GameObject Grid;
    public int Count;

	// Use this for initialization
	void Start () {
        
	}
	public void LoadInfo()
    {
        int c = Main.GetComponent<GameFunction>().Ontheplayer;
        Count = Map.transform.Find(c.ToString()).GetComponent<MapData>().Mans.Length;
        if(Count < 6)
        {
            Grid.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            ProfilesList.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Clamped;
        }
        else
        {
            Grid.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            ProfilesList.GetComponent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;
        }
        for (int i = 0; i < Count; i++)
        {
            ButtonClone = Instantiate(Button);
            ButtonClone.transform.SetParent(Grid.transform);
            ButtonClone.GetComponent<Palikka>().ID = int.Parse(Map.transform.Find(c.ToString()).GetComponent<MapData>().Mans[i]);
            ButtonClone.GetComponent<Button>().onClick.AddListener(Main.GetComponent<GameFunction>().NumberInput);
            ButtonClone.name = ButtonClone.GetComponent<Palikka>().ID.ToString();
        }
    }
}
