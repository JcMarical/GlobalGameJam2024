using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageType
{
    //消息类型
    public static byte Type_Controll = 1;
    public static byte Type_UI = 2;
    public static byte Type_Audio = 3;
    public static byte Type_Player = 4;
    public static byte Type_Scroll = 5;
    //控制消息
    public static int Controll_Move = 100;
    public static int Controll_Jump = 101;
    //UI消息
    public static int UI_ShowPanel = 200;
    public static int UI_ClosePanel = 201;
    public static int UI_newText = 202;
    //音频消息
    public static int Audio_play = 300;
    //玩家消息
    public static int Player_OnGround = 400;
    //卷轴消息
    public static int Scroll_NewGround = 500;

}
