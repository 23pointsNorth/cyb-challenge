#include "p32mx340f256h.h"

// Include all headers for any enabled TCPIP Stack functions
#include "TCPIP Stack/TCPIP.h"

#if defined(STACK_USE_ZEROCONF_LINK_LOCAL)
#include "TCPIP Stack/ZeroconfLinkLocal.h"
#endif
#if defined(STACK_USE_ZEROCONF_MDNS_SD)
#include "TCPIP Stack/ZeroconfMulticastDNS.h"
#endif

// Include functions specific to this stack application
#include "MainDemo.h"
#include "i2c.h"



void initi2Cs(void);

// Private helper functions.
// These may or may not be present in all applications.
void InitAppConfig(void);
void InitializeBoard(void);
void ProcessIO(void);

volatile int LINEA,LINEB;
volatile int LINEAOFF, LINEBOFF, LINEAON, LINEBON;
int LINETa=512;	// if below this value then black line
int LINETb=512;

volatile unsigned int bitdelcount;
volatile char lastIR;
volatile int IRstreamHead,IRstreamTail,IRstreamLen;
volatile unsigned char IRres[512];
volatile unsigned char IRres2[512];
int speed1=0x7fff;
int pos1=0;
int speed2=0x7fff;
int pos2=0;

void setspeed(int newspeed1,int newspeed2);


// IR settings

#define IR_ON_PERIOD	15000
#define IR_OFF_PERIOD	1000
#define RESPONSE_TIME	1000
volatile int status = 1;
volatile int ir_timer = 0;


//MAG VAR

#define MAG_BUFFER_PACKET_SIZE		60
#define MAG_PACKETS_PER_AXIS		16
#define MAG_DATA_BUFFER_PER_AXIS	(MAG_BUFFER_PACKET_SIZE * MAG_PACKETS_PER_AXIS)

#define MAG_DATA_PERIOD				68

unsigned int mag_data_x[MAG_DATA_BUFFER_PER_AXIS];
unsigned int mag_data_y[MAG_DATA_BUFFER_PER_AXIS];
unsigned int mag_data_z[MAG_DATA_BUFFER_PER_AXIS];

char mag_acquire_data = 0;
char should_send_mag = 0;
unsigned int mag_data_pos = 0;
unsigned int mag_ticker = 0;


//ACCELEROMETER VAR

#define ACC_BUFFER_PACKET_SIZE	60
#define ACC_PACKETS				17
#define ACC_DATA_BUFFER			(ACC_BUFFER_PACKET_SIZE * ACC_PACKETS)	

unsigned int acc_data_z[ACC_DATA_BUFFER];
unsigned int acc_cur_pos = 0;
char acc_data_aquire = 0;
char should_send_acc = 0;
unsigned int acc_data_ticker = 0;
#define ACC_DATA_PERIOD			2


// IR DATA

#define IR_DATA_BUFFER_SIZE		10
char send_IR_update = 0;

#define IR_DATA_DELAY_PERIOD	100
unsigned int ti	= 0;
unsigned int IR_pos_l[IR_DATA_BUFFER_SIZE];
unsigned int IR_pos_r[IR_DATA_BUFFER_SIZE];
int IR_data_l[IR_DATA_BUFFER_SIZE];
int IR_data_r[IR_DATA_BUFFER_SIZE];
int current_pos = 0;
unsigned int avrg_pos=0;


// ENCODER STEPS

unsigned int wanted_encoder_steps = 0;
unsigned int encoder_l_old = 0;
unsigned int encoder_r_old = 0;

char drive_by_steps = 0;

int wanted_speed_left;
int wanted_speed_right;
int le_old;				//left encoder old value
int re_old;


// CONTROL SYSTEMS

unsigned long ticker4 = 0;
#define SYS_FREQ			80000000L
#define PRESCALE			2
#define PB_DIV				8
#define TOGGLES_SEC_SPEED	205 //At 10Hz // lower value to increase freq 2048 = 1Hz
#define TOGGLE_SEC_POSITION	10	//At ¬205Hz
#define INTER_FREQ			10  //10HZ at 205 toggles
#define T4_TICK       		(SYS_FREQ/PB_DIV/PRESCALE)

#define MAX_SPEED_ENCODER_STEPS	230
#define SLOPE					5

#define MAX_SPEED			127 //encoder steps/second
int DRIVE_MAX_SPEED	= 100;
int DIRECTION = 1;

#define LEFT_DRIVE_COEF		(float)(1)
#define RIGHT_DRIVE_COEF	(float)(1.125)

#define MIN_SPEED			50	// [-127;128] values

#define PROP				15


