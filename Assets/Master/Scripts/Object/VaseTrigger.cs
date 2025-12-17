using UnityEngine;

public class VaseTrigger : BaseTrigger
{
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Vase")
        {
            //Debug.Log("Vase OnTrigger");
            StepPlaceObjects.SetVasePlaced(true);
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Vase")
        {
            //Debug.Log("Vase OnExit");
            StepPlaceObjects.SetVasePlaced(false);
        }
    }
}
