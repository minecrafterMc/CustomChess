using UnityEngine.UIElements;
    
public class MainMenuModeListEntry
{
    Label m_NameLabel;
    
    // This function retrieves a reference to the 
    // character name label inside the UI element.
    public void SetVisualElement(VisualElement visualElement)
    {
        m_NameLabel = visualElement.Q<Label>("modeName");
    }
    
    // This function receives the character whose name this list 
    // element is supposed to display. Since the elements list 
    // in a `ListView` are pooled and reused, it's necessary to 
    // have a `Set` function to change which character's data to display.
    public void SetModeData(modeData modeData)
    {
        m_NameLabel.text = modeData.name;
    }
}