//Called with freq = 2048Hz
void __attribute((interrupt(ipl2), vector(_TIMER_4_VECTOR), nomips16)) _T4Interrupt(void)
{
	int new = 0;
	int z = 0;
	// Reset interrupt flag
	mT4ClearIntFlag();	


	mPORTEToggleBits(BIT_3);
	// Increment internal high tick counter
	ticker4++;
	acc_data_ticker++;
	mag_ticker++;

	//MAG
	if ((mag_ticker % MAG_DATA_PERIOD ==0) && (mag_acquire_data != 0))
	{
		I2S();I2send(0x3c);I2send(9);I2SR();I2send(0x3d);
		new = I2GET(0) & 0x01; // status register
		I2P();
		if (new != 0)
		{
			I2S();I2send(0x3c);I2send(3);I2SR();
			I2send(0x3d);
			// X		
			mag_data_x[mag_data_pos] = (I2GET(1) << 8);
			mag_data_x[mag_data_pos] += I2GET(1);
			// Y		
			mag_data_y[mag_data_pos] = (I2GET(1) << 8);
			mag_data_y[mag_data_pos] += I2GET(1);
			// Z		
			mag_data_z[mag_data_pos] = (I2GET(1) << 8);
			mag_data_z[mag_data_pos] += I2GET(0);
	
			I2P();
	
			mag_data_pos++;
		}

		if (mag_data_pos >= MAG_DATA_BUFFER_PER_AXIS)
		{
			mag_data_pos = 0;
			mag_acquire_data = 0;
			should_send_mag = 1;
		}

		mag_ticker = 0;
	}

	//ACC
	if ((acc_data_ticker % ACC_DATA_PERIOD == 0) && (acc_data_aquire != 0))
	{
		I2S();I2send(0x38);
		I2send(0x00);I2SR();I2send(0x39);
		new = I2GET(0) & 0x04; //0x00 reg - status
		I2P();
		if (new != 0)
		{
			//read z_pos;
			I2S();I2send(0x38);
			I2send(0x05);I2SR();I2send(0x39);
			acc_data_z[acc_cur_pos] = I2GET(1) << 4; //0x05 reg -  msb
			acc_data_z[acc_cur_pos] += (I2GET(0) >> 4); //0x06 - lsb
			I2P();
			//End read
	
			acc_cur_pos++;
		}

		if (acc_cur_pos >= ACC_DATA_BUFFER)
		{
			acc_cur_pos = 0;
			acc_data_aquire = 0;
			should_send_acc = 1; // Send report that it has finished
		}

		acc_data_ticker=0;
	}

	if (ticker4 % TOGGLE_SEC_POSITION)
	{
		if (drive_by_steps != 0)
		{
/*
			unsigned int driven_pos_l = pos1;
			unsigned int driven_pos_r = pos2;
			if (pos1 < encoder_l_old) driven_pos_l =+ 0xFFFF;
			if (pos2 < encoder_r_old) driven_pos_r =+ 0xFFFF;

			if ((encoder_l_old + wanted_encoder_steps <= driven_pos_l) &&
			   ( encoder_r_old + wanted_encoder_steps <= driven_pos_r))
*/
			if ((abs(encoder_l_old - pos1) >= wanted_encoder_steps) ||
				(abs(encoder_r_old - pos2) >= wanted_encoder_steps))
			{
				drive_by_steps = 0;
				wanted_speed_right = 0;
				wanted_speed_left = 0;
				setspeed(wanted_speed_left, wanted_speed_right);
				POSTTCPhead(1 ,128);				
				POSTTCPchar(1); // send a command that i am done
			}
			else
			{
				//Left
				if (abs(encoder_l_old + wanted_encoder_steps - pos1) > MAX_SPEED_ENCODER_STEPS)   
				{
					wanted_speed_left = DRIVE_MAX_SPEED * DIRECTION;
				}
				else
				{
					wanted_speed_left = min(max((pos1 - encoder_l_old) * SLOPE  * DIRECTION, MIN_SPEED  * DIRECTION), DRIVE_MAX_SPEED * DIRECTION);
					//wanted_speed_left = MIN_SPEED;
				}   
 
				//Right
				if (abs(encoder_r_old + wanted_encoder_steps - pos2) > MAX_SPEED_ENCODER_STEPS)   
				{
					wanted_speed_right = DRIVE_MAX_SPEED * DIRECTION;
				}
				else
				{
					wanted_speed_right = min(max((pos2 - encoder_r_old) * SLOPE * DIRECTION, MIN_SPEED * DIRECTION), DRIVE_MAX_SPEED * DIRECTION);
					//wanted_speed_right = MIN_SPEED;
				}

				wanted_speed_left = (int)(wanted_speed_left * LEFT_DRIVE_COEF);
				wanted_speed_right = (int)(wanted_speed_right * RIGHT_DRIVE_COEF);
      
				//Check motor speeds
				if (wanted_speed_left > 127) wanted_speed_left = 127;
				if (wanted_speed_left < -127) wanted_speed_left = -127;
				if (wanted_speed_right > 127) wanted_speed_right = 127;
				if (wanted_speed_right < -127) wanted_speed_right = -127;


				setspeed(wanted_speed_left, wanted_speed_right);   
			}   
		}
	}

	if (ticker4 % TOGGLES_SEC_SPEED == 0)
	{
		//mPORTEToggleBits(BIT_3);

		//Feedback left motor
		int delta_e_l = (wanted_speed_left/127)*MAX_SPEED_ENCODER_STEPS/10;
		int actual_de_l = (pos1 - le_old);
		if (actual_de_l < 0) {actual_de_l = 0xFFFF - le_old + pos1;} 
		le_old = pos1;
		
		int l_error = actual_de_l - delta_e_l;

		if (l_error > 0)
		{
			if (wanted_speed_left > 0)
				speed1 = speed1 - PROP * abs(l_error); 
			else speed1 = speed1 + PROP * abs(l_error);
		}
		else if (l_error < 0)
		{
			if (wanted_speed_left > 0)
				speed1 = speed1 + PROP * abs(l_error); 
			else speed1 = speed1 - PROP * abs(l_error);
		}

		//Feedback right motor
		int delta_e_r = (wanted_speed_right/127)*MAX_SPEED_ENCODER_STEPS/10;
		int actual_de_r = (pos2 - re_old);
		if (actual_de_r < 0) {actual_de_r = 0xFFFF - re_old + pos2;} 
		re_old = pos2;
		
		int r_error = actual_de_r - delta_e_r;
		if (r_error > 0)
		{
			if (wanted_speed_right > 0)
				speed2 = speed2 - PROP * abs(r_error); 
			else speed2 = speed2 + PROP * abs(r_error);
		}
		else if (r_error < 0)
		{
			if (wanted_speed_right > 0)
				speed2 = speed2 + PROP * abs(r_error); 
			else speed2 = speed2 - PROP * abs(r_error);
		}		

		//Check motor speeds
		if (speed1 > 127) speed1 = 127;
		if (speed1 < -127) speed1 = -127;
		if (speed2 > 127) speed2 = 127;
		if (speed2 < -127) speed2 = -127;
	
		//Set new motor speeds
		setspeed(speed1, speed2);
		ticker4 = 0; //Reset
	}
}


