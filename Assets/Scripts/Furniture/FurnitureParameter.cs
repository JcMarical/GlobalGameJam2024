
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

        public float judgeHeight;
        public Animator animator;
        public Rigidbody2D rigid;
        public bool isInteracting;
        public float destroyDistance = -50f;
        
        [Header("玩家")]
        public Transform target;
        public LayerMask targetLayer;
        
        
}
