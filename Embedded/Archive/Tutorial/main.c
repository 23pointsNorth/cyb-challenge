//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//	Filename:			N:\Tutorial Project\main.c
//	Dependancies:	
//	Processor:			Microchip PIC24HJ128GP504
//	Compiler:			Microchip C30
//	IDE:				Microchip MPLAB
//	Hardware Dependencies:	
//	
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//	Revision History
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//	Author				Date		    Version	Comments on this revision
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//	Stephen Gould		09/01/2012		1.0		First version
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//
// Hardware Utilisation/Configuration
//
//	|----------------------------------------------------------------------------------------
//	| Pin  		| Mem  	|A/D	| Dir	| Name              
//  | Bit  		|       |    	|      	|
//	|----------------------------------------------------------------------------------------
//	|  PORT A0  | RA0  	|  D 	| Out 	| LED D3
//	|  PORT D6	| RD6  	|  D 	| In   	| SWITCH S3
//	|----------------------------------------------------------------------------------------

//** I N C L U D E S ************************************************************************
//#include "p24hj128GP504.h"
#include "p24hj256gp610a.h"
#include "lcd.h"
#include "I2C.h"

//** F U S E S ******************************************************************************
//----------- Setup configuration bit defined by MPLAB when using the PIC24HJ128GP610A
	_FOSCSEL(FNOSC_PRIPLL & IESO_OFF)
	_FOSC(FCKSM_CSDCMD & OSCIOFNC_OFF & POSCMD_XT)
	_FWDT(FWDTEN_OFF)

//** C O M P I L E R   D E F I N I T I O N S ************************************************
#define OUTPUT 	0
#define INPUT 	1
#define TRUE	1
#define FALSE 	0
#define false	0
#define On 		1
#define Off		0

//** L E D **********************************************************************************
#define Init_LEDs()		TRISA = TRISA & 0xfffe		// clear A0, making it an output
#define LED_3       	LATAbits.LATA0				// A0 latch

#define LED_3_On() 		LED_3 = On;					// set A0 latch

#define LED_3_Off() 	LED_3 = Off;				// clear A0 latch

#define LED_3_Toggle()	LED_3 = !LED_3;				// invert A0

//** S W I T C H E S ************************************************************************
#define Init_SWITCH()		TRISDbits.TRISD13 = INPUT;	// set D13, making it an input
#define SWITCH_4_READ	PORTDbits.RD13				// read D13

//** V A R I A  B L E S *********************************************************************
volatile unsigned int tick;

//** P R O T O T Y P E S ********************************************************************
void delayms(int);

//** S U B R O U T I N E S ******************************************************************

int testswitch(void)							// returns TRUE if switch depressed, else FALSE
{
	int button;
	
	button = (SWITCH_4_READ & 0x0001);			// read switch S4
	if (button == FALSE)	return(TRUE);		// if it is pressed ( pin == 0) return true
	return (FALSE);
}

void setleds(unsigned int value)
{
	LATA = value &0x0001;						// switch on the leds indicated by value
}

void __attribute__((interrupt, auto_psv)) _T2Interrupt(void)
{
	tick++;										// increment tick counter every T2 interrupt
	_T2IF=0;									// clear the T2 interrupt flag
}

void Clear_LCD(void) {
    showString("      test      ", 0, 16, false);
    showString("                ", 1, 16, false);
}

//** M A I N *********************************************************************************

int main( void )
{
	unsigned char switch_3_state = 0;
	Init_LEDs();
	Init_SWITCH();
    Init_LCD(); 							// set up the LCD display 
    Clear_LCD();	
    Init_I2C();
		
	setleds(0x0000);						// turn all the LEDS off
	
	PR2 = 399;
	T2CON=0x8000;
	_T2IF = 0;								// clear the Timer 2 Interrupt Flag
	_T2IE = 1;								// enable Timer 2 interrupts
		
	while (-1)
	{	
		if (testswitch()) 					// if testswitch() returns true (==1) then
		{
			if (switch_3_state == 0)
			{
				showString("Switch 3 On     ", 0, 16, false);	
			}
			else
			{
				showString("Switch 3 Off     ", 0, 16, false);
			}
			LED_3_Toggle();					// toggle LED D3
			switch_3_state = !switch_3_state;
		}
		delayms(500);							// delay tp prevent switch bounce
	}
}

//** E N D ***********************************************************************************

