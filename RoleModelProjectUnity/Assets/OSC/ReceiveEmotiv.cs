using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ReceiveEmotiv : MonoBehaviour {

	//Currently this script is configured to
	public OSC osc;
	
	//No longer needed
	
	//public InputVal inputVal;

	//we need to find a good range of values to work with
	//in the final version, the manufacturers will help us with
	//our data stream
	public float minimumStateValue = 0f;
	public float maximumStateValue = 500f;
	

	//these are public just so that we can see them, but should not be set in the inspector
	[SerializeField] float attentionVal = 0f, stressVal = 0f, relaxVal = 0f, meditationVal = 0f;

	//debug mode is for testing when we don't have the brainbit connected
	public bool debugMode;

	public enum EmotionalState {attention = 0, stress = 1, relax = 2, meditation = 3, neutralState = 4, numEntries}

	public EmotionalState currentState;
	private EmotionalState previousState;

	public float[] stateValues;

	public delegate void ChangeState();
	public event ChangeState OnChangeState;

	public RevisedAudioPicker audioPicker;

	//time until we repeat the same dialogue
	public float sameStateRepeatTime = 30f;
	public float sameStateTimer = 0f;

	private bool delayedChangeState = false;

	private bool pauseScanning = false;
	
	

	// Use this for initialization
	void Start () {

		//osc addresses:
		
		osc.SetAddressHandler("/Attention", AttentionToStoredFloat);
		osc.SetAddressHandler("/Stress", StressToStoredFloat);
		osc.SetAddressHandler("/Relax", RelaxToStoredFloat);
		osc.SetAddressHandler("/Meditation", MeditationToStoredFloat);

		stateValues = new float[(int)EmotionalState.numEntries];

		currentState = (EmotionalState)4;
		previousState = (EmotionalState)4;

		delayedChangeState = false;

		pauseScanning = false;
	}

	// Update is called once per frame
	void Update () {
		if (!pauseScanning) {
			if (debugMode) {
				//inputVal.inputBCIValue = dummySlider;
				UpdateEmotionalState();
			}
			else {
				UpdateEmotionalState();
			}
		}
	}

	void AttentionToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		Mathf.Clamp(inputFloat, minimumStateValue, maximumStateValue);

		attentionVal = inputFloat;

	}
	
	void StressToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumStateValue, maximumStateValue);

		stressVal = inputFloat;
	}
	
	void RelaxToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumStateValue, maximumStateValue);
		relaxVal = inputFloat;

	}

	void MeditationToStoredFloat(OscMessage message) {
		float inputFloat = message.GetFloat(0);

		inputFloat = Mathf.Clamp(inputFloat, minimumStateValue, maximumStateValue);
		meditationVal = inputFloat;
	}


	public float AverageInputValues(float value1, float value2, float value3, float value4) {
		return (value1 + value2 + value3 + value4) / 4f;
	}

	public void UpdateEmotionalState() {


		
		//if the brainbit is connected, find the dominant value
		if (!debugMode) {



			stateValues[(int) EmotionalState.attention] = attentionVal;
			stateValues[(int) EmotionalState.stress] = stressVal;
			stateValues[(int) EmotionalState.relax] = relaxVal;
			stateValues[(int) EmotionalState.meditation] = meditationVal;
			stateValues[(int) EmotionalState.neutralState] = 0f;
			
			
			for (int i = 0; i < (int) EmotionalState.numEntries; i++) {
				if (stateValues[i] > stateValues[(int) currentState]) {
					currentState = (EmotionalState) i;
				}
			}
		}
		
		//see if our state changed
		if (previousState != currentState)
		{

			if (audioPicker.isPlayingVO) {
				//delay state change while VO is playing
				delayedChangeState = true;
			}
			
			else {




				//This sends out an event that can let other scripts know that the emotional state
				//has been changed
				EmotionalStateChanged();

				switch (currentState) {
					case EmotionalState.attention:
						audioPicker.PlayAttentionClips();
						break;
					case EmotionalState.stress:
						audioPicker.PlayStressClips();
						break;
					case EmotionalState.relax:
						audioPicker.PlayRelaxClips();
						break;
					case EmotionalState.meditation:
						audioPicker.PlayMeditationClips();
						break;
					default:
						break;
				}
			}

		} else {
			// check to see if we've passed the time limit, then repeat the audio clips
			//also if we have a delayed state change to process, do that now
			if (delayedChangeState) {
				EmotionalStateChanged();
				RepeatAudioClips();
				delayedChangeState = false;
			}
			
			sameStateTimer += Time.deltaTime;
			if (sameStateTimer >= sameStateRepeatTime && !audioPicker.isPlayingVO)
			{
				RepeatAudioClips();
			}
		}
		
		//set previous state to current state
		previousState = currentState;

	}

	public void EmotionalStateChanged() {
		if (OnChangeState != null) OnChangeState();
	}

	public void RepeatAudioClips() {
		
		
		
		audioPicker.ResetPlayedList();

		switch (currentState) {
			case EmotionalState.attention:
				audioPicker.PlayAttentionClips();
				break;
			case EmotionalState.stress:
				audioPicker.PlayStressClips();
				break;
			case EmotionalState.relax:
				audioPicker.PlayRelaxClips();
				break;
			case EmotionalState.meditation:
				audioPicker.PlayMeditationClips();
				break;
			default:
				break;
		}

		sameStateTimer = 0f;

	}

	public void VisitTheGuru() {
		if (pauseScanning) return;
		
		audioPicker.PlayGuruSegment();
		StartCoroutine(VisitGuru());
	}

	public IEnumerator VisitGuru() {
		
		pauseScanning = true;
		currentState = EmotionalState.meditation;
		//change the image
		EmotionalStateChanged();
		
		yield return new WaitForSeconds(20f);

		currentState = EmotionalState.neutralState;
		EmotionalStateChanged();
		pauseScanning = false;

	}
}
