/************************ HEADERS **********************************/
// myidcode MUST BE set to match your dongle/processor bundle, as it is written on the bottom of both
#define myidcode 0
#define track 1
#if myidcode==0
    #error Set the myidcode to the number written on the processor board and dongle 
#endif

//Initial channel is based on  myidcode - This may be altered temporarily in code by calling SetChannel( CHANNEL_XY);   Where  11 <= XY <= 26
// 	after which you MUST make sure you switch back to your own dongle's channel or your robot WILL BE LOST.
// 
//  You MUST ENSURE that this channel is NOT the same as ANYONE ELSE'S - or we WILL disqualify you
//	Hence the following declaration ensures it is unique - based on your ID Code.
#define chanA (CHANNEL_11 + (myidcode-1)*16)

//Necessary files to get things off the ground - Do Not Touch
#include "P2P.h"
#include "MRF24J40.h"
#include "SymbolTime.h"
#include "I2C.h"
#include "hardwareprofile.h"
    
/************************ VARIABLES ********************************/
//These are variables used throughout the code, please do not alter!
// You can include additional variables here to deal with anything you may want to.
BYTE myChannel = chanA;
int timetoconnect;
TICK CTick;    
TICK timeout;
char switchedfreq;    
int uctry;
int myconectionid;
char running;

#include "typeDef.h"

int lasttag;
TICK txtime;

TICK waketime;
TICK lasttransactiontime;

BYTE BroadcastPacketAR[256];

int BroadcastPacketPoint,instate;
BYTE waveid;
char Broadcast,BroadcastPend;
unsigned int REQCOUNT=0;

void CheckP2P(void);
void processCMD(BYTE cmdid,BYTE dbytes);

char speed1,speed2,speed3;
volatile int pos1,pos2,pos3;
volatile char lastTVopto1B;
volatile char lastTVopto1C;
volatile char lastTVopto2B;
volatile char lastTVopto2C;

volatile int T3count;
char IRFLASH;


extern int adDMAbuf[32] __attribute__((space(dma),aligned(32)));

#define TVopto1B _RG15
#define TVopto1C _RC14
#define TVopto2B _RC13
#define TVopto2C _RC15

void initvars(void)
{
	speed1=speed2=speed3=0;
	pos1=pos2=pos3=0;
	lastTVopto1B=TVopto1B;
	lastTVopto1C=TVopto1C;
	lastTVopto2B=TVopto2B;
	lastTVopto2C=TVopto2C;

}

void __attribute__((interrupt,auto_psv))  _T3Interrupt(void)
{
if (IRFLASH)  _RG13=!_RG13;
 if (!(T3count--))
	{_T3IE=0;_RG13=0;
	};
 _T3IF=0;
}


void __attribute__((interrupt,auto_psv))  _DMA3Interrupt(void)
{
	 char workTVopto1B;
	char workTVopto1C;
	char workTVopto2B;
	char workTVopto2C;
	workTVopto1B=TVopto1B;
	workTVopto1C=TVopto1C;
	workTVopto2B=TVopto2B;
	workTVopto2C=TVopto2C;
  if (lastTVopto1B!=workTVopto1B)
	{
  		if (workTVopto1B)
			{
			  if (speed1>0) pos1++;
				else
                {
				if (speed1==0) 
				  {
					if (workTVopto1C)	pos1++; else pos1--;
				  }
				}
			}
			else
			{
			  if (speed1<0) pos1--;
			}
	}
  if (lastTVopto2B!=workTVopto2B)
	{
  		if (workTVopto2B)
			{
			  if (speed2>0) pos2++;
				else
                {
				if (speed2==0) 
				  {
					if (!workTVopto2C)	pos2++; else pos2--;
				  }
				}
			}
			else
			{
			  if (speed2<0) pos2--;
			}
	}
	lastTVopto1B=workTVopto1B;
	lastTVopto1C=workTVopto1C;
	lastTVopto2B=workTVopto2B;
	lastTVopto2C=workTVopto2C;

_DMA3IF=0;
}


