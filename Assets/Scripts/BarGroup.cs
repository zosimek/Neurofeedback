using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGroup : MonoBehaviour
{
    public List<BarButton> tabButtons;
    public Sprite tabHoverPatient;
    public Sprite tabHoverTraining;
    public Sprite tabHoverSignal;
    public Sprite tabActivePatient;
    public Sprite tabActiveTraining;
    public Sprite tabActiveSignal;

    public GameObject icon;
    public Sprite iconHoverPatient;
    public Sprite iconHoverTraining;
    public Sprite iconHoverSignal;
    public Sprite iconActivePatient;
    public Sprite iconActiveTraining;
    public Sprite iconActiveSignal;
    [HideInInspector]
    public BarButton selectedTab;

    public List<GameObject> objectsToSwap;

    public void Subscribe(BarButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<BarButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(BarButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        {
            int index = button.transform.GetSiblingIndex();
            if (index == 0) 
            {
                icon = button.transform.GetChild(0).gameObject;
                icon.GetComponent<Image>().sprite = iconActivePatient;
                button.background.sprite = tabActivePatient;
            }
            if (index == 1)
            {
                icon = button.transform.GetChild(0).gameObject;
                icon.GetComponent<Image>().sprite = iconActiveTraining;
                button.background.sprite = tabActiveTraining;
            }
            if (index == 2)
            {
                icon = button.transform.GetChild(0).gameObject;
                icon.GetComponent<Image>().sprite = iconActiveSignal;
                button.background.sprite = tabActiveSignal;
            }


        }
    }

    public void OnTabExit(BarButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(BarButton button)
    {
        selectedTab = button;
        ResetTabs();
        int index = button.transform.GetSiblingIndex();

        if (index == 0) 
        {
            icon = button.transform.GetChild(0).gameObject;
            icon.GetComponent<Image>().sprite = iconActivePatient;
            button.background.sprite = tabActivePatient;
        }
        if (index == 1)
        {
            icon = button.transform.GetChild(0).gameObject;
            icon.GetComponent<Image>().sprite = iconActiveTraining;
            button.background.sprite = tabActiveTraining;
        }
        if (index == 2)
        {
            icon = button.transform.GetChild(0).gameObject;
            icon.GetComponent<Image>().sprite = iconActiveSignal;
            button.background.sprite = tabActiveSignal;
        }



        for (int i = 0; i<objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach(BarButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            int index = button.transform.GetSiblingIndex();

            if (index == 0)
            {
                icon = button.transform.GetChild(0).gameObject;
                icon.GetComponent<Image>().sprite = iconHoverPatient;
                button.background.sprite = tabHoverPatient;
            }
            if (index == 1)
            {
                icon = button.transform.GetChild(0).gameObject;
                icon.GetComponent<Image>().sprite = iconHoverTraining;
                button.background.sprite = tabHoverTraining;
            }
            if (index == 2)
            {
                icon = button.transform.GetChild(0).gameObject;
                icon.GetComponent<Image>().sprite = iconHoverSignal;
                button.background.sprite = tabHoverSignal;
            }
        }
    }
}
