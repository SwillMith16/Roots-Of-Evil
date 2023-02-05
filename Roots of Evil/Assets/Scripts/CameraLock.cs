using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : CinemachineExtension
{

    [Tooltip("Lock the camera's Z position to this value")]
    public float ZPosition = -9.75f;
    public float YPosition = 1.6f;
    public float XRangeRight = 16f;
    public float XRangeLeft = 0f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.z = ZPosition;
            pos.y = YPosition;
            state.RawPosition = pos;

            if (state.RawPosition.x > XRangeRight)
            {
                pos.x = XRangeRight;
                state.RawPosition = pos;
            }
            if (state.RawPosition.x < XRangeLeft)
            {
                pos.x = XRangeLeft;
                state.RawPosition = pos;
            }

        }
    }
}
