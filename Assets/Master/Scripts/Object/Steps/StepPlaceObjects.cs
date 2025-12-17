using UnityEngine;

public class StepPlaceObjects : StepBase
{
    private void OnEnable()
    {
        TotalSteps = 3;
        StartStep();
        CurretSteps = 0;
    }

    protected override void ExecuteCurrentStep()
    {
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("Step Place Objects , step 0 : Place flask");
                StepTutorialManager.Instance.GotoState(0);
                break;
            case 1:
                Debug.Log("Step Place Objects , step 1: Place condenser");
                StepTutorialManager.Instance.GotoState(1);
                break;
            case 2:
                Debug.Log("Step Place Objects , step 2: Place vase");
                StepTutorialManager.Instance.GotoState(1);
                break;
        }
    }
}
