using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class shape : ScriptableObject{
    public string name;
    public int moveDistanceLimit;
    public bool canMoveInfinitely;
    //array values:
    //0- cant move or attack
    //1- can move but not attack
    //2- can both move and attack
    //3- can move only if it attacks
    //array positions:
    //0- up
    //1- right
    //2- down
    //3- left
    //4- diagonal up right
    //5- diagonal down right
    //6- diagonal down left
    //7- diagonal up left
    //8- horse up right
    //9- horse down right
    //10- horse down left
    //11- horse up left
    public int[] moveDirections;
    public bool isImportant;

}
[CreateAssetMenu]
public class modeData : ScriptableObject
{
    public string ModeName;
    public Sprite PortraitImage;
    public shape[] shapes;
    //[SerializeField]
}