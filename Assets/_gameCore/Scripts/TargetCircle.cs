using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetingSprite;
    [SerializeField] private LayerMask destroyableTargets;
    private Transform circleTrans;
    private Vector3 playerPos;
    private Color color_targetInRange = Color.red;
    public void Initialize(PlayerCtrl pc)
    {
        circleTrans = targetingSprite.transform;
        playerPos = pc.transform.position;
    }
    public void UpdateTargetCircle()
    {
        if (Physics.CheckCapsule(playerPos, circleTrans.position, 0.26f, destroyableTargets.value))
        {
            targetingSprite.color = color_targetInRange;
        }
        else
            targetingSprite.color = Color.white;

    }
}
