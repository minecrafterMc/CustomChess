using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;

    private List<Button> _menuButtons = new List<Button>();

    private void Awake(){
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("openModeEditor") as Button;
        _button.RegisterCallback<ClickEvent>(OnPlayerGameClick);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count;i++){
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAnyButtonClick);
        }
    }

    private void OnDisable(){
        _button.UnregisterCallback<ClickEvent>(OnPlayerGameClick);
        for (int i = 0; i < _menuButtons.Count;i++){
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAnyButtonClick);
        }
    }

    private void OnPlayerGameClick(ClickEvent evt){
        Debug.Log(_button.style);
        //_button.Attributes.Text = "a";
    }
    public void OnAnyButtonClick(ClickEvent evt){
        Debug.Log("all test");
    }
}
