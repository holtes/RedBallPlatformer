using _Project.Develop.Runtime.Presentation.CameraFollowFeature.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Presentation.CameraFollowFeature.Systems
{
    public sealed class CameraFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CameraFollow> _cameraFilter = null;
        private Vector3 _velocity;

        public void Run()
        {
            foreach (var i in _cameraFilter)
            {
                ref var followData = ref _cameraFilter.Get1(i);

                var targetPos = followData.TargetTransform.position;
                var camera = followData.Camera;
                var bounds = followData.Bounds;

                Vector3 desired = new Vector3(targetPos.x, targetPos.y, camera.transform.position.z);

                float camHalfHeight = camera.orthographicSize;
                float camHalfWidth = camHalfHeight * camera.aspect;

                float minX = bounds.bounds.min.x + camHalfWidth;
                float maxX = bounds.bounds.max.x - camHalfWidth;
                float minY = bounds.bounds.min.y + camHalfHeight;
                float maxY = bounds.bounds.max.y - camHalfHeight;

                float clampedX = Mathf.Clamp(desired.x, minX, maxX);
                float clampedY = Mathf.Clamp(desired.y, minY, maxY);

                Vector3 clampedPos = new Vector3(clampedX, clampedY, desired.z);

                camera.transform.position = Vector3.SmoothDamp(camera.transform.position, clampedPos, ref _velocity, 0.15f);
            }
        }
    }
}