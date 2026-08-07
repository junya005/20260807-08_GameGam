using UnityEngine;

public interface IArrivalCheck
{
    bool CheckArrival(Vector2 checkPos, float checkRadius);
    bool CheckArrival(Vector2 checkPos, float checkRadius, out float distance);
}