//ADC
// IR uC 
void __attribute((interrupt(ipl3), vector(_ADC_VECTOR), nomips16)) _ADCInterrupt(void)
{
  int i;
  if (lastIR==IR_IO)
    {if (bitdelcount<256)
     {
	 bitdelcount++;
	 if ((bitdelcount & 0xf)==0)
		{
			if (lastIR) IRres[IRstreamHead++]=0x80; else IRres[IRstreamHead++]=0x00;
			if (IRstreamHead>511) IRstreamHead=255;
		}
     }
    }
	else
	{lastIR=IR_IO;
	 if (bitdelcount>=256) 
        {
			if (IRstreamTail==0)
				{
					for (i=0;i<IRstreamHead;i++) IRres2[i]=IRres[i];
					IRstreamLen=IRstreamHead;
					IRstreamHead=IRstreamTail=0;
				}
		}
     bitdelcount=7;
    }	
  if (AD1CON2bits.BUFS)
		{
			//Standard!
			LINEA=ADC1BUF0; //IR LED ON
		    LINEB=ADC1BUF1;
	
			if ((status == 1) && (ir_timer < IR_ON_PERIOD - RESPONSE_TIME))
			{
				//CUSTOM
				LINEAON=ADC1BUF0; //IR LED ON
				LINEBON=ADC1BUF1;
			}
			ir_timer--;
			if (ir_timer <= 0)
			{
				if (status == 1)
				{
					//CUSTOM
					LINEAON=ADC1BUF0; //IR LED ON
					LINEBON=ADC1BUF1;

					//switch IR Off
					status = 0;
					LED2_IO = 0;
					LED3_IO = 0;
					ir_timer = IR_OFF_PERIOD;
				}
				else
				{
					LINEAOFF=ADC1BUF0; 
					LINEBOFF=ADC1BUF1;

					//Swtich ON
					status = 1;
					LED2_IO = 1;
					LED3_IO = 1;
					ir_timer = IR_ON_PERIOD;				
				}
			}
		}
		else
		{
			//Standard!
		   LINEAOFF=ADC1BUF8; //IR LED OFF
		   LINEBOFF=ADC1BUF9;

			if ((status == 1) && (ir_timer < IR_ON_PERIOD - RESPONSE_TIME))
			{
				//CUSTOM
				LINEAON=ADC1BUF8; //IR LED ON
				LINEBON=ADC1BUF9;
			}
			ir_timer--;
			if (ir_timer <= 0)
			{
				if (status == 1)
				{
					//CUSTOM
					LINEAON=ADC1BUF8; //IR LED ON
					LINEBON=ADC1BUF9;

					//switch IR Off
					status = 0;
					LED2_IO = 0;
					LED3_IO = 0;
					ir_timer = IR_OFF_PERIOD;
				}
				else
				{
					LINEAOFF=ADC1BUF8; 
					LINEBOFF=ADC1BUF9;

					//Swtich ON
					status = 1;
					LED2_IO = 1;
					LED3_IO = 1;
					ir_timer = IR_ON_PERIOD;				
				}
			}
		}
IFS1bits.AD1IF=0;
}


/* Moved up
int speed1=0x7fff;
int pos1=0;
int speed2=0x7fff;
int pos2=0;
*/

//REVERSE SOGNS TO ACCOMODATE REVERSED SPEED > to <
//encoder interrupt on rise and fall edge
void __attribute((interrupt(ipl4), vector(_INPUT_CAPTURE_1_VECTOR), nomips16)) _IC1Interrupt(void)
{
	if (speed1 < 0) pos1++; else pos1--;
	IFS0bits.IC1IF=0;

	
}

void __attribute((interrupt(ipl4), vector(_INPUT_CAPTURE_3_VECTOR), nomips16)) _IC3Interrupt(void)
{
	int q;
	if (speed2 < 0) pos2++; else pos2--;
	IFS0bits.IC3IF=0;
/*
if (send_IR_update != 0)
	{
		//REAAD IR data
		IR_pos_l[current_pos] = pos1;
		IR_pos_r[current_pos] = pos2;
		IR_data_l[current_pos] = LINEA;
		IR_data_r[current_pos] = LINEB;
		
		current_pos++;
		if (current_pos >= IR_DATA_BUFFER_SIZE)
		{ 
			setspeed(0, 0); 
			current_pos = 0; 
			POSTTCPhead(6 * IR_DATA_BUFFER_SIZE, 132);
			for (q = 0; q < IR_DATA_BUFFER_SIZE; q++)
			{
				POSTTCPchar(IR_data_l[q]);
				POSTTCPchar(IR_data_l[q] >> 8);

				POSTTCPchar(IR_data_r[q]);
				POSTTCPchar(IR_data_r[q] >> 8);

				avrg_pos = IR_pos_l[q]/2 + IR_pos_r[q]/2;
				POSTTCPchar(avrg_pos);
				POSTTCPchar(avrg_pos >> 8);
			}
			setspeed(wanted_speed_left, wanted_speed_right); 
		}
	}*/
}

