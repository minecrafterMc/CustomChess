using UnityEngine.UIElements;
    
public class MainMenuModeListEntry
{
    Label m_NameLabel;
    

    public void SetVisualElement(VisualElement visualElement)
    {
        m_NameLabel = visualElement.Q<Label>("modeName");
    }

    public void SetModeData(modeData modeData)
    {
        m_NameLabel.text = modeData.name;
    }
}