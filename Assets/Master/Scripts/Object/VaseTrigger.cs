using DG.Tweening;
using UnityEngine;

public class VaseTrigger : BaseTrigger
{
    [SerializeField] private GameObject m_AnchorVase;
    private void OnEnable()
    {
        m_AnchorVase.SetActive(false);
    }
    protected override void OnEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Vase")
        {
            if (IgnoreTrigger()) return;

            m_AnchorVase.SetActive(false);
            //Debug.Log("Vase OnTrigger");
            StepPlaceObjects.SetVasePlaced(true);
            
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Vase")
        {
            if (IgnoreTrigger()) return;
            //Debug.Log("Vase OnExit");
            m_AnchorVase.SetActive(true);
            StepPlaceObjects.SetVasePlaced(false);
        }
    }

    private bool IgnoreTrigger()
    {
        return StepPlaceObjects.CurrentStep < 2;
    }
}
