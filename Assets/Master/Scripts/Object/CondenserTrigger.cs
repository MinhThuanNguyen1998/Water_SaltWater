using UnityEngine;

public class CondenserTrigger : BaseTrigger
{
    protected override void OnEnter(Collider other)
    {
        if (Step.CurretSteps <= 1) return;
        if (other.gameObject.tag == "Vase")
        {
            Debug.Log("Vase OnTrigger");
            Step.GoToNextStep();
        }
    }
    protected override void OnExit(Collider other)
    {
        if (Step.CurretSteps <= 1) return;
        if (other.gameObject.tag == "Vase")
        {
            Debug.Log("Vase OnExit");
            Step.GoToPrevStep();
        }
    }
}
