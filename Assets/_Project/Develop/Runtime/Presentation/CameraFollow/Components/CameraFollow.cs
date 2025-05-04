using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.CameraFollowFeature.Components
{
    public struct CameraFollow
    {
        public Camera Camera;
        public Transform TargetTransform;
        public BoxCollider2D Bounds;
    }
}