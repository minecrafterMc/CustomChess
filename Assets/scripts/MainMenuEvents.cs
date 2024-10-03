using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _editorButton;
    private Button _savedModesButton;
    private Button _savedModesCloseButton;
    private Button _quitButton;
    private VisualElement myModesMenu;
    private List<Button> _menuButtons = new List<Button>();
    
    [SerializeField]
    VisualTreeAsset m_ListEntryTemplate;
    private void Awake(){
        _document = GetComponent<UIDocument>();

        _editorButton = _document.rootVisualElement.Q("openModeEditor") as Button;
        _savedModesButton = _document.rootVisualElement.Q("myModes") as Button;
        _savedModesCloseButton = _document.rootVisualElement.Q("modeMenuClose") as Button;
        _quitButton = _document.rootVisualElement.Q("quit") as Button;
        myModesMenu = _document.rootVisualElement.Q("savedModesContainer") as VisualElement;
        _editorButton.RegisterCallback<ClickEvent>(OnModeEditorButtonPressed);
        _savedModesButton.RegisterCallback<ClickEvent>(OnMyModesButtonPressed);
        _savedModesCloseButton.RegisterCallback<ClickEvent>(OnMyModesCloseButtonPressed);
        _quitButton.RegisterCallback<ClickEvent>(QuitGame);

        _menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count;i++){
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAnyButtonClick);
        }
        
        var modeListController = new MainMenuModeListController();
        modeListController.InitializeModeList(_document.rootVisualElement, m_ListEntryTemplate);
    }

    private void OnDisable(){
        _editorButton.UnregisterCallback<ClickEvent>(OnModeEditorButtonPressed);
        for (int i = 0; i < _menuButtons.Count;i++){
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAnyButtonClick);
        }
    }

    private void OnModeEditorButtonPressed(ClickEvent evt){
        Debug.Log(_editorButton.style);
        //_editorButton.Attributes.Text = "a";
    }
    private void OnMyModesButtonPressed(ClickEvent evt){
        myModesMenu.style.display = DisplayStyle.Flex;
    }
    private void OnMyModesCloseButtonPressed(ClickEvent evt){
        myModesMenu.style.display = DisplayStyle.None;
    }
    private void OnAnyButtonClick(ClickEvent evt){
        Debug.Log(myModesMenu.style.display);
    }
    void QuitGame(ClickEvent evt) {
        Application.Quit();
    }
}
