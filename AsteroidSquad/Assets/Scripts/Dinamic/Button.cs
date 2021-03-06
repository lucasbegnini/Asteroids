﻿using UnityEngine;
using System.Collections;

public class Button : DinamicImage {
	
	protected Animator animRef;
	protected bool canDown = true;
	//public AudioSource down;
	//public AudioSource select;
	void Start () {
		initPos = transform.position;
		animRef = GetComponent<Animator> ();
		audio.volume = PlayerPrefs.GetFloat("SFXVolume");
	}
	
	void Update () {
		if(canEnter){
			DoEnter();
		}
		
		if(canExit || canExitS){
			DoExit();
			canExit = false;
		}
		
	}

	void  OnMouseEnter(){
		Down ();
	}
	
	void OnMouseDown(){
		//Down ();
	}
	
	void OnMouseExit(){
		Up();
	}

	
	protected void Up(){
		animRef.SetBool ("pressed", false);
	}
	
	void Down(){
		if(canDown)
			animRef.SetBool ("pressed", true);
		try{
			audio.Play ();
		}catch(MissingComponentException e){

		}
	}
}
