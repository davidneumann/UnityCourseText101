using UnityEngine;
using System.Collections.Generic;

public class GameState{
	private List<UserChoice> _userChoices = new List<UserChoice>();
	public List<UserChoice> UserChoices {get{return _userChoices;}}
	public string RoomPrompt {get;set;}
}
