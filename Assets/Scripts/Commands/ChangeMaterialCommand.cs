using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialCommand : ICommand {
	
	public MeshRenderer renderer;
    public Material newMat;
    public int tickToExecute;
    private Material originalMat;

    public ChangeMaterialCommand(MeshRenderer renderer, Material newMat, int tickToExecute){
		this.renderer = renderer;
        this.newMat = newMat;
        this.tickToExecute = tickToExecute;
	}

	public override void Execute(){
        originalMat = renderer.material;
        renderer.material = newMat;
	}

	public override void Undo(){

	}
}
