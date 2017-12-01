using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialCommand : ICommand {
	
	public MeshRenderer renderer;
    public Material newMat;
    private Material originalMat;

    public ChangeMaterialCommand(MeshRenderer renderer, Material newMat){
		this.renderer = renderer;
        this.newMat = newMat;
	}

	public override void Execute(){
        originalMat = renderer.material;
        renderer.material = newMat;
	}

	public override void Undo(){

	}
}
