﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    //rango
    [Range(0f,0.20f)]

    //Creando metodos para velocidad
    public float parallaxSpeed = 0.7f;
    public RawImage background;
    public RawImage platform;
    public GameObject uiIdle;


    public enum GameState {Idle, Playing};
    public GameState gameState = GameState.Idle;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	//Empieza el juego

	if( gameState == GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))) {
		gameState = GameState.Playing;	
   		uiIdle.SetActive(false);
   		player.SendMessage("UpdateState", "PlayerRun");


	}
	// JUEGO EN MARCHA
	else if(gameState == GameState.Playing) {
			Parallax();
		}
	
    }


    void Parallax() {
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);
	}



}
