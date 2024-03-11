using UnityEngine;

public static class TransformExtensions
{
    public static void RotateTowardsByAxis(this Transform transform, Transform target, Vector3 axis, float deltaSpeed)
    {
        var dir = target.position - transform.position;
        var rotSpeed = deltaSpeed * Time.deltaTime;
        Quaternion lookTowards = Quaternion.LookRotation(dir.normalized, axis);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookTowards, rotSpeed);
    }
}