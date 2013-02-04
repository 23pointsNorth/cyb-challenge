/*****************************************************************************
 *
 *              Main.c -- user main program
 *
 *****************************************************************************
 * FileName:        HardwareProfile.c
 * Dependencies:
 * Processor:       PIC18F
 * Compiler:        C18 02.20.00 or higher
 *                  PICC 9.50.00 or higher
 *                  C30 02.03.00 or higher
 * Linker:          MPLINK 03.40.00 or higher
 * Company:         Microchip Technology Incorporated
 *
 * Software License Agreement
 *
 * Copyright © 2007-2008 Microchip Technology Inc.  All rights reserved.
 *
 * Microchip licenses to you the right to use, modify, copy and distribute 
 * Software only when embedded on a Microchip microcontroller or digital 
 * signal controller and used with a Microchip radio frequency transceiver, 
 * which are integrated into your product or third party product (pursuant 
 * to the terms in the accompanying license agreement).   
 *
 * You should refer to the license agreement accompanying this Software for 
 * additional information regarding your rights and obligations.
 *
 * SOFTWARE AND DOCUMENTATION ARE PROVIDED “AS IS” WITHOUT WARRANTY OF ANY 
 * KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION, ANY 
 * WARRANTY OF MERCHANTABILITY, TITLE, NON-INFRINGEMENT AND FITNESS FOR A 
 * PARTICULAR PURPOSE. IN NO EVENT SHALL MICROCHIP OR ITS LICENSORS BE 
 * LIABLE OR OBLIGATED UNDER CONTRACT, NEGLIGENCE, STRICT LIABILITY, 
 * CONTRIBUTION, BREACH OF WARRANTY, OR OTHER LEGAL EQUITABLE THEORY ANY 
 * DIRECT OR INDIRECT DAMAGES OR EXPENSES INCLUDING BUT NOT LIMITED TO 
 * ANY INCIDENTAL, SPECIAL, INDIRECT, PUNITIVE OR CONSEQUENTIAL DAMAGES, 
 * LOST PROFITS OR LOST DATA, COST OF PROCUREMENT OF SUBSTITUTE GOODS, 
 * TECHNOLOGY, SERVICES, OR ANY CLAIMS BY THIRD PARTIES (INCLUDING BUT 
 * NOT LIMITED TO ANY DEFENSE THEREOF), OR OTHER SIMILAR COSTS.
 *****************************************************************************/

#include "Compiler.h"
#include "Console.h"
#include "SymbolTime.h"
#include "P2P.h"
#include "P2PDefs.h"
#include "p24HJ64GP506.h"

#if defined(__18F4620) 
        #pragma romdata CONFIG1H = 0x300001
        const rom unsigned char config1H = 0b00000110;      // HSPLL oscillator
    
        #pragma romdata CONFIG2L = 0x300002
        const rom unsigned char config2L = 0b00011111;      // Brown-out Reset Enabled in hardware @ 2.0V, PWRTEN disabled
    
        #pragma romdata CONFIG2H = 0x300003
//        const rom unsigned char config2H = 0b00000000;     // HW WD disabled, 1:1 prescaler
        const rom unsigned char config2H = 0b00010110;     // HW WD ensabled, 1:64 prescaler
//        const rom unsigned char config2H = 0b00001010;      // HW WD enabled, 1:32 prescaler
    
        #pragma romdata CONFIG3H = 0x300005
        const rom unsigned char config3H = 0b10000000;      // PORTB digital on RESET
    
        #pragma romdata CONFIG4L = 0x300006
        const rom unsigned char config4L = 0b10000001;      // DEBUG disabled,
                                                            // XINST disabled
                                                            // LVP disabled
                                                            // STVREN enabled
#elif defined(__PIC24F__) 
	// Explorer 16 board 
	_CONFIG2(IESO_OFF & FNOSC_FRC & FCKSM_CSDCMD & OSCIOFNC_ON )		// 
	_CONFIG1(JTAGEN_OFF & FWDTEN_OFF & WDTPS_PS2048)		// JTAG off, watchdog timer off
#elif defined(__dsPIC33F__) || defined(__PIC24H__) 
	// Explorer 16 board
	_FOSCSEL(FNOSC_FRC);    
	_FOSC(OSCIOFNC_ON & FCKSM_CSDCMD)
	_FWDT(FWDTEN_OFF & WDTPOST_PS2048)				// Disable Watchdog timer
	// JTAG should be disabled as well
#elif defined(__PIC32MX__) 
    #define PIC32MX_SPI1_SDO_SCK_MASK_VALUE      (0x00000140)
    #define PIC32MX_SPI1_SDI_MASK_VALUE          (0x00000080)
    //#define PIC32MX_INT2_MASK_VALUE              (0x00000010)
    #define PIC32MX_INT1_MASK_VALUE              (0x00000008)
    /* MAX SPI CLOCK FREQ SUPPORTED FOR MIWI TRANSCIEVER */
    #define MAX_SPI_CLK_FREQ_FOR_P2P             (20000000)
    
    #define        Sleep()      PowerSaveSleep()
    
    #pragma config FPLLMUL = MUL_16, FPLLIDIV = DIV_2, FPLLODIV = DIV_1, FWDTEN = OFF
    #pragma config POSCMOD = XT, FNOSC = PRIPLL, FPBDIV = DIV_4, WDTPS = PS8192
#elif defined(__dsPIC30F__) 
               _FOSC(CSW_FSCM_OFF & FRC_PLL8);
               _FWDT(WDT_OFF);
               _FBORPOR(PBOR_OFF & MCLR_EN);

#endif

int adDMAbuf[32] __attribute__((space(dma),aligned(32)));