#define comsdatasize 1024
char comsdata[comsdatasize];
unsigned int comsdatahead=0;
unsigned int comsdatatail=0;
void putcomsdata(char v)
{
  unsigned int nhead;
  nhead=comsdatahead+1;
  if (nhead>=comsdatasize) nhead-=comsdatasize;
  if (nhead!=comsdatatail)
	{
       comsdatahead=nhead;
       comsdata[comsdatahead]=v;
	}
}

char yescomsdata(void)
{
  if (comsdatatail!=comsdatahead) return(1); else return(0);
}

char getcomsdata(void)
{
  if (comsdatatail==comsdatahead) return(0);
  comsdatatail++;
  if (comsdatatail>=comsdatasize) comsdatatail-=comsdatasize;
  return(comsdata[comsdatatail]);
}

char peekcomsdata(void)
{
  int i;
  if (comsdatatail==comsdatahead) return(0);
  i=comsdatatail+1;
  if (i>=comsdatasize) i-=comsdatasize;
  return(comsdata[i]);
}

UINT16  globalRSSI=255;
void POSTTCPchar(char b);
void POSTTCPhead(int len,int id)
{
   POSTTCPchar(0xff);POSTTCPchar(len+2);POSTTCPchar(globalRSSI);POSTTCPchar(id);
}

int commandstate=-1;
int commandlen;
unsigned char nextcommand[256];
UINT16 REQCOUNT=0;
int waveid=0;

void initi2Cs(void)  // called once when rover starts
{
	//setup accn MMA8452Q									//Data rate active mode
										//I2S();I2send(0x38);I2send(0x2a);I2send(0x20);/*50Hz nonactive */ I2send(0x2);I2P();
										//I2S();I2send(0x38);I2send(0x2a);I2send(0x21);/*50Hz active */ /*I2send(0x2);*/I2P();
										I2S();I2send(0x38);I2send(0x2a);I2send(0x09);/*400Hz active noise reduction*/ I2P();
										//As above are commented values should be -> +-2g, at 400Hz
	//setup ad MCP3425
										I2S();I2send(0xd0);I2send(0x90);I2P();
	//setup io MCP23008  // to be done
//										I2S();I2send(0x4e);I2send(0x90);I2P();
	//setup gyro L3G4200D  // to be done
//										I2S();I2send(0xd2);I2send(0x90);I2P();
//setup mag HMC5883L
										I2S();I2send(0x3c);I2send(0x0);I2send(0x70);I2send(0x20);I2send(0x00);I2P(); // Leave standard 15Hz
										//I2S();I2send(0x3c);I2send(0x0);I2send(0x68);I2send(0x20);I2send(0x00);I2P(); // Set to 30Hz
}


//REVERSE MOTOR SPEED IF  == < > to == > <
void setspeed(int newspeed1,int newspeed2)  // routine sets speed of motors 
											// only alters motors if speed has changed
{
  if (newspeed1!=speed1)
	{
			speed1=newspeed1;
			  if (speed1==0) {LATD&=~0x006;OC3CON=0;OC2CON=0;OC3R=OC3RS=0;OC2R=OC2RS=0;}
			  if (speed1>0) 
				{	
					OC3CON=0;OC3R=OC3RS=0;
					OC2RS=abs(speed1);
					if (!OC2CON) OC2CON=0x8006;											 
				}
			  if (speed1<0) 
				{
					OC2CON=0;OC2R=OC2RS=0;
					OC3RS=abs(speed1);
					if (!OC3CON) OC3CON=0x8006;											 
				}
	}
  if (newspeed2!=speed2)
	{
			speed2=newspeed2;
			  if (speed2==0) {LATD&=~0x0018;OC4CON=0;OC5CON=0;OC4R=OC4RS=0;OC5R=OC5RS=0;}
			
			  if (speed2>0) 
					{
						OC5CON=0;OC5R=OC5RS=0;
						OC4RS=abs(speed2);
						if (!OC4CON) OC4CON=0x8006;										 
					}
			  if (speed2<0) 
					{
						OC4CON=0;OC4R=OC4RS=0;
						OC5RS=abs(speed2);
						if (!OC5CON) OC5CON=0x8006;											 
					}
	}
}

int bptag=0;