//MiWi function - do not alter
void setupP2P(void)
{
	   InitSymbolTimer();
    P2PInit();   
    #if defined(PICDEMZ)
        INTCONbits.GIEH = 1;
    #elif defined(EXPLORER16)
    #else
    #endif
	running=0;
    SetChannel(myChannel);
    
    
    /*******************************************************************/
    // Function EnableNewConnection will enable the device to accept
    // request to establish P2P connection from other devices. If a
    // P2P connection has been established, user can choose to call
    // function DisableNewConnection() to reject further request to 
    // establish P2P connection, if it is desired for the application
    /*******************************************************************/
    EnableNewConnection();
    

 }

 //MiWi function - do not alter
void CheckP2P(void)
{
    BYTE i;
		 
        /*******************************************************************/
        // Function ReceivedPacket will return a boolean to indicate if a 
        // packet has been received by the transceiver. If a packet has been
        // received, all information will be stored in the rxFrame, structure  
        // of RECEIVED_FRAME.
        /*******************************************************************/
        if( ReceivedPacket() )
        {lasttransactiontime=TickGet();
            /*******************************************************************/
            // If a packet has been received, following code prints out some of
            // the information available in rxFrame.
            /*******************************************************************/
			if (rxFrame.SourceLongAddress[4]==myidcode)
			{
				if (rxFrame.PayLoadSize>0)
					{ 
						processCMD(rxFrame.PayLoad[0],rxFrame.PayLoadSize-1);
					}
			}
			if (rxFrame.SourceLongAddress[4]==250)  //packet from rocket or hidden TX
			{
				if (rxFrame.PayLoadSize>0)
					{ 
						for (i=0;i<rxFrame.PayLoadSize;i++)
								{
									BroadcastPacketAR[0]=rxFrame.PacketRSSI;
									BroadcastPacketAR[i+1]=rxFrame.PayLoad[i]; // fill frame - also add RSSI
								}
						BroadcastPend=rxFrame.PayLoadSize+1;
					}
			}
            /*******************************************************************/
            // Function DiscardPacket is used to release the current received packet.
            // After calling this function, the stack can start to process the
            // next received frame 
            /*******************************************************************/
            DiscardPacket();
        }
        else
        {
            /*******************************************************************/
            // Macro isDataRequesting returns the boolean to indicate if
            // the Data Request command has received any feedback from its 
            // associated device. If there won't be any message from the associate
            // device to the device with radio off during idle, the RFD device
            // will not required to send out Data Request command, thus the return
            // value of macro isDataRequesting is always FALSE
            /*******************************************************************/
            if( isDataRequesting() == FALSE )
            {
  				if (Broadcast)
				{    
                        FlushTx();
							SlaveID=myidcode;
							for (i=0;i<Broadcast;i++)
								{
									WriteData(BroadcastPacketAR[i]);
								}
				            BroadcastPacket(myPANID, FALSE, FALSE);
							Broadcast=0;
						txtime=TickGet();
                }
                
                #ifdef ENABLE_FREQUENCY_AGILITY
                    /***********************************************************************
                    * AckFailureTimes is the global variable to track the transmission 
                    * failure because no acknowledgement frame is received. Typically,
                    * this is the indication of either very strong noise, or the PAN
                    * has hopped to another channel. Here we call function ResyncConnection
                    * to resynchronize the connection.
                    *   The first parameter is the destination long address of the peer node
                    *   that we would like to resynchronize to.
                    *   The second parameter is the bit map of channels to be scanned
                    *************************************************************************/
                    if( AckFailureTimes > ACK_FAILURE_TIMES )
                    {
                        ResyncConnection(P2PConnections[0].PeerLongAddress, 0x07FFF800);    
                    }
                
                #endif
                
            }   // end of data requesting
	}
}

     
void initi2Cs(void)
{
	//setup accn MMA8452Q
										I2S();I2send(0x38);I2send(0x2a);I2send(0x20);/*50Hz nonactive */ I2send(0x2);I2P();
										I2S();I2send(0x38);I2send(0x2a);I2send(0x21);/*50Hz active */ /*I2send(0x2);*/I2P();
	//setup ad MCP3425
										I2S();I2send(0xd0);I2send(0x90);I2P();
	//setup io MCP23008  // to be done
//										I2S();I2send(0x4e);I2send(0x90);I2P();
	//setup gyro L3G4200D  // to be done
//										I2S();I2send(0xd2);I2send(0x90);I2P();
//setup mag HMC5883L
										I2S();I2send(0x3c);I2send(0x0);I2send(0x70);I2send(0x20);I2send(0x00);I2P();
}


