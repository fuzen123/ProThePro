using UnityEngine;

public class CharacterRotating : MonoBehaviour
{
    [SerializeField] private Transform CharacterModel = null;
    [SerializeField] private float angleRotation = 10f;
    public void UpdateRotation()
    {
        CharacterModel.Rotate(Vector3.up, angleRotation * Time.deltaTime, Space.Self);
    }
    public Vector3 LookingDirection()
    {
        return CharacterModel.forward;
    }
}