void processcommand(void)		// the main routine which processes commands
{
 int i; int pack; int axis;
 unsigned char wk;
 int blocklen;
  switch (nextcommand[0]) // sort on command id (each case is for a different command)
  {
    case 0:POSTTCPhead(0,0);break;
	case 1:POSTTCPhead(1,1);    //Ask for Led and Switch status Packet
			POSTTCPchar(((~PORTE<<2) & 0xc)| ((~PORTD>>6) & 3)| ((LATE<<2) & 0x30));
			break;
	case 2:if (commandlen==1)		//Set LEDs
			{
			  if (nextcommand[1] & 2) LED1_IO=0; else LED1_IO=1;
			  if (nextcommand[1] & 1) LED0_IO=0; else LED0_IO=1;
			  POSTTCPhead(0,2);break;
			}
			break;
	case 3:POSTTCPhead(2,3);  // get internal counter
			POSTTCPchar(REQCOUNT & 0xff);
			POSTTCPchar((REQCOUNT>>8) & 0xff);REQCOUNT++;
			break;
	case 4:  // request motor status here 
			 POSTTCPhead(9,4);
			  POSTTCPchar(speed1);
			  POSTTCPchar(pos1);
			  POSTTCPchar(pos1>>8);

			  POSTTCPchar(speed2);
			  POSTTCPchar(pos2);
			  POSTTCPchar(pos2>>8);

			  POSTTCPchar(0);
			  POSTTCPchar(0);
			  POSTTCPchar(0);
			break;
	case 5:if (commandlen==1)	// set motor1
			{
				drive_by_steps = 0;
				wanted_speed_left = nextcommand[1];
			  setspeed((char)nextcommand[1],speed2);
			 POSTTCPhead(0,5);
			}
			break;
	case 6:if (commandlen==1)	// set motor2
			{
				drive_by_steps = 0;
				wanted_speed_right = nextcommand[1];
			  setspeed(speed1,(char)nextcommand[1]);
			 POSTTCPhead(0,6);
			}
			break;
	case 7:if (commandlen==2)	// set both motors
			{
				drive_by_steps = 0;
				wanted_speed_left = nextcommand[1];
				wanted_speed_right = nextcommand[2];
			  setspeed((char)nextcommand[1],(char)nextcommand[2]);
			 POSTTCPhead(0,7);
			}
			break;
	case 8:	// report line following
			POSTTCPhead(5,8);
			i=0;
			if (LINEA<LINETa) i|=1;
			if (LINEB<LINETb) i|=2;
			POSTTCPchar(i);
			i=LINEA;
			POSTTCPchar(i);POSTTCPchar(i>>8);
			i=LINEB;
			POSTTCPchar(i);POSTTCPchar(i>>8);
			break;
	case 9:	if (commandlen==5)	// set line following thrsholds and LEDS
            {
			if (nextcommand[1]& 1) LED2_IO=1; else LED2_IO=0;
			if (nextcommand[1]& 2) LED3_IO=1; else LED3_IO=0;
			i=nextcommand[2]|(nextcommand[3]<<8);
			LINETa=i;
			i=nextcommand[4]|(nextcommand[5]<<8);
			LINETb=i;
			POSTTCPhead(0,9);
            }
			break;
	case 10:  
			 if (commandlen==1)	//request ultrasonic wave
			 {
			  I2S();I2send(0xB8);I2send(128);I2send(nextcommand[1]);
			  I2P();
			  POSTTCPhead(0,10);
			 } 
			break;
	case 11:  
			 if (commandlen==0)	//request utrasonic wave status
			 {
			  POSTTCPhead(1,11);
			  I2S();I2send(0xB8);I2send(128);
			  I2SR();I2send(0xb9);
			  POSTTCPchar(I2GET(0));
			  I2P();
			 } 
			waveid=0;
			break;
	case 12:  
			 if (commandlen==0)	//send ultrasonics wave section
			 {POSTTCPhead(86,12);
			  I2S();I2send(0xB8);I2send(129);I2SR();I2send(0xb9);
			  
			  POSTTCPchar(waveid++);
			  for (i=1;i<=85;i++)
				{POSTTCPchar(I2GET(i!=85));
				}
			 if (waveid==3) 
					bptag=1;
			  I2P();
			 } 
			break;
	case 13:  
			 if (commandlen==1)	//send ultrasonics trim
			 {
					  if ((nextcommand[1]>90) && (nextcommand[1]<110))
				{
			      I2S();I2send(0xB8);I2send(8);I2send(nextcommand[1]);
			      I2P();POSTTCPhead(0,13);
				}
			 } 
			break;
	case 16:  
			 if (commandlen==0)	//send ultrasonics
			 {POSTTCPhead(8,16);
			  I2S();I2send(0xB8);I2send(0);I2SR();I2send(0xb9);
			  for (i=1;i<=8;i++)
				{POSTTCPchar(I2GET(i!=8));
				}
			  I2P();
			 } 
			break;
	case 17:  
			 if (commandlen==0)	//send light/aux
			 {
			  I2S();I2send(0xB8);I2send(10);I2SR();I2send(0xb9);
			  POSTTCPhead(4,17);
			  for (i=1;i<=4;i++)
				{POSTTCPchar(I2GET(i!=4));
				}
			  I2P();
			 } 
			break;
	case 18:  
			 if (commandlen==3)	//pump init
			 {
			  POSTTCPhead(0,18);
			  I2S();I2send(0x12);I2send(0); I2send(nextcommand[1]);I2send(nextcommand[2]);I2send(nextcommand[3]);
			  I2P();
			 } 
			break;
	case 19:  
			 if (commandlen==1)	//pump write delta
			 {
			  POSTTCPhead(0,19);
			  I2S();I2send(0x12);I2send(0); I2send(nextcommand[1]);
			  I2P();
			 } 
			break;
	case 20:  
			 if (commandlen==0)	//pump read
			 {
			  POSTTCPhead(4,20);
			  I2S();I2send(0x12);I2send(0);I2SR();I2send(0x13);
			  for (i=1;i<=4;i++)
				{POSTTCPchar(I2GET(i!=4));
				}
			  I2P();
			 } 
			break;
	case 21:  
			 if (commandlen==1)	//POWER SWITCH
			 {
			  POSTTCPhead(0,21);
			  I2S();I2send(0x14);I2send(0); I2send(nextcommand[1]);
			  I2P();
			 } 
			break;
	case 22:  
			 if (commandlen==1)	//POWER SERV0 1
			 {
			  POSTTCPhead(0,22);
			  I2S();I2send(0x14);I2send(1); I2send(nextcommand[1]);
			  I2P();
			 } 
			break;
	case 23:  
			 if (commandlen==1)	//POWER SERV0 2
			 {
			  POSTTCPhead(0,23);
			  I2S();I2send(0x14);I2send(2); I2send(nextcommand[1]);
			  I2P();
			 } 
			break;
	case 24:  
			 if (commandlen==0)	//POWER READ AD0
			 {
			  POSTTCPhead(2,24);
			  I2S();I2send(0x14);I2send(8);I2SR();I2send(0x15);
			  for (i=1;i<=2;i++)
				{POSTTCPchar(I2GET(i!=2));
				}
			  I2P();
			 } 
			break;
	case 25:  
			 if (commandlen==0)	//POWER READ AD1
			 {
			  POSTTCPhead(2,25);
			  I2S();I2send(0x14);I2send(10);I2SR();I2send(0x15);
			  for (i=1;i<=2;i++)
				{POSTTCPchar(I2GET(i!=2));
				}
			  I2P();
			 } 
			break;
	case 26:  
			 if (commandlen==0)	//POWER READ AD6  - photo diode
			 {
			  POSTTCPhead(2,26);
			  I2S();I2send(0x14);I2send(12);I2SR();I2send(0x15);
			  for (i=1;i<=2;i++)
				{POSTTCPchar(I2GET(i!=2));
				}
			  I2P();
			 } 
			break;
	case 27:  
			 if (commandlen==0)	//POWER READ AD7  - thermistor
			 {
			  POSTTCPhead(2,27);
			  I2S();I2send(0x14);I2send(14);I2SR();I2send(0x15);
			  for (i=1;i<=2;i++)
				{POSTTCPchar(I2GET(i!=2));
				}
			  I2P();
			 } 
			break;
	case 28:  
			 if (commandlen==0)	//IR rx
			 {
 			  blocklen=(IRstreamLen+7)/8;
			  POSTTCPhead(blocklen,28);
			  for (i=1;i<=blocklen;i++)
				{
				 wk=IRres2[IRstreamTail++];
				 wk=(wk>>1) | IRres2[IRstreamTail++];
				 wk=(wk>>1) | IRres2[IRstreamTail++];
				 wk=(wk>>1) | IRres2[IRstreamTail++];
                 wk=(wk>>1) | IRres2[IRstreamTail++];
				 wk=(wk>>1) | IRres2[IRstreamTail++];
				 wk=(wk>>1) | IRres2[IRstreamTail++];
				 wk=(wk>>1) | IRres2[IRstreamTail++];
				 POSTTCPchar(wk);
				}
			  IRstreamLen =IRstreamTail=0;
			 } 
			break;
	case 40:  
			 if (commandlen==0)	//send accn MMA8452Q
			 {
				I2S();I2send(0x38);I2send(0x00);I2SR();I2send(0x39);
		    	i=I2GET(0);I2P();
			    if (i&8)
					{
					POSTTCPhead(6,40);
					I2S();I2send(0x38);I2send(0x01);I2SR();I2send(0x39);
					for (i=1;i<=6;i++)
						{POSTTCPchar(I2GET(i!=6));
						}
				    I2P();
					}
					else POSTTCPhead(0,40);
			 } 
			break;
	case 41:  
			 if (commandlen==0)	//send ad MCP3425
			 {
			    POSTTCPhead(3,41);
					I2S();I2send(0xd1);
					for (i=1;i<=3;i++)
						{POSTTCPchar(I2GET(i!=3));
						}
				    I2P();
			 } 
			break;
	case 42:  
			 if (commandlen==0)	//send io MCP23008
			 {
			    POSTTCPhead(11,42);
					I2S();I2send(0x4e);I2send(0x00);I2SR();I2send(0x4f);
					for (i=1;i<=11;i++)
						{POSTTCPchar(I2GET(i!=11));
						}
				    I2P();
			 } 
			break;
	case 43:  
			 if (commandlen==0)	//send gyro L3G4200D
			 {
			    POSTTCPhead(8,43);
					I2S();I2send(0xd2);I2send(0x26);I2SR();I2send(0xd3);
					for (i=1;i<=8;i++)
						{POSTTCPchar(I2GET(i!=8));
						}
				    I2P();
			 } 
			break;
	case 44:  
			 if (commandlen==0)	//send mag HMC5883L
			 {
			    POSTTCPhead(1,44);
					I2S();I2send(0x3c);I2send(9);I2SR();I2send(0x3d);
					POSTTCPchar(I2GET(0));
				    I2P();
			 } 
			break;
	case 45:  
			 if (commandlen==0)	//send mag HMC5883L
			 {
			    POSTTCPhead(6,45);
					I2S();I2send(0x3c);I2send(3);I2SR();I2send(0x3d);
					for (i=1;i<=6;i++)
						{POSTTCPchar(I2GET(i!=6));
						}
				    I2P();
			 } 
			break;

	case 128:  //Drive amount of encoder steps
			 if (commandlen==3)	// move amount of encoder steps
			 {
			    drive_by_steps = 1; // activated
				wanted_encoder_steps = nextcommand[1] + (nextcommand[2] << 8);
				DIRECTION = (nextcommand[3] == 1)?1:-1;
				pos1 = 0x3FFF; //x7FFF;
				pos2 = 0x3FFF; //x7FFF;// for middle
				encoder_l_old = pos1;
				encoder_r_old = pos2;
			 } 
			break;
	case 129: //Send light and motor position
		if (commandlen==0)	//send light/aux
		{
			I2S();I2send(0xB8);I2send(10);I2SR();I2send(0xb9);
			POSTTCPhead(8,129);
			for (i=1;i<=4;i++)
			{
				POSTTCPchar(I2GET(i!=4));
			}
			I2P();

			POSTTCPchar(pos1);
			POSTTCPchar(pos1>>8);

			POSTTCPchar(pos2);
			POSTTCPchar(pos2>>8);
		} 
		break;
	case 130: //Send IR LINE data and motor position
		if (commandlen == 0)	
		{
			//if (nextcommand[1]& 1) LED2_IO=1; else LED2_IO=0;
			//if (nextcommand[1]& 2) LED3_IO=1; else LED3_IO=0;
			//mPORTEToggleBits(BIT_2);
			i = 0;
			POSTTCPhead(8, 130);
			//IR 
			i = LINEA; //(LINEAON - LINEAOFF);
			POSTTCPchar(i);
			POSTTCPchar(i>>8);
			i = LINEB; //(LINEBON - LINEBOFF);
			POSTTCPchar(i);
			POSTTCPchar(i>>8);

			//Motor position
			POSTTCPchar(pos1);
			POSTTCPchar(pos1>>8);

			POSTTCPchar(pos2);
			POSTTCPchar(pos2>>8);
		} 
		break;
	case 131:
	{
		POSTTCPhead(120, 131);
		for (i = 0; i < IR_DATA_BUFFER_SIZE; i++)
		{
			POSTTCPchar(IR_data_l[i]);
			POSTTCPchar(IR_data_l[i] >> 8);

			POSTTCPchar(IR_data_r[i]);
			POSTTCPchar(IR_data_r[i] >> 8);

			avrg_pos = IR_pos_l[i]/2 + IR_pos_r[i]/2;
			POSTTCPchar(avrg_pos);
			POSTTCPchar(avrg_pos >> 8);
		}
		break;
	}
	case 132:
	{
		if (commandlen == 1)
		{
			send_IR_update = nextcommand[1];
      current_pos = 0;
		}
		break;
	}
	case 133:
		//Read ACC data
		break;
	case 134:
		// ACC buffer read
		acc_cur_pos = 0;
		acc_data_aquire = 1;
		break;
	case 135:
		if (commandlen == 1)
		{
			pack = nextcommand[1];
			POSTTCPhead(ACC_BUFFER_PACKET_SIZE*2 + 1, 135);
			POSTTCPchar(pack);
			for (i = pack * ACC_BUFFER_PACKET_SIZE; i< (pack + 1)* ACC_BUFFER_PACKET_SIZE; i++)
			{
				POSTTCPchar(acc_data_z[i]);
				POSTTCPchar(acc_data_z[i] >> 8);
			}
		}	
		break;
	case 136:
		//Request MAG data acquire
		mag_acquire_data = 1;
		mag_data_pos = 0;
		break;
	case 137:
		//Send MAG X data packet
		if (commandlen == 1)
		{
			pack = nextcommand[1];
			POSTTCPhead(MAG_DATA_BUFFER_PER_AXIS * 2 + 1, 137);
			POSTTCPchar(pack);
			for (i = pack * MAG_DATA_BUFFER_PER_AXIS; i < (pack + 1)* MAG_DATA_BUFFER_PER_AXIS; i++)
			{
				POSTTCPchar(mag_data_x[i] >> 8); //
				POSTTCPchar(mag_data_x[i]);
			}	
		} // end of if commanlen
		break; // break of case
	case 138:
		// MAG Y data
		if (commandlen == 1)
		{
			pack = nextcommand[1];
			POSTTCPhead(MAG_DATA_BUFFER_PER_AXIS * 2 + 1, 138);
			POSTTCPchar(pack);
			for (i = pack * MAG_DATA_BUFFER_PER_AXIS; i < (pack + 1)* MAG_DATA_BUFFER_PER_AXIS; i++)
			{
				POSTTCPchar(mag_data_y[i] >> 8);
				POSTTCPchar(mag_data_y[i]);
			}
		}
		break;
	case 139:
		// MAG Z data
		if (commandlen == 1)
		{
			pack = nextcommand[1];
			POSTTCPhead(MAG_DATA_BUFFER_PER_AXIS * 2 + 1, 139);
			POSTTCPchar(pack);
			for (i = pack * MAG_DATA_BUFFER_PER_AXIS; i < (pack + 1)* MAG_DATA_BUFFER_PER_AXIS; i++)
			{
				POSTTCPchar(mag_data_z[i] >> 8);
				POSTTCPchar(mag_data_z[i]);
			}
		}
		break;
	case 200:
		// DRIVE_MAX_SPEED
		if (commandlen == 1)
		{
			DRIVE_MAX_SPEED = nextcommand[1];
			POSTTCPhead(1, 200);
			POSTTCPchar(DRIVE_MAX_SPEED);
		}
		break;
  }
}


//Process packets
void ProcessIO(void)
{
 unsigned int i = 0, j = 0;
 if (yescomsdata())
 {
  if (commandstate<0)
   {
     if ((unsigned char)getcomsdata()==0xff)
       {
         commandstate=0;
         if (yescomsdata())
			{
               commandstate=(unsigned char)getcomsdata();
			   commandlen=commandstate-1;
			   if (commandstate==0) commandstate=-1;
			}
	   }
   }
   else
   {
     if (commandstate==0)
		{
               commandstate=(unsigned char)getcomsdata();
			   commandlen=commandstate-1;
			   if (commandstate==0) commandstate=-1;
		}
		else
		{
			while (yescomsdata() && (commandstate))
				{
				  nextcommand[1+(commandlen-commandstate)]=getcomsdata();
				  commandstate--;
				}
			if (commandstate==0)
				{
					
					processcommand();
					commandstate=-1;
				}
		}
   }
	
 }

	//GENERAL SEND ACC DATA

	if (should_send_acc != 0)
	{
//In stead of saving data, send that it has been recorded!
		POSTTCPhead(1, 134);
		POSTTCPchar(1);
/*
		for (j = 0; j < ACC_PACKETS; j++)
		{ 
			POSTTCPhead(ACC_BUFFER_PACKET_SIZE * 2 + 1, 134);
			POSTTCPchar(j);
			for (i = 0; i < ACC_BUFFER_PACKET_SIZE; i++)
			{
				POSTTCPchar(acc_data_z[i + ACC_BUFFER_PACKET_SIZE * j]);
				POSTTCPchar(acc_data_z[i + ACC_BUFFER_PACKET_SIZE * j] >> 8);
			}
		}
*/
		should_send_acc = 0;
	}

	if (should_send_mag != 0)
	{
		POSTTCPhead(1, 136);
		POSTTCPchar(1);
		should_send_mag = 0;
	}

}


