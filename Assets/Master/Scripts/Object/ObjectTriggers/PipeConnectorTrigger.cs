using UnityEngine;

public class PipeConnectorTrigger : BaseTrigger
{
    [SerializeField] private CondensationEffectController m_CondensationEffect;
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Condenser")
        {
            StepPlaceObjects.SetPipeConnectorPlaced(true);
            //Debug.Log("Condenser OnTrigger");
            m_CondensationEffect.TurnOnCondensationEffect();
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Condenser")
        {
            StepPlaceObjects.SetPipeConnectorPlaced(false);
            //Debug.Log("Condenser OnExit");
            m_CondensationEffect.TurnOffCondensationEffect();
        }
    }  
}
