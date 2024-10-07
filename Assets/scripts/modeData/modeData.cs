using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

//https://www.youtube.com/watch?v=81kyAHy9gUE
[CreateAssetMenu]
public class board : ScriptableObject{
    public string name;
    public int width;
    public int height;
    public int[] shape;

}
// 4.10.2024 / 21.08
// had an existential crisis, but I'm good now
[CreateAssetMenu(fileName = "Mode Data", menuName = "data/mode")]
public class modeData : ScriptableObject
{
    [SerializeField] private List<shape> _shape = new List<shape>();
    [SerializeField] public string ModeName;
    [SerializeField] public string ModeDesc;
    [SerializeField] public Sprite PortraitImage;
    
    
    public List<shape> shapes {get => _shape; set => _shape = value;}
    #if UNITY_EDITOR
    [ContextMenu("make new shape")]
    private void MakeNewShape(){
        shape shape = ScriptableObject.CreateInstance<shape>();
        shape.name = "New Shape";
        shape.Initialise(this);
        _shape.Add(shape);

        AssetDatabase.AddObjectToAsset(shape, this);
        AssetDatabase.SaveAssets();

        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(shape);
    }
    #endif
    
}