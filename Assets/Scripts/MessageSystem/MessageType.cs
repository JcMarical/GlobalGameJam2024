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
    public static int Player_Move = 400;

}
