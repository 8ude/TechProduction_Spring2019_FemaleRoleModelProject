using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCrossfaderScript : MonoBehaviour
{
    
    //trying an alternate way of implementing the fading scripts
    public InputVal inputVal;

    private float inputBCIValue;
    
    public float bciFadeInStart, bciFadeInEnd, bciFadeOutStart, bciFadeOutEnd;

    private AudioSource aSource;
    
    // Start is called before the first frame update
    void Start() {
        aSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputBCIValue = inputVal.imageValue;
        BCIChangeVolume();
    }
    
    //here's what i've added, which seems to be working a little better.  
    //in the inspector, we set our ranges 
    private void BCIChangeVolume() {
        if (inputBCIValue >= bciFadeInStart && inputBCIValue <= bciFadeInEnd) {
            
            //linearly interpolate from 0 - 1
            float volume = (inputBCIValue - bciFadeInStart) /
                               (bciFadeInEnd - bciFadeInStart);

            aSource.volume = volume;


        } else if (inputBCIValue >= bciFadeInEnd && inputBCIValue <= bciFadeOutStart) {

            aSource.volume = 1f;

        } else if (inputBCIValue >= bciFadeOutStart && inputBCIValue <= bciFadeOutEnd) {
            
            //linearly interpolate from 1 - 0
            float volume = 1f - ((inputBCIValue - bciFadeOutStart) /
                                     (bciFadeOutEnd - bciFadeOutStart));

            aSource.volume = volume;

        }
        else {

            aSource.volume = 0f;

        }
       
    }
}
