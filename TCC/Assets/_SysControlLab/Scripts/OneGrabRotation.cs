/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Oculus.Interaction;
using UnityEngine;

/// <summary>
/// A Transformer that moves the target in a 1-1 fashion with the GrabPoint.
/// Updates transform the target in such a way as to maintain the target's
/// local positional and rotational offsets from the GrabPoint.
/// </summary>
public class OneGrabRotation : MonoBehaviour, ITransformer
{
 

    [SerializeField] private bool xRotate=default;
    [SerializeField] private bool yRotate=default;
    [SerializeField] private bool zRotate=default;
    private IGrabbable _grabbable;
    private Pose _grabDeltaInLocalSpace;

    public void Initialize(IGrabbable grabbable)
    {
        _grabbable = grabbable;
    }

    public void BeginTransform()
    {
        Pose grabPoint = _grabbable.GrabPoints[0];
        var targetTransform = _grabbable.Transform;
        _grabDeltaInLocalSpace = new Pose(
            targetTransform.InverseTransformVector(grabPoint.position - targetTransform.position),
            Quaternion.Inverse(grabPoint.rotation) * targetTransform.rotation);
    }

    public void UpdateTransform()
    {
        Pose grabPoint = _grabbable.GrabPoints[0];
        var targetTransform = _grabbable.Transform;
        if(xRotate)
            targetTransform.rotation = Quaternion.Euler(grabPoint.rotation.x,0,0 ) * Quaternion.Euler(_grabDeltaInLocalSpace.rotation.x,0,0 );
        if(yRotate)
            targetTransform.rotation = Quaternion.Euler(0,grabPoint.rotation.y,0 ) * Quaternion.Euler(0,_grabDeltaInLocalSpace.rotation.y,0 );
        if(zRotate)
            targetTransform.rotation = Quaternion.Euler(0,0,grabPoint.rotation.z ) * Quaternion.Euler(0,0,_grabDeltaInLocalSpace.rotation.z );
        //targetTransform.position = grabPoint.position - targetTransform.TransformVector(_grabDeltaInLocalSpace.position);
    }

    public void EndTransform()
    {
    }
}
