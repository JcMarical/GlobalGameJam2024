
using UnityEngine;

[System.Serializable]
public class FurnitureParameter 
{

        [Header("快乐属性")]
        public int happiness;
        public int upsetThreshold;
        public int happyThreshold;
        public int maxThreshold;
        [Header("家具本身属性")]
        public Transform target;
        public LayerMask targetLayer;
        public Transform attackPoint;
        public float attackArea;
        public Animator animator;
        public Rigidbody2D rigid;
}
