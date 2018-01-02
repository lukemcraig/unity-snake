using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProjectionSystem : EgoSystem<
EgoConstraint<Camera>
>{
	
    public override void Start(){    	
        constraint.ForEachGameObject((egoComponent, camera) =>
        	{        		
        		float aspect;
        		float fov = 60f;
        		float near = .3f;
        		float far = 1000f;
        		float orthographicSize = 50f;
        		aspect = (float) Screen.width / (float) Screen.height;
        		Matrix4x4 ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        		Matrix4x4 perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        		Camera.main.projectionMatrix = ortho;
        		
        		camera.projectionMatrix = MatrixLerp(perspective, ortho,  0.98f);
        	});
    }
    
    private static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }
    
}
