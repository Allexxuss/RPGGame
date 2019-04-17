using UnityEngine;

public static class ExtensionMethods
{
    public static TElement FirstRandom<TElement>(this TElement[] array)
        => array[Random.Range(0, array.Length)];
        
    public static Quaternion SmoothDamp(this Quaternion rotation, Quaternion target, ref Quaternion velocity, float time)
    {
        var mult = Quaternion.Dot(rotation, target) > 0f ? 1f : -1f;
        var delta = 1f / Time.deltaTime;
        target.x *= mult;
        target.y *= mult;
        target.z *= mult;
        target.w *= mult;
        var result = new Vector4(
            Mathf.SmoothDamp(rotation.x, target.x, ref velocity.x, time),
            Mathf.SmoothDamp(rotation.y, target.y, ref velocity.y, time),
            Mathf.SmoothDamp(rotation.z, target.z, ref velocity.z, time),
            Mathf.SmoothDamp(rotation.w, target.w, ref velocity.w, time)).normalized;
        velocity.x = (result.x - rotation.x) * delta;
        velocity.y = (result.y - rotation.y) * delta;
        velocity.z = (result.z - rotation.z) * delta;
        velocity.w = (result.w - rotation.w) * delta;
        return new Quaternion(result.x, result.y, result.z, result.w);
    }
}