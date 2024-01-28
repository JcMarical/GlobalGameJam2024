using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{
    // Start is called before the first frame update
    [Header("地图滚动")]
    public Slider mapSlider;
    [Header("高兴值滚动")]
    public Slider happinessSlider;
    public Image happinessBar;
    public Sprite[] BarSprites;
    public Sprite[] HandleSprites;
    public Transform[] handleAreaPoint;
    [SerializeField]
    [Range(0,1f)]
    private float mapRatio;
    [SerializeField]
    [Range(0,1f)]
    private float happinessRatio;

    [Header("毛线球")] public GameObject woolBallUI;
       
    
    [Header("Player")]
    public Transform player;
    void Start()
    {
        mapRatio = mapSlider.value;
        happinessRatio = happinessSlider.value;
        player = transform.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

        }
    }
}
