

/************************ HEADERS **********************************/
#define myidcode 5

#include "P2P.h"
#include "MRF24J40.h"
#include "SymbolTime.h"
#include "I2C.h"
#include "ultra.h"
#include "hardwareprofile.h"
    
/************************ VARIABLES ********************************/


/*******************************************************************/
// The variable myChannel defines the channel that the P2P connection
// is operate on. This variable will be only effective if energy scan
// (ENABLE_ED_SCAN) is not turned on. Once the energy scan is turned
// on, the operating channel will be one of the channels available with
// least amount of energy (or noise).
/*******************************************************************/
#define chanA CHANNEL_15
BYTE myChannel = chanA;
int timetoconnect;
TICK CTick;    
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
char Broadcast;
unsigned int REQCOUNT=0;

void CheckP2P(void);
void processCMD(BYTE cmdid,BYTE dbytes);




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

     

void processCMD(BYTE cmdid,BYTE dbytes)
{
  int speed,tmp;
  int i;
  unsigned int workword;
						switch (cmdid)
						{
							case 0:BroadcastPacketAR[0]=0;
									Broadcast=1;  // number in packet
									break;
							case 1:BroadcastPacketAR[0]=1;
									workword=PORTB;workword=~(workword>>12) &3;
									workword |=((LATB>>6) & 0x30);
									BroadcastPacketAR[1]=workword & 0x33;
									Broadcast=2;  // number in packet
									break;
							case 2:if (dbytes==1)
									{
									  _LATB10=!(rxFrame.PayLoad[1] & 1);
									  if (rxFrame.PayLoad[1] & 2) _LATB11=0; else _LATB11=1;
									}
									break;
							case 3:BroadcastPacketAR[0]=3;  // get internal counter
									BroadcastPacketAR[1]=REQCOUNT & 0xff;
									BroadcastPacketAR[2]=(REQCOUNT>>8) & 0xff;REQCOUNT++;
									Broadcast=3;  // number in packet
									break;
							case 4:if (dbytes==1)	// set motor speed
									{
									  speed=(char)rxFrame.PayLoad[1];
									  if (speed>100) speed=100;
									  if (speed<-100) speed=-100;
									  I2S();I2send(0xb0);I2send(1);I2send(speed);I2P();
									}
									break;
							case 5:  // request motor status here via I2C
									 // on receive data send result via MiWi
									  I2S();I2send(0xb0);I2send(1);I2SR();I2send(0xb1);
									  BroadcastPacketAR[0]=5;
									  BroadcastPacketAR[1]=I2GET(1);tmp=I2GET(1);tmp=I2GET(1);
									  for (i=0;i<12;i++)
										{BroadcastPacketAR[i+2]=I2GET(i!=11);
										}
									  I2P();Broadcast=14;  // number in packet

									break;
							case 6:if (dbytes==1)	// set power
									{
										I2S();I2send(0xC0);I2send(0);I2send(rxFrame.PayLoad[1]);I2P();
									}
									break;
							case 7:if (dbytes==1)	// set servo pwm
									{
									  I2S();I2send(0xb0);I2send(7);I2send(rxFrame.PayLoad[1]);I2P();
									}
									break;
							case 8:  // request motor current here via I2C
									 // on receive data send result via MiWi
									  I2S();I2send(0xb0);I2send(3);I2SR();I2send(0xb1);
									  BroadcastPacketAR[0]=8;
									  BroadcastPacketAR[1]=I2GET(0);
									  I2P();Broadcast=2;  // number in packet
									break;
							case 9:  // request servo setup via I2C
									 // on receive data send result via MiWi
									  I2S();I2send(0xb0);I2send(16);I2SR();I2send(0xb1);
									  BroadcastPacketAR[0]=9;
									  for (i=0;i<8;i++)
										{BroadcastPacketAR[i+1]=I2GET(i!=7);
										}
									  I2P();Broadcast=9;  // number in packet
									break;
							case 10:  
									 if (dbytes==8)	// set servo setup via I2C
									 {
									 // on receive data send result via MiWi
									  I2S();I2send(0xb0);I2send(16);
									  for (i=0;i<8;i++)
										{I2send(rxFrame.PayLoad[i+1]);
										}
									  I2P();
									 } 
									break;
							case 11:  
									 if (dbytes==1)	// set REG sensor light and read
									 {
									 //light = (rxFrame.PayLoad[1]!=0);
									 // start sensor read
									  I2S();I2send(0xe8);I2send(0);I2send(1);	I2P();
									 } 
									break;
							case 12:  
									 if (dbytes==0)	//read RGB sensor
									 {BroadcastPacketAR[0]=12;
										I2S();I2send(0xe8);I2send(64);I2SR();I2send(0xe9);
										BroadcastPacketAR[1]=I2GET(1);BroadcastPacketAR[2]=I2GET(1);
										BroadcastPacketAR[3]=I2GET(1);BroadcastPacketAR[4]=I2GET(1);
										BroadcastPacketAR[5]=I2GET(1);BroadcastPacketAR[6]=I2GET(1);
										BroadcastPacketAR[7]=I2GET(1);BroadcastPacketAR[8]=I2GET(0);
										I2P();Broadcast=9; 
									 } 
									break;
							case 13:  
									 if (dbytes==12)	// send RGB values
									 {
										I2S();I2send(0xe8);I2send(6);
										for (i=1;i<=12;i++) I2send(rxFrame.PayLoad[i]);
										I2P();Broadcast=0; 
									 } 
									break;
							case 14:  
									 if (dbytes==0)	//read RGB sensor setups
									 {BroadcastPacketAR[0]=14;
										I2S();I2send(0xe8);I2send(6);I2SR();I2send(0xe9);
										BroadcastPacketAR[1]=I2GET(1);BroadcastPacketAR[2]=I2GET(1);
										BroadcastPacketAR[3]=I2GET(1);BroadcastPacketAR[4]=I2GET(1);
										BroadcastPacketAR[5]=I2GET(1);BroadcastPacketAR[6]=I2GET(1);
										BroadcastPacketAR[7]=I2GET(1);BroadcastPacketAR[8]=I2GET(1);
										BroadcastPacketAR[9]=I2GET(1);BroadcastPacketAR[10]=I2GET(1);
										BroadcastPacketAR[11]=I2GET(1);BroadcastPacketAR[12]=I2GET(0);
										I2P();Broadcast=13; 
									 } 
									break;
							case 15:  
									 if (dbytes==0)	//read RGB offsets and trim.
									 {BroadcastPacketAR[0]=0;Broadcast=0; 
									  I2S();I2send(0xe8);I2send(0);I2send(2);	I2P();
									  i=10000;
									  while (i>0) 
										{
											i--;
											I2S();I2send(0xe8);I2send(0);I2SR();I2send(0xe9);
											if (!(I2GET(0) & 2)) i=-1;
											I2P();
										}
										if (i<0)
											{
									  		I2S();I2send(0xe8);I2send(1);I2send(1);	I2P();
											}
									 } 
									break;
							case 16:  
									 if (dbytes==0)	//send ultrasonics
									 {BroadcastPacketAR[0]=16;
									  BroadcastPacketAR[1]=lastecho;
									  BroadcastPacketAR[2]=ultracount;
									  Broadcast=3; 
									 } 
									break;
						}
}

        

int main(void)

{   
	long int idel;
    /*******************************************************************/
    // Initialize the system
    /*******************************************************************/

	for (idel=0;idel<0x7ffff;idel++);
    BoardInit(); 
	initultra();   
	PHY_RESETn = 1;
	for (idel=0;idel<0x7fff;idel++);
    PHY_RESETn = 0;
	for (idel=0;idel<0x7fff;idel++);
	PHY_RESETn = 1;

	setupP2P();
   

running=0;
	waketime=lasttransactiontime=txtime=TickGet();uctry=0;
	timetoconnect=0;
    lasttag=0;
	BroadcastPacketPoint=0;instate=0;
	SlaveID=0;Broadcast=0;
	BroadcastPacketAR[0]=0;Broadcast=1;

    while(1)
    {
		CTick = TickGet();
		CheckP2P();
    }
}

