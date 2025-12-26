using DG.Tweening;
using UnityEngine;

public class VaseTrigger : BaseTrigger
{
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Vase")
        {
            if (IgnoreTrigger()) return;
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
            StepPlaceObjects.SetVasePlaced(false);
        }
    }
    private bool IgnoreTrigger()
    {
        return !StepPlaceObjects.PipeConnectorPlaced;
    }
}