void SetupPORTS(void)
{
/*
PORTB	[TRIS=0x737F]
15  	O			[AN15/OCFB/CN12/RB15]
14		IA			[U2RTS/AN14/RB14]
13		I SW
12		I SW 
11		O LED
10		O LED
9		IA			[AN9/RB9]
8   	IA			[U2CTS/AN8/RB8]
7  		O	PGD
6   	IA	PGC	[PGC1/EMUC1/AN6/OCFA/RB6]
5   	IA		[AN5/IC8/CN7/RB5]
4   	IA		[AN4/IC7/CN6/RB4]
3   	IA	   
2   	IA	   
1   	IA	   	
0   	IA	

PORTC	[TRIS=0x0000]
15   	I	Distopto2C
14   	I	Distopto1C
13  	I	Distopto2B
12		O	
2	O	MiWi Wake
1	O	MiWi RST

PORTD	[TRIS=0x0F00]
11	    I	INT	MiWi
10      I	
9   	I	
8   	I	REMOTE IR detect [IC1/INT1/RD8]
7   	O	
6   	O	  
5  		O		 
4  		O		
3  		O	MOTOR 2 B    
2  		O	MOTOR 2 A   
1  		O	MOTOR 1 B   
0  		O	MOTOR 1 A

PORTF	[TRIS=0x0004]
6   	O		[U1RTS/SCK1/INT0/RF6]
5 		O		[U2TX/SCL2/CN18/RF5]  
4   	O		[U2RX/SDA2/CN17/RF4]
3		O		[U1TX/SDO1/RF3]
2  		I		[U1RX/SDI1/RF2]
1   	O	
0   	O	

PORTG	[TRIS=0x508F]
15   	I	Distopto1B
14  	I	
13  	O	
12  	O	
9	O	MiWi CS
8	O	MiWi SDO
7	I	MiWi SDI
6	O	MiWi SCK
3	I	SDA	PL4	I2C 10K pullup on daughter board
2	I	SCL	PL4	I2C 10K pullup on daughter board
1	I	
0	I	

Analog mask	0xBC80
*/
AD1PCFGH=0xffff;
AD1PCFGL=0xBC80;

AD1CON1=0x04e4;	
AD1CON2=0x0424;  
AD1CON3=0x0203;	// lowish sampling time. need to adjust TAD if change proc speed.
AD1CON4=0x0;	
AD1CHS0=0x000;
AD1CSSL=0x437f;

	/* initialise the DMA channel 3 for A/D */
	/* clear the collission flags */
	DMACS0=0;
    /* setup channel 3 for peripheral indirect addressing mode 
    normal operation, word operation and select as Rx to peripheral */
    DMA3CON=0x0020;
    /* setup the address of the peripheral  */ 
	DMA3PAD=(unsigned int)&ADC1BUF0;	
 	/* Set the data block transfer size of 2 */
 	DMA3CNT=9;
 	/* automatic DMA Rx initiation by DMA request */
	DMA3REQ=0x000d;	
	/* DPSRAM atart adddress offset value */ 
	DMA3STA=__builtin_dmaoffset(&adDMAbuf);	
	/* enable the channel */
	DMA3CONbits.CHEN=1;


AD1CON1=0x84e4;	
 
	LATB = 0x0800; 
	TRISB = 0x737F; 
	LATC = 0x0000; 
	TRISC = 0xe000; 
	LATD = 0x0000; 
	TRISD = 0x0F00; 
	LATF = 0x0000; 
	TRISF = 0x0004; 
	LATG = 0x0000; 
	TRISG = 0xC08F; 
	initi2c();

	OC3CON=0;OC4CON=0;OC3R=OC3RS=0;OC4R=OC4RS=0;
	OC2CON=0;OC5CON=0;OC2R=OC2RS=0;OC5R=OC5RS=0;

	T2CON=0x8000;
	PR2=127;
}



/*********************************************************************
 * Function:        void BoardInit( void )
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    Board is initialized for P2P usage
 *
 * Overview:        This function configures the board for the PICDEM-z
 *                  MRF24J40 usage 
 *
 * Note:            This routine needs to be called before the function 
 *                  to initialize P2P stack or any other function that
 *                  operates on the stack
 ********************************************************************/

void BoardInit(void)
{
SetupPORTS();

            SPI2CON1 = 0b0000000100111110;
            SPI2STAT = 0x8000;
        
            INTCON2bits.INT1EP = 1;
       
        
        PHY_RESETn = 0;
        PHY_RESETn_TRIS = 0;
        PHY_CS = 1;
        PHY_CS_TRIS = 0;
        PHY_WAKE = 1;
        PHY_WAKE_TRIS = 0;

        RFIF = 0;
        RFIE = 1;
        
        if( RF_INT_PIN == 0 )
        {
            RFIF = 1;
        }
}




/*********************************************************************
 * Function:        void Enable_PB_1_2_Interrupts()
 *
 * PreCondition:    None
 * 
 * Input:           None
 * 
 * Output:          None
 * 
 * Side Effects:    None
 * 
 * Overview:        Configure/Enable PB 1 & 2 interrupts.
 *  
 * Note:            None
 ********************************************************************/

#ifdef __PIC32MX__

void Enable_PB_1_2_Interrupts(void)
{
    unsigned int value;

    CNCON = 0x8000;  // Enable Change Notice module

    /* Configure Change Notice Registers for Push Button 1 & 2. These buttons can be 
       used to wake the controller from sleep state. */
    CNEN  = 0x00018000; // Enable CN15 and CN16 pins

    /* Read port to clear mismatch on change notice pins */
    value = PORTD;

    mCNClearIntFlag(); // Clear the CN interrupt flag status bit

    mCNIntEnable(1); // Enable Change Notice interrupts
}

#endif