/* This is the function which is called every time a new packet is received from MiWi
*
* This is where new packet types may be implemented. Please be careful with timing, if you take too long to process a packet
*  it may render your system unresponsive.  Talk to a demonstrator to find out how you may get around such issues.
*
*	BroadcastPacketAR[n] : TX Packet contents, where  n=0 is TypeID and n>0 is Payload
*	Broadcast : is a byte value representative of the largest n in this TX Packet (this initiates the sending of the packet)
*
*  An example of unresponsive processing is the I2C routines when no or faulty I2C bus is present. This is not a problem as
*    you will only be calling Ultrasonics Packets when you do have one attached...  Please refer to the datasheet of this PIC
*    for further description of the I2C protocol.
*
*/
void processCMD(BYTE cmdid,BYTE dbytes)
{
  int tmp;
  int i;
  unsigned int workword;
						switch (cmdid)
						{
							case 0:BroadcastPacketAR[0]=0;   //Ask for Null Echo
									Broadcast=1;  // number in packet
									break;
							case 1:BroadcastPacketAR[0]=1;    //Ask for Led and Switch status Packet
									workword=PORTB;workword=~(workword>>12) &3;
									workword |=((LATB>>6) & 0x30);
									BroadcastPacketAR[1]=workword & 0x33;
									Broadcast=2;  // number in packet
									break;
							case 2:if (dbytes==1)		//Set LEDs
									{
									  _LATB10=!(rxFrame.PayLoad[1] & 1);
									  if (rxFrame.PayLoad[1] & 2) _LATB11=0; else _LATB11=1;
									  BroadcastPacketAR[0]=2;Broadcast=1;  // number in packet
									}
									break;
							case 3:BroadcastPacketAR[0]=3;  // get internal counter
									BroadcastPacketAR[1]=REQCOUNT & 0xff;
									BroadcastPacketAR[2]=(REQCOUNT>>8) & 0xff;REQCOUNT++;
									Broadcast=3;  // number in packet
									break;
							case 4:  // request motor status here 
									 // on receive data send result via MiWi
									  BroadcastPacketAR[0]=4;
									  BroadcastPacketAR[1]=speed1;
									  BroadcastPacketAR[2]=pos1;
									  BroadcastPacketAR[3]=pos1>>8;

									  BroadcastPacketAR[4]=speed2;
									  BroadcastPacketAR[5]=pos2;
									  BroadcastPacketAR[6]=pos2>>8;

									  BroadcastPacketAR[7]=speed3;
									  BroadcastPacketAR[8]=pos3;
									  BroadcastPacketAR[9]=pos3>>8;

									  Broadcast=10;  // number in packet

									break;
#if track==1
							case 5:if (dbytes==1)	// set motor1
									{
									  speed1=(char)rxFrame.PayLoad[1];
									  if (speed1==0) {LATD&=~0x003;OC2CON=0;OC1CON=0;OC2R=OC2RS=0;OC1R=OC1RS=0;}
									  if (speed1<0) 
										{	
											OC2CON=0;OC2R=OC2RS=0;
											OC1RS=abs(speed1)/* *16*/;
											if (!OC1CON) OC1CON=6;											 
//											LATD|=0x0010;
										}
									  if (speed1>0) 
										{
											OC1CON=0;OC1R=OC1RS=0;
											OC2RS=abs(speed1)/* *16*/;
											if (!OC2CON) OC2CON=6;											 
//											LATD|=0x0002;
										}
									  BroadcastPacketAR[0]=5;Broadcast=1;  // number in packet
									}
									break;
#else
							case 5:if (dbytes==1)	// set motor1
									{
									  speed1=(char)rxFrame.PayLoad[1];
									  if (speed1==0) {LATD&=~0x0012;OC2CON=0;OC5CON=0;OC2R=OC2RS=0;OC5R=OC5RS=0;}
									  if (speed1<0) 
										{	
											OC2CON=0;OC2R=OC2RS=0;
											OC5RS=abs(speed1)/* *16*/;
											if (!OC5CON) OC5CON=6;											 
//											LATD|=0x0010;
										}
									  if (speed1>0) 
										{
											OC5CON=0;OC5R=OC5RS=0;
											OC2RS=abs(speed1)/* *16*/;
											if (!OC2CON) OC2CON=6;											 
//											LATD|=0x0002;
										}
									  BroadcastPacketAR[0]=5;Broadcast=1;  // number in packet
									}
									break;
#endif
							case 6:if (dbytes==1)	// set motor2
									{
									  speed2=(char)rxFrame.PayLoad[1];
									  if (speed2==0) {LATD&=~0x000C;OC3CON=0;OC4CON=0;OC3R=OC3RS=0;OC4R=OC4RS=0;}
									
									  if (speed2<0) 
											{
												OC4CON=0;OC4R=OC4RS=0;
												OC3RS=abs(speed2)/* *16*/;
												if (!OC3CON) OC3CON=6;											 
//												LATD|=0x0004;
											}
									  if (speed2>0) 
											{
												OC3CON=0;OC3R=OC3RS=0;
												OC4RS=abs(speed2)/* *16*/;
												if (!OC4CON) OC4CON=6;											 
//												LATD|=0x0008;
											}
									  BroadcastPacketAR[0]=6;Broadcast=1;  // number in packet
									}
									break;
#if track==0
							case 7:if (dbytes==1)	// set motor3
									{
									  speed3=(char)rxFrame.PayLoad[1];
									  if (speed3==0) {LATD&=~0x0021;}
									  if (speed3<0) 
											{
											 
												LATD|=0x0001;
												lastdir3=1;
											}
									  if (speed3>0) 
											{										 
												LATD|=0x0020;
												lastdir3=-1;
											}
									  BroadcastPacketAR[0]=7;Broadcast=1;  // number in packet
									}
									break;
#endif
							case 8:  
									 if (dbytes==0)	//send bump
									 {
									  BroadcastPacketAR[0]=8;
									  BroadcastPacketAR[1]=0;
									  if (_RG14) BroadcastPacketAR[1]|=1;
									  if (_RG12) BroadcastPacketAR[1]|=2;
									  if (_RG0) BroadcastPacketAR[1]|=4;
									  if (_RG1) BroadcastPacketAR[1]|=8;
									  if (_RD9) BroadcastPacketAR[1]|=16;
									  if (_RD10) BroadcastPacketAR[1]|=32;
									  Broadcast=2;  // number in packet
									 } 
									break;
							case 9:  
									 if (dbytes==0)	//send ad
									 {
									  BroadcastPacketAR[0]=9;
									  for (i=1;i<=7;i++)
										{BroadcastPacketAR[((i-1)*2)+1]=adDMAbuf[(i-1)];
										 BroadcastPacketAR[((i-1)*2)+2]=adDMAbuf[(i-1)]>>8;
										}
									  for (i=9;i<=10;i++)
										{BroadcastPacketAR[((i-2)*2)+1]=adDMAbuf[(i-1)];
										 BroadcastPacketAR[((i-2)*2)+2]=adDMAbuf[(i-1)]>>8;
										}
									  for (i=15;i<=15;i++)
										{BroadcastPacketAR[((i-6)*2)+1]=adDMAbuf[(i-1)];
										 BroadcastPacketAR[((i-6)*2)+2]=adDMAbuf[(i-1)]>>8;
										}
									  Broadcast=21;  // number in packet
									 } 
									break;
							case 10:  
									 if (dbytes==1)	//request utrasonic wave
									 {
									  I2S();I2send(0xB8);I2send(128);I2send(rxFrame.PayLoad[1]);
									  I2P();
									  BroadcastPacketAR[0]=10;Broadcast=1;  // number in packet
									 } 
									break;
							case 11:  
									 if (dbytes==0)	//request utrasonic wave status
									 {
									  I2S();I2send(0xB8);I2send(128);
									  I2SR();I2send(0xb9);BroadcastPacketAR[0]=11;
									  BroadcastPacketAR[1]=I2GET(0);
									  I2P();Broadcast=2;
									 } 
									waveid=0;
									break;
							case 12:  
									 if (dbytes==0)	//send ultrasonics wave section
									 {
									  I2S();I2send(0xB8);I2send(129);I2SR();I2send(0xb9);
									  BroadcastPacketAR[0]=12;
									  BroadcastPacketAR[1]=waveid++;
									  for (i=1;i<=85;i++)
										{BroadcastPacketAR[i+1]=I2GET(i!=85);
										}
									  I2P();Broadcast=87;  // number in packet
									 } 
									break;
							case 13:  
									 if (dbytes==1)	//send ultrasonics trim
									 {
  									  if ((rxFrame.PayLoad[1]>90) && (rxFrame.PayLoad[1]<rxFrame.PayLoad[1]<110))
										{
									      I2S();I2send(0xB8);I2send(8);I2send(rxFrame.PayLoad[1]);
									      I2P();
									  	  BroadcastPacketAR[0]=13;Broadcast=1;  // number in packet
										}
									 } 
									break;
							case 16:  
									 if (dbytes==0)	//send ultrasonics
									 {
									  I2S();I2send(0xB8);I2send(0);I2SR();I2send(0xb9);
									  BroadcastPacketAR[0]=16;
									  for (i=1;i<=8;i++)
										{BroadcastPacketAR[i]=I2GET(i!=8);
										}
									  I2P();Broadcast=9;  // number in packet
									 } 
									break;
							case 17:  
									 if (dbytes==0)	//send light
									 {
									  I2S();I2send(0xB8);I2send(10);I2SR();I2send(0xb9);
									  BroadcastPacketAR[0]=17;
									  for (i=1;i<=4;i++)
										{BroadcastPacketAR[i]=I2GET(i!=4);
										}
									  I2P();Broadcast=5;  // number in packet
									 } 
									break;
							case 40:  
									 if (dbytes==0)	//send accn MMA8452Q
									 {
									    BroadcastPacketAR[0]=40;
										I2S();I2send(0x38);I2send(0x00);I2SR();I2send(0x39);
								    	i=I2GET(0);I2P();
									    if (i&8)
											{
											I2S();I2send(0x38);I2send(0x01);I2SR();I2send(0x39);
											for (i=1;i<=6;i++)
												{BroadcastPacketAR[i]=I2GET(i!=6);
												}
										    I2P();Broadcast=7;  // number in packet
											}
											else Broadcast=1;
									 } 
									break;
							case 41:  
									 if (dbytes==0)	//send ad MCP3425
									 {
									    BroadcastPacketAR[0]=41;
											I2S();I2send(0xd1);
											for (i=1;i<=3;i++)
												{BroadcastPacketAR[i]=I2GET(i!=3);
												}
										    I2P();Broadcast=4;  // number in packet
									 } 
									break;
							case 42:  
									 if (dbytes==0)	//send io MCP23008
									 {
									    BroadcastPacketAR[0]=42;
											I2S();I2send(0x4e);I2send(0x00);I2SR();I2send(0x4f);
											for (i=1;i<=11;i++)
												{BroadcastPacketAR[i]=I2GET(i!=11);
												}
										    I2P();Broadcast=12;  // number in packet
									 } 
									break;
							case 43:  
									 if (dbytes==0)	//send gyro L3G4200D
									 {
									    BroadcastPacketAR[0]=43;
											I2S();I2send(0xd2);I2send(0x26);I2SR();I2send(0xd3);
											for (i=1;i<=8;i++)
												{BroadcastPacketAR[i]=I2GET(i!=8);
												}
										    I2P();Broadcast=9;  // number in packet
									 } 
									break;
							case 44:  
									 if (dbytes==0)	//send mag HMC5883L
									 {
									    BroadcastPacketAR[0]=44;
											I2S();I2send(0x3c);I2send(9);I2SR();I2send(0x3d);
											BroadcastPacketAR[1]=I2GET(0);I2P();
										    I2P();Broadcast=2;  // number in packet
									 } 
									break;
							case 45:  
									 if (dbytes==0)	//send mag HMC5883L
									 {
									    BroadcastPacketAR[0]=45;
											I2S();I2send(0x3c);I2send(3);I2SR();I2send(0x3d);
											for (i=1;i<=6;i++)
												{BroadcastPacketAR[i]=I2GET(i!=6);
												}
										    I2P();Broadcast=7;  // number in packet
									 } 
									break;
							case 32: // IR 
									 if (dbytes!=0)	
									 {
									 IRFLASH=1;
									 _T3IP=6;
									 PR3=47;
									 T3CON=0x8000;
  									 for (i=1;i<=dbytes;i++)
										{
										T3count=rxFrame.PayLoad[i];
									  	_T3IE=1;
									  	while (_T3IE);
										IRFLASH=!IRFLASH;
									    } 	
									 T3CON=0x0000;
									  BroadcastPacketAR[0]=32;

									  Broadcast=1;
									 } 
									break;
							case 33: // rocket 
									 if (dbytes==0)	
									 {
									 switchedfreq=1;		// say we have switched
									 timeout=CTick;			// remember when
									 BroadcastPend=0;
									 SetChannel(CHANNEL_24);	// change channel

									 } 
									break;
							case 34: // hidden 
									 if (dbytes==0)	
									 {
									 switchedfreq=1;
									 timeout=CTick;
									 BroadcastPend=0;
									 SetChannel(CHANNEL_25);

									 } 
									break;
						}
}

        

