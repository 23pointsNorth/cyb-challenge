#include "p24HJ64gp506.h"


void initi2c(void)
{
I2C1CON=0x2000;
I2C1BRG=80;
I2C1CON=0xa000;
}

void I2S(void)
{
  I2C1CON=I2C1CON & 0xffe0;
 I2C1CONbits.SEN=1;
 while (I2C1CONbits.SEN);
}

void I2SR(void)
{
  I2C1CON=I2C1CON & 0xffe0;
 I2C1CONbits.RSEN=1;
 while (I2C1CONbits.RSEN);
}

void I2send(int v)
{
  int i;
  _MI2C1IF=0;
  I2C1TRN=v;
  i=10000;
  while ((i) && (I2C1STATbits.TRSTAT)) i--; /* wait till transmitted*/
  i=10000;
  while ((i) && (!_MI2C1IF)) i--; /* wait till transmitted*/
  _MI2C1IF=0;	
}

int I2GET(int ack)
{
  int readval;
  I2C1CON=I2C1CON & 0xffe0;
//  readval=I2CRCV;
  I2C1CONbits.RCEN=1;
  while (I2C1CONbits.RCEN);
//  readval=I2CRCV;
  if (!ack) 
	{I2C1CONbits.ACKDT=1;}
	 else 
	{I2C1CONbits.ACKDT=0;}
  I2C1CONbits.ACKEN=1;
  while (I2C1CONbits.ACKEN);
  readval=I2C1RCV;
  I2C1CON=I2C1CON & 0xffe0;
 return(readval);
}

void I2P(void)
{
  I2C1CON=I2C1CON & 0xffe0;
 I2C1CONbits.PEN=1;
 while (I2C1CONbits.PEN);
}


