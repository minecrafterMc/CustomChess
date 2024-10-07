using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class shape : ScriptableObject
{
    [SerializeField] private modeData _parentMode;
    public modeData parentMode {get => _parentMode;}
    [SerializeField] public string _name;
    [SerializeField] public bool isImportant;
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
    [Header("movement")]
    [SerializeField] public int[] moveDirections = {0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField] public int[] moveDistances = {0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField] public bool UsesFirstMoveBoost;
    [SerializeField] public int[] moveFirstDistances = {0,0,0,0,0,0,0,0,0,0,0,0};
    

#if UNITY_EDITOR
    public void Initialise (modeData parentMode){
        _parentMode = parentMode;
    }
#endif
#if UNITY_EDITOR
[ContextMenu("Update Editor Name")]
    private void Rename(){
        this.name = _name;
        EditorUtility.SetDirty(this);
    }
#endif
#if UNITY_EDITOR
[ContextMenu("Delete this shape")]
    private void DeleteThis(){
        _parentMode.shapes.Remove(this);
        Undo.DestroyObjectImmediate(this);
        AssetDatabase.SaveAssets();
    }
#endif

}
