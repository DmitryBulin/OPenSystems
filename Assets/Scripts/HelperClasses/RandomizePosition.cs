using UnityEngine;

/// <summary>
/// Purpose of this component is just changing it's position within a certain box
/// </summary>

public class RandomizePosition : MonoBehaviour
{
    [Range(0f, 1.5f)] [SerializeField] private float _maxDistance;
    public Vector3 RootPosition;

    public void ResetPosition()
    {
        transform.position = RootPosition;
    }

    public void ChangePosition()
    {
        transform.position = RootPosition + new Vector3(Random.Range(-_maxDistance, _maxDistance),
            Random.Range(-_maxDistance, _maxDistance),
            Random.Range(-_maxDistance, _maxDistance));
    }

}
