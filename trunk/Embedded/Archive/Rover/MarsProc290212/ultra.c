#include "p24HJ64GP506.h"
// sensitivity is threshold for ultrasonics
#define sensitivity 128

volatile unsigned int UltraSonicCycles;
volatile char UltraSonicState,Ultrasonicleft;
volatile unsigned int minADval;
volatile unsigned int ECHO;
volatile unsigned int ultracount;
volatile unsigned int lastecho;


void __attribute__((interrupt,auto_psv)) _T1Interrupt(void)  // 40 times a second or 25mS
															// on int sends an ultrasonic chirp (left/right)
															// new reading (L & R) every 20th second
{	
	Ultrasonicleft=!Ultrasonicleft;							
	UltraSonicCycles=8;			// how many cycles of chirp (40KHz)
	UltraSonicState=0;			// initialize echo state machine
	lastecho=ECHO;
	ultracount++;
	ECHO=0;
/*
read other A/Ds here
		AD1CON2=0;				// make sure that A/D is running and start reading
		AD1CON1=0x04e0;
		AD1CON3=0x0202;
		AD1CON1=0x84e0;
		AD1CHS0=0;  // look at AD channel 0
		AD1CON1bits.SAMP=1;minADval=0x7fff;

*/
	_T3IE=1;					// enable 40KHz interrupt
	_T1IF=0;					// cancle 40Hz interrupt
}

void __attribute__((interrupt,auto_psv)) _T3Interrupt(void)
{				// use the 40KHz Timer 3 to send the chirp and to measure echo
unsigned int v;
	switch (UltraSonicState)
	{
	case 0:				// send the chirp
	if (UltraSonicCycles--)
		{ 
		if (Ultrasonicleft) {if (OC5CON!=0xe) OC5CON=0xe;}
				else {if (OC6CON!=0xe) OC6CON=0xe;}
		}
		else
		{
		OC5CON=0x0;
		UltraSonicState=1;UltraSonicCycles=20; //delay to calm down
		AD1CON2=0;				// make sure that A/D is running and start reading
		AD1CON1=0x04e0;
		AD1CON3=0x0202;
		AD1CON1=0x84e0;
		AD1CHS0=0;  // look at AD channel 0
		AD1CON1bits.SAMP=1;minADval=0x7fff;
		}
		break;
	case 1:			// wait to settle down after chirp (and measure background level)
	if (!UltraSonicCycles--)  
		{
		UltraSonicState=2;	// Sample the A/D
		AD1CON1bits.SAMP=1;
		}
		else
		{v=ADC1BUF0;AD1CON1bits.SAMP=1;
		 if (v<minADval) minADval=v;		//  detect smallest background echo
		}
		break;
	case 2:
		UltraSonicCycles++;
		v=ADC1BUF0;AD1CON1bits.SAMP=1;	
		 if (v<minADval) minADval=v;
				// Test to look for echo (bigger than background + noise margin) and see how far we have counted (or time out)
		if ((v>(minADval+sensitivity)) || (UltraSonicCycles>250))	
			{
			  ECHO=UltraSonicCycles;
			  UltraSonicState=3;
			  _T3IE=0;				// as found echo (or timed out) disable 40KHz interrupt
			}
		break;
	} 	
	_T3IF=0;
}

void initultra(void)
{
ultracount=UltraSonicCycles=UltraSonicState=Ultrasonicleft=0;
ECHO=0;
PR3=91;				// setup the timer for 40KHz
T3CON=0x8000;
OC5RS=49;			// Ultrasonic width

PR1=12499;			// Set up timer for Ultra sonic chirps
					// 40Khz
T1CON=0x8010;		// (4000000 /8)= 500000Hz. Divide this by PR1 (12500)
_T1IF=0;
_T1IE=1;			// enable this 40KHz interrupt
}
