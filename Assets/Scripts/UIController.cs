using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{
    // Start is called before the first frame update
    [Header("地图滚动")]
    public Slider mapSlider;

    public float mapAllTime = 60;
    private float mapTimer;
    
    [Header("高兴值滚动")] public float happyMaxValue = 120;
    public Slider happinessSlider;
    public Image happinessBar;
    public Image happinessHandle;
    public Sprite[] BarSprites;
    public Sprite[] HandleSprites;
    
    [SerializeField]
    [Range(0,1f)]
    private float mapRatio;
    [SerializeField]
    [Range(0,1f)]
    private float happinessRatio;

    [Header("毛线球")] public GameObject woolBallUI;
       
    
    [Header("Player")]
    public GameObject player;

    public Player playerScript;
    
    void Start()
    {
        mapRatio = mapSlider.value;
        happinessRatio = happinessSlider.value;
        player = GameObject.Find("player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MapSliderChange(mapAllTime);
        HappyChange();
    }


    public void MapSliderChange(float allTime)
    {
        mapTimer += Time.deltaTime;
        mapSlider.value = mapTimer / allTime;
        if (mapTimer > allTime)
        {
            Debug.Log("恭喜通关！！！");
            MessageCenter.SendCustomMessage(new Message(MessageType.Type_Controll, MessageType.Audio_frame, null));
        }
    }
    public void HappyChange()
    {
            float value = playerScript.HappyValue / happyMaxValue;
            happinessSlider.value = value;
            if (value < 0.3333f)
            {
                happinessBar.sprite = BarSprites[0];
                happinessHandle.sprite = HandleSprites[0];
            }
 
            if (value >= 0.3333f && value < 0.6666f )
            {
                happinessBar.sprite = BarSprites[1];
                happinessHandle.sprite = HandleSprites[1];
            }
            if (value >= 0.6666f && value < 1.0f)
            {
                happinessBar.sprite = BarSprites[2];
                happinessHandle.sprite = HandleSprites[2];
            }

    }
}
