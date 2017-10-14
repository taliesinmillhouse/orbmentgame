using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkTreeConfirmationButton : BaseButton
{
    private AudioClip m_perkAppliedAudioClip;

    protected override void Awake()
    {
        base.Awake();

        m_perkAppliedAudioClip = Resources.Load("Audio/Beta/UI/Perk_Tree/Perk_Applied") as AudioClip;
    }

    public override void OnCursorEnter()
    {
        base.OnCursorEnter();

        PerkTreeConfirmationManager.m_perkTreeConfirmationManager.SelectedButtonIndex = m_iParentListIndex;
        PerkTreeConfirmationManager.m_perkTreeConfirmationManager.SelectedButton.IsMousedOver = false;
        PerkTreeConfirmationManager.m_perkTreeConfirmationManager.SelectedButton = PerkTreeConfirmationManager.m_perkTreeConfirmationManager.MainPanelButtons[m_iParentListIndex];
        PerkTreeConfirmationManager.m_perkTreeConfirmationManager.SelectedButton.IsMousedOver = true;
    }

    public override void OnClick(string a_strParameter)
    {
        base.OnClick(a_strParameter);

        switch (a_strParameter)
        {
            case "MainPanelYes":
                {
                    PerkTreeManager.m_perkTreeManager.PerkTreeAudioSource.PlayOneShot(m_perkAppliedAudioClip);
                    PerkTreeManager.m_perkTreeManager.m_selectedPerkButton.PurchasePerk();
                    PerkTreeConfirmationManager.m_perkTreeConfirmationManager.gameObject.SetActive(false);
                    break;
                }

            case "MainPanelNo":
                {
                    PerkTreeManager.m_perkTreeManager.PerkTreeAudioSource.PlayOneShot(m_menuClickAudioClip);
                    PerkTreeConfirmationManager.m_perkTreeConfirmationManager.gameObject.SetActive(false);
                    break;
                }

            default:
                {
                    Debug.Log("Case for " + a_strParameter + "could not be found.");
                    break;
                }
        }
    }
}
