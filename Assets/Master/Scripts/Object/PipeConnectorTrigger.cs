using UnityEngine;

public class PipeConnectorTrigger : BaseTrigger
{
    protected override void OnEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Condenser" )
        {
            //Debug.Log("Condenser OnTrigger");
            StepPlaceObjects.SetPipeConnectorPlaced(true);
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Condenser")
        {
            //Debug.Log("Condenser OnExit");
            StepPlaceObjects.SetPipeConnectorPlaced(false);

        }
    }
}
