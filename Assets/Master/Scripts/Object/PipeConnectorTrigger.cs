using UnityEngine;

public class PipeConnectorTrigger : BaseTrigger
{
    protected override void OnEnter(Collider other)
    {
        if (Step.CurretSteps == 0) return;
        if (other.gameObject.tag == "Condenser" )
        {
            Debug.Log("Condenser OnTrigger");
            Step.GoToNextStep();
        }
    }
    protected override void OnExit(Collider other)
    {
        if (Step.CurretSteps == 0) return;
        if (other.gameObject.tag == "Condenser")
        {
            Debug.Log("Condenser OnExit");
            Step.GoToPrevStep();
        }
    }
}
