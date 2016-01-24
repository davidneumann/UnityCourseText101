using UnityEngine;
using System.Collections;

public class UserChoice{
	private GameState _activationState = null;
	private KeyCode _activationKey = KeyCode.R;
	private string _choicePrompt = string.Empty;
	public GameState ActivationState {get {return _activationState;} }
	public KeyCode ActivationKey {get {return _activationKey;}}
	public string ChoicePrompt {get {return _choicePrompt;}}
	
	public UserChoice(KeyCode activationKey, string choicePrompt, GameState activationState)	{
		this._activationState = activationState;
		this._activationKey = activationKey;
		this._choicePrompt = choicePrompt;
	}
}
