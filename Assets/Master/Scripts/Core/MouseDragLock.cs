using UnityEngine;
public enum DragCategory
{
    None,
    ChemicalTools,
   
}
public class MouseDragLock : MonoBehaviour
{
    public static bool IsBlocked { get; private set; } = false;
    public static bool IsLockedAfterStepsCompleted { get; private set; } = false;
    public static void Block() => IsBlocked = true;
    public static void Unblock() => IsBlocked = false;
    public static void LockAfterStepsCompleted() => IsLockedAfterStepsCompleted = true;
    public static void UnLockAfterStepsCompleted() => IsLockedAfterStepsCompleted = false;
}
