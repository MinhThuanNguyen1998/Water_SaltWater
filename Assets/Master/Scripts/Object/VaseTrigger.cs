using DG.Tweening;
using UnityEngine;

public class VaseTrigger : BaseTrigger
{
    [SerializeField] private Transform m_AnchorVase;
    protected override void OnEnter(Collider other)
    {
        if (other.gameObject.tag == "Vase")
        {
            MouseDragLock.LockAfterStepsCompleted();
            //Debug.Log("Vase OnTrigger");
            other.transform.DOMove(m_AnchorVase.position,1f)
                .OnComplete(() =>
                {
                    StepPlaceObjects.SetVasePlaced(true);
                    MouseDragLock.UnLockAfterStepsCompleted();
                });
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