/* Main function - Do Not Alter, this takes care of initialising and running the correct processes.
    The while loop may contain other, cooperative function calls which end in a short space of time, such as
	finite state machines to deal with additional tasks you may choose to attempt solving.
    Please talk to a demonstrator about this as if you get this wrong or interfere with some hardware that is
	already initialised, you can render your robot unresponsive or even worse, might fail to move altogether.
*/
int main(void)

{   
	long int idel;
    /*******************************************************************/
    // Initialize the system
    /*******************************************************************/

	for (idel=0;idel<0x7ffff;idel++);
    BoardInit(); 
	PHY_RESETn = 1;
	for (idel=0;idel<0x7fff;idel++);
    PHY_RESETn = 0;
	for (idel=0;idel<0x7fff;idel++);
	PHY_RESETn = 1;

    initvars();
	setupP2P();
initi2Cs();
running=0;
	waketime=lasttransactiontime=txtime=TickGet();uctry=0;
	timetoconnect=0;
    lasttag=0;
	BroadcastPacketPoint=0;instate=0;
	SlaveID=0;BroadcastPend=Broadcast=0;
	BroadcastPacketAR[0]=0;Broadcast=1;
_DMA3IF=0;
_DMA3IE=1;
switchedfreq=0;

    while(1)
    {
		CTick = TickGet();
		
 		if( switchedfreq )	// handle freq switch timeout and reply 			if (( TickGetDiff(CTick, timeout) > (ONE_SECOND*6) )|| (BroadcastPend))				{
				     switchedfreq=0;
					if (BroadcastPend) {Broadcast=BroadcastPend;BroadcastPend=0;}
						else
						{		BroadcastPacketAR[0]=33;Broadcast=1;
						}
					SetChannel(myChannel);
				}

		CheckP2P();
    }
}