/****************************************************************************
  Function:
    static void InitializeBoard(void)

  Description:
    This routine initializes the hardware.  
  Precondition:
    None

  Parameters:
    None - None

  Returns:
    None

  Remarks:
    None
  ***************************************************************************/
void InitializeBoard(void)
{
    UINT32              actualClock;
	
  // init ports for analog  AN2 to AN3 are analog
AD1PCFG=0xfffffff3;
	IR_TRIS=1;IRstreamHead=IRstreamTail=0;
	lastIR=IR_IO;
	IC1_TRIS=1;
	IC2_TRIS=1;
	IC3_TRIS=1;
	IC4_TRIS=1;
TRISDbits.TRISD6=1;
TRISDbits.TRISD7=1;
	// LEDs
	LED0_TRIS = 0;
	LED1_TRIS = 0;

	LED2_TRIS = 0;	// used for line following
	LED3_TRIS = 0;

		// Enable multi-vectored interrupts
		INTEnableSystemMultiVectoredInt();
		
		// Enable optimal performance
		SYSTEMConfigPerformance(GetSystemClock());
		mOSCSetPBDIV(OSC_PB_DIV_1);				// Use 1:1 CPU Core:Peripheral clocks
		
		// Disable JTAG port so we get our I/O pins back, but first
		// wait 50ms so if you want to reprogram the part with 
		// JTAG, you'll still have a tiny window before JTAG goes away.
		// The PIC32 Starter Kit debuggers use JTAG and therefore must not 
		// disable JTAG.
		DelayMs(50);
		#if !defined(__MPLAB_DEBUGGER_PIC32MXSK) && !defined(__MPLAB_DEBUGGER_FS2)
			DDPCONbits.JTAGEN = 0;
		#endif
		

		T3CON=0;
		PR3=8333;
        T3CONbits.TON=1;
		    AD1CHS = 2;					

	// ADC
	AD1CON1 = 0x0444;			// Turn on, auto sample start, convert on t3, 
	AD1CON2 = 0x0406;			// AVdd, AVss, int every 2 conversions, MUXA only, scan
	AD1CON3 = 0x1003;			// 16 Tad auto-sample, Tad = 3*Tcy
		AD1CSSL = 0xc;				// Scan line following
	AD1CON1 = 0x8444;			// Turn on, auto sample start, convert on t3, 


// Deassert all chip select lines so there isn't any problem with 
// initialization order.  Ex: When ENC28J60 is on SPI2 with Explorer 16, 
// MAX3232 ROUT2 pin will drive RF12/U2CTS ENC28J60 CS line asserted, 
// preventing proper 25LC256 EEPROM operation.
#if defined(WF_CS_TRIS)
	WF_CS_IO = 1;
	WF_CS_TRIS = 0;
#endif




	LeftMotorF=0;
	LeftMotorF_TRIS=0;
	LeftMotorB=0;
	LeftMotorB_TRIS=0;
	RightMotorF=0;
	RightMotorF_TRIS=0;
	RightMotorB=0;
	RightMotorB_TRIS=0;
	OC3CON=0;OC4CON=0;OC3R=OC3RS=0;OC4R=OC4RS=0;
	OC2CON=0;OC5CON=0;OC2R=OC2RS=0;OC5R=OC5RS=0;
	T2CON=0x8040;
	PR2=127;
	IC1CON=0x0001;
	IC1CON=0x8001;
	IC2CON=0x0001;
	IC2CON=0x8001;
	IC3CON=0x0001;
	IC3CON=0x8001;
	IC4CON=0x0001;
	IC4CON=0x8001;
IFS0bits.IC1IF=0;
IFS0bits.IC3IF=0;

IPC1bits.IC1IS=0;
IPC1bits.IC1IP=4;
IPC3bits.IC3IS=0;
IPC3bits.IC3IP=4;
IEC0bits.IC1IE=1;
IEC0bits.IC3IE=1;

IFS1bits.AD1IF=0;
IPC6bits.AD1IS=0;
IPC6bits.AD1IP=3;
IEC1bits.AD1IE=1;


    actualClock = I2CSetFrequency(I2C1, GetPeripheralClock(), 50000);
    // Enable the I2C bus
    I2CEnable(I2C1, TRUE);

	//Initialize timer4
//PR4 = 999 ; // 1000 ticks foe each itnerrupt 
	PR4 = 2047;
	OpenTimer4(T4_ON | T4_SOURCE_INT | T4_PS_1_2, T4_TICK);
	ConfigIntTimer4(T4_INT_ON | T4_INT_PRIOR_2);
	INTEnableSystemMultiVectoredInt();
}

