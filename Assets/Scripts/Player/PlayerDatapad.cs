using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerDatapad : MonoBehaviour
{
    #region PROPERTIES

    [Header("Datapad Properties")]
    private float PreviousScroll;
    private float PreviousNavigation;
    public bool UsingDatapad = false;
    public Page CurrentPage;

    [Space]

    [Header("Datapad UI Properties")]
    public TMP_Text DatapadSectionText;
    public TMP_Text DatapadContentText;

    #endregion

    private void Start()
    {
        UpdateUI();
    }

    public void OnPadUse(InputValue context)
    {
        UsingDatapad = context.Get<float>() > 0.5;
        Debug.Log(UsingDatapad);
    }

    public void OnPadScroll(InputValue context)
    {
        if (!UsingDatapad) return;

        float NewDirection = context.Get<float>();

        if (NewDirection != PreviousScroll)
        {
            if (NewDirection > 0) DatapadNavigateLeft();
            if (NewDirection < 0) DatapadNavigateRight();
        }

        PreviousScroll = NewDirection;
    }

    public void OnPadNavigate(InputValue context)
    {
        if (!UsingDatapad) return;

        float NewDirection = context.Get<float>();

        if (NewDirection != PreviousNavigation)
        {
            if (NewDirection > 0) DatapadNavigateUp();
            if (NewDirection < 0) DatapadNavigateDown();
        }

        PreviousNavigation = NewDirection;
    }

    #region HELPER FUNCS

    public void DatapadNavigateLeft()
    {
        TryNavigate(CurrentPage.PrevPage);
    }

    public void DatapadNavigateRight()
    {
        TryNavigate(CurrentPage.NextPage);
    }

    public void DatapadNavigateUp()
    {
        TryNavigate(CurrentPage.HomePage);
    }

    public void DatapadNavigateDown()
    {
        TryNavigate(CurrentPage.InfoPage);
    }

    public void TryNavigate(Page NewPage)
    {
        if (NewPage != null)
        {
            CurrentPage = NewPage;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        DatapadSectionText.text = CurrentPage.PageSection;
        DatapadContentText.text = CurrentPage.PageContent;
    }

    #endregion
}
