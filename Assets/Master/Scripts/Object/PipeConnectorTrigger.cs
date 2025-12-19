using UnityEngine;

public class PipeConnectorTrigger : BaseTrigger
{
    [SerializeField] private CondensationEffect CondensationEffect;


    protected override void OnEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Condenser" )
        {
            //Debug.Log("Condenser OnTrigger");
            StepPlaceObjects.SetPipeConnectorPlaced(true);
            CondensationEffect.TurnOnCondensationEffect();
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
