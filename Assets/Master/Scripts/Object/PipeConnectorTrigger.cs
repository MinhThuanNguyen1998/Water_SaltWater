using UnityEngine;

public class PipeConnectorTrigger : BaseTrigger
{
    [SerializeField] private CondensationEffect m_CondensationEffect;
    [SerializeField] private GameObject m_AnchorCondenser;
    private bool m_HasPlayedCondensation;
    private void OnEnable() => ActiveAnchorCondenser(false);
    protected override void OnEnter(Collider other) => ActiveAnchorCondenser(false);
    protected override void OnStay(Collider other)
    {
        if (other.gameObject.tag == "Condenser")
        {
            if (IgnoreTrigger()) return;
            if (m_HasPlayedCondensation) return;
            //Debug.Log("Condenser OnTrigger");
            StepPlaceObjects.SetPipeConnectorPlaced(true);
            m_CondensationEffect.TurnOnCondensationEffect();
            StepPlaceObjects.SetVasePlaced(true);
            m_HasPlayedCondensation = true;
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Condenser")
        {
            if(StepPlaceObjects.CurrentStep >= 1) m_AnchorCondenser.SetActive(true); 
            if (IgnoreTrigger()) return;
            //Debug.Log("Condenser OnExit");
            m_HasPlayedCondensation = false;
            StepPlaceObjects.SetPipeConnectorPlaced(false);
            m_CondensationEffect.TurnOffCondensationEffect();
            StepPlaceObjects.SetVasePlaced(false);
        }
    }
    private bool IgnoreTrigger()
    {
        return StepPlaceObjects.CurrentStep <= 0 || !StepPlaceObjects.BurnerUsed;
    }
    private void ActiveAnchorCondenser(bool isActive) => m_AnchorCondenser.SetActive(isActive);
    
}
