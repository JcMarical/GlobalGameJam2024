using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageType
{
    //��Ϣ����
    public static byte Type_Controll = 1;
    public static byte Type_UI = 2;
    public static byte Type_Audio = 3;
    public static byte Type_Player = 4;
    public static byte Type_Scroll = 5;

    public static byte Type_WoolBall = 6;
    public static byte Type_Carton = 7; 
    //������Ϣ
    public static int Controll_Move = 100;
    public static int Controll_Jump = 101;
    //UI��Ϣ
    public static int UI_ShowPanel = 200;
    public static int UI_ClosePanel = 201;
    public static int UI_newText = 202;
    //��Ƶ��Ϣ
    public static int Audio_play = 300;
    //�����Ϣ
    public static int Player_OnGround = 400;

    public static int Player_Hurt = 401;
    //������Ϣ
    public static int Scroll_NewGround = 500;
    public static int Scroll_NewFurniture = 501;
    public static int Scroll_Arrow = 502;
    //WoolBall
    public static int WoolBall_Interact = 601;
    //Carton
    public static int Carton_Interact = 701;
    public static int Carton_Hurt = 702;

}
