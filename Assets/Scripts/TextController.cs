using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextController : MonoBehaviour {

	public Text text;
	private GameState currentState = null;
	
	// Use this for initialization
	void Start () {
		
		GameState freedom = new GameState(){RoomPrompt=StringsStore.Freedom_Prompt};
		GameState lock_1 = new GameState(){RoomPrompt=StringsStore.Lock_1_Prompt};
		GameState cell_mirror = new GameState(){RoomPrompt=StringsStore.Cell_Mirror_Prompt};
		GameState sheets_1 = new GameState(){RoomPrompt=StringsStore.Sheets_1_Prompt};
		GameState mirror_0 = new GameState(){RoomPrompt=StringsStore.Mirror_0_Prompt};
		GameState lock_0 = new GameState(){RoomPrompt=StringsStore.Lock_0_Prompt};
		GameState sheets_0 = new GameState(){RoomPrompt=StringsStore.Sheets_0_Prompt};
		GameState cell_0 = new GameState(){RoomPrompt=StringsStore.PrisonCell_0_Prompt};
		
		cell_0.UserChoices.Add(new UserChoice (KeyCode.S, StringsStore.GoToSheets, sheets_0));
		cell_0.UserChoices.Add(new UserChoice (KeyCode.M, StringsStore.GoToMirror, mirror_0));
		cell_0.UserChoices.Add(new UserChoice (KeyCode.D, StringsStore.GoToDoor, lock_0));
		
		sheets_0.UserChoices.Add(new UserChoice (KeyCode.R, StringsStore.ReturnToCenterCell, cell_0));
		lock_0.UserChoices.Add(new UserChoice(KeyCode.R, StringsStore.ReturnToCenterCell, cell_0));
		mirror_0.UserChoices.Add(new UserChoice (KeyCode.T, StringsStore.SmashMirror, cell_mirror));
		mirror_0.UserChoices.Add(new UserChoice(KeyCode.R, StringsStore.ReturnToCenterCell, cell_0));
		sheets_1.UserChoices.Add(new UserChoice (KeyCode.R, StringsStore.ReturnToBrokenMirror, cell_mirror));
		cell_mirror.UserChoices.Add(new UserChoice (KeyCode.S, StringsStore.GoToSheets, sheets_1));
		cell_mirror.UserChoices.Add(new UserChoice(KeyCode.D, StringsStore.GoToDoor, lock_1));
		lock_1.UserChoices.Add(new UserChoice (KeyCode.O, StringsStore.OpenDoorWithShard, freedom));
		lock_1.UserChoices.Add(new UserChoice(KeyCode.R, StringsStore.ReturnToBrokenMirror, cell_mirror));
		freedom.UserChoices.Add(new UserChoice(KeyCode.P, StringsStore.PlayAgain, cell_0));
		
		MoveToState(cell_0);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var choice in currentState.UserChoices) {
			if (Input.GetKeyDown(choice.ActivationKey)){
				MoveToState(choice.ActivationState);
				break;
			}	
		}
	}
	
	void MoveToState(GameState newState)
	{
		currentState = newState;
		text.text = newState.RoomPrompt + "\r\n";
		foreach (UserChoice item in currentState.UserChoices) {
			text.text += "\r\n" + item.ActivationKey.ToString() + ": " + item.ChoicePrompt;
		}
	}
}
