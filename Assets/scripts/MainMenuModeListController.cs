using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuModeListController
{
     // UXML template for list entries
    VisualTreeAsset m_ListEntryTemplate;
    
    // UI element references
    ListView m_ModeList;
    Label m_ModeName;
    Label m_ModeDescription;
    Label m_modeShapeList;
    
    List<modeData> m_AllModes;
    
    public void InitializeModeList(VisualElement root, VisualTreeAsset listElementTemplate)
    {
        EnumerateAllModes();
    

        m_ListEntryTemplate = listElementTemplate;
    

        m_ModeList = root.Q<ListView>("savedModesList");
    

        m_ModeName = root.Q<Label>("modeName");
        m_ModeDescription = root.Q<Label>("modeDesc");
        m_modeShapeList = root.Q<Label>("modeShapesList");
    
        FillModeList();
    

        m_ModeList.selectionChanged += OnModeSelected;
    }
    
    void EnumerateAllModes()
    {
        m_AllModes = new List<modeData>();
        m_AllModes.AddRange(Resources.LoadAll<modeData>("Modes"));
    }
    
    void FillModeList()
    {
        // Set up a make item function for a list entry
        m_ModeList.makeItem = () =>
        {
            // Instantiate the UXML template for the entry
            var newListEntry = m_ListEntryTemplate.Instantiate();
    
            // Instantiate a controller for the data
            var newListEntryLogic = new MainMenuModeListEntry();
    
            // Assign the controller script to the visual element
            newListEntry.userData = newListEntryLogic;
    
            // Initialize the controller script
            newListEntryLogic.SetVisualElement(newListEntry);
    
            // Return the root of the instantiated visual tree
            return newListEntry;
        };
    
        // Set up bind function for a specific list entry
        m_ModeList.bindItem = (item, index) =>
        {
            (item.userData as MainMenuModeListEntry)?.SetModeData(m_AllModes[index]);
        };
    
        // Set a fixed item height matching the height of the item provided in makeItem. 
        // For dynamic height, see the virtualizationMethod property.
        m_ModeList.fixedItemHeight = 45;
    
        // Set the actual item's source list/array
        m_ModeList.itemsSource = m_AllModes;
    }
    
    void OnModeSelected(IEnumerable<object> selectedItems)
    {
        // Get the currently selected item directly from the ListView
        var selectedMode = m_ModeList.selectedItem as modeData;
    
        // Handle none-selection (Escape to deselect everything)
        if (selectedMode == null)
        {
            // Clear
            m_ModeName.text = "";
            m_ModeDescription.text = "";
            m_modeShapeList.text = "";

    
            return;
        }
    
        // Fill in character details
        m_ModeName.text = selectedMode.ModeName;
        m_ModeDescription.text = selectedMode.ModeDesc;
        m_modeShapeList.text = "Shapes:";
        Debug.Log(selectedMode);
        for (int i = 0;i<selectedMode.shapes.Count;i++){
            m_modeShapeList.text +=  ", " + selectedMode.shapes[i].name;
        }
    }
}
