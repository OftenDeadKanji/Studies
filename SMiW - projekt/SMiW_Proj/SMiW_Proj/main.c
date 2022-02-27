/*
* SMiW_Proj.c
*
* Created: 7 gru 2019 23:09:14
* Author : Mateusz Ch³opek
*/

#define F_CPU 1000000UL

/*
#define bit_get(p,m) ((p) & (m))
#define bit_set(p,m) ((p) |= (m))
#define bit_clear(p,m) ((p) &= ~(m))
#define bit_flip(p,m) ((p) ^= (m))
#define bit_write(c,p,m) (c ? bit_set(p,m) : bit_clear(p,m))
#define BIT(x) (0x01 << (x))
#define LONGBIT(x) ((unsigned long)0x00000001 << (x))*/

//poni¿sze define wykorzystywane s¹ do wyœwietlacza LCD
#define D0 eS_PORTD0
#define D1 eS_PORTD1
#define D2 eS_PORTD2
#define D3 eS_PORTD3
#define D4 eS_PORTD4
#define D5 eS_PORTD5
#define D6 eS_PORTD6
#define D7 eS_PORTD7
#define RS eS_PORTC3
#define EN eS_PORTC4

#include <avr/io.h>
#include <stdio.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include "lcd.h"

volatile int tot_overflow1 = 0;
volatile int tot_overflow2 = 0;
volatile int czasTrwania = 0;

ISR(TIMER1_OVF_vect)
{
	tot_overflow1++;
	tot_overflow2++;
	czasTrwania++;
}

void eeprom_zapis(unsigned int adres, unsigned char dane);
unsigned char eeprom_odczyt(unsigned int adres);

void timer1_init();
void IOinit();
void ADCInit();

void wypiszAktualnyNaLCD(int aktualny);
void wypiszGranicznyNaLCD(int graniczny);
void wypiszMeasureInfo();

uint16_t pomiarADC(uint8_t kanal);

int main()
{
	int measureState = 0;
	int newMeasure = 0;
	int measureAlert = 0;
	
	int LCDstate = 0;

	int clicked = 0;
	
	uint16_t wynikADC = 0;
	
	//eeprom
	unsigned char dolny;
	unsigned char gorny;
	if(eeprom_odczyt(0x00) == 0x00) //odczytanie trybu - któr¹ wartoœæ z eeprom pobraæ
	{
		//zapisana sta³a
		dolny = eeprom_odczyt(0x01); 
		gorny = eeprom_odczyt(0x02);
		measureAlert = gorny * 255 + dolny;
	} 
	else if (eeprom_odczyt(0x00) == 0x01)
	{
		//ostatnio dokonany w³asny pomiar
		dolny = eeprom_odczyt(0x03);
		gorny = eeprom_odczyt(0x04);
		measureAlert = gorny * 255 + dolny;
	}
	else
	{
		eeprom_zapis(0x01, 0xDD);
		eeprom_zapis(0x02, 0x00);
		eeprom_zapis(0x00, 0x00);
		
		dolny = 0xDD;
		gorny = 0x00;
		measureAlert = gorny * 255 + dolny;
	}
	
	timer1_init();
	_delay_ms(10);
	IOinit();
	_delay_ms(10);
	Lcd8_Init();
	_delay_ms(10);
	ADCInit();
	_delay_ms(10);
	

	
	while(1)
	{
		//sprawdzenie przycisku MEASURE
		
		if(!(PINC & (1 << PINC1)) && clicked == 0){
			czasTrwania = 0;
			clicked = 1;
		}
		if((PINC & (1 << PINC1)) && clicked == 1)
		{
			if(czasTrwania >= 50) // > 3 sekundy
			{
				cli();
				eeprom_zapis(0x00, 0x00);
				dolny = eeprom_odczyt(0x01);
				gorny = eeprom_odczyt(0x02);
				measureAlert = gorny * 255 + dolny;
				sei();
				measureState = 0;
			}
			else
			{
				if(measureState == 0) {
					measureState = 1;
				}
				else if(measureState == 1) {
					measureState = -1;
				}
			}
			
			clicked = 0;
		}
		
		//sprawdzanie stanu funkcji MEASURE
		if(measureState == 1)
		{
			wynikADC = pomiarADC(0);
			newMeasure = (newMeasure + wynikADC) / 2;
		} 
		else if(measureState == -1)
		{
			measureAlert = newMeasure * 1.3;
			measureState = 0;
			newMeasure = 0;
			cli();
			gorny = measureAlert / 256;
			dolny = measureAlert - gorny * 256;
			eeprom_zapis(0x00, 0x01);
			eeprom_zapis(0x03, dolny);
			eeprom_zapis(0x04, gorny);
			sei();
		}
		
		//pomiar z ADC
		wynikADC = pomiarADC(0);
		
		//migaj diod¹ jeœli trzeba
		if(tot_overflow1 >= 8){
			if(wynikADC >= measureAlert)
				PORTC ^= (1 << PINC2);
			else
				PORTC |= (1 << PINC2);
			tot_overflow1 = 0;
		}
		
		//wypisanie info na LCD
		if(tot_overflow2 >= 16) {
			if(LCDstate == 0 && tot_overflow2 >= 30 && tot_overflow2 <= 60){
				wypiszAktualnyNaLCD(wynikADC);
				LCDstate = 1;
			}
			if(LCDstate == 1 && tot_overflow2 > 60 && tot_overflow2 <= 90){
				wypiszGranicznyNaLCD(measureAlert);
				LCDstate = 2;
			}
			if(LCDstate == 2 && measureState == 0 && tot_overflow2 > 90){
				tot_overflow2 = 0;
				LCDstate = 0;
			}
			if(LCDstate == 2 && measureState != 0 && tot_overflow2 > 90) {
				wypiszMeasureInfo();
				tot_overflow2 = 0;
				LCDstate = 0;
			}
			
		}
		
	}
}

void eeprom_zapis(unsigned int adres, unsigned char dane)
{
	while(EECR & (1<< EEPE)); //czekanie na zakoñczenie wczeœniejszego zapisu
	
	EECR = (0 << EEPM1) | (0<<EEPM0); //tryb erase and write
	
	EEAR = adres;
	EEDR = dane;
	
	EECR |= (1<<EEMPE);
	
	EECR |= (1<<EEPE);
	
	_delay_ms(10);
}

unsigned char eeprom_odczyt(unsigned int adres)
{
	while(EECR & (1<<EEPE));
	
	EEAR = adres;
	
	EECR |= (1<<EERE);
	
	return EEDR;
}

void timer1_init()
{
	TCCR1B |= (1 << CS00); //prescaler = 1
	TCNT1 = 0;
	TIMSK1 |= (1 << TOIE1);
	tot_overflow1 = 0;
	tot_overflow2 = 0;
	sei();
	
}

void IOinit()
{
	//konfiguracja Portu C
	
	DDRC &= ~(1 << PINC0); //0 input MQ-9
	PORTC |= 1 << PINC0;

	DDRC &= ~(1 << PINC1); //1 input MEASURE
	PORTC |= 1 << PINC1;

	DDRC |= 1 << PINC2; //2 output LED
	PORTC |= 1 << PINC2; //zgaszenie diody (wstawienie 1)
	
	DDRC |= 1 << PINC3; //3 output LCD_RS
	
	DDRC |= 1 << PINC4; //4 output LCD_E
	
	//konfiguracja Portu D
	
	DDRD = 0xFF; // output LCD D0...D7
}

void ADCInit()
{
	ADCSRA |= (1 << ADEN); //w³¹czenie ADC
	ADCSRA |= (1 << ADPS2); //preskaler /16
	ADMUX |= (1 << REFS0); //napiêcie odniesienia 5V
}

void wypiszAktualnyNaLCD(int aktualny)
{
	//wyliczanie PPM
	int akt_stez = 1.121 * aktualny -146.94;
	if (akt_stez < 0)
	akt_stez = 0;
	char str[16] = "";
	
	//wypisanie aktualnego
	snprintf(str, sizeof(str), "%d", akt_stez);
	Lcd8_Clear();
	Lcd8_Set_Cursor(1, 0);
	Lcd8_Write_String("Aktualnie [PPM]");
	Lcd8_Set_Cursor(2, 0);
	Lcd8_Write_String(str);
	
}

void wypiszGranicznyNaLCD(int graniczny)
{
	//wyliczanie PPM
	int alert_stez = 1.121 * graniczny -146.94;
	if(graniczny < 0)
	graniczny = 0;
	char str[16] = "";
	
	//wypisanie granicznego
	snprintf(str, sizeof(str), "%d", alert_stez);
	Lcd8_Clear();
	Lcd8_Set_Cursor(1, 0);
	Lcd8_Write_String("Graniczne [PPM]");
	Lcd8_Set_Cursor(2, 0);
	Lcd8_Write_String(str);
	
}

void wypiszMeasureInfo()
{
	//wypisanie informacji o wyliczaniu nowego
	Lcd8_Clear();
	Lcd8_Set_Cursor(1, 0);
	Lcd8_Write_String("Nowa wartosc");
	Lcd8_Set_Cursor(2, 0);
	Lcd8_Write_String("jest wyliczana.");
}

uint16_t pomiarADC(uint8_t kanal)
{
	ADMUX = (ADMUX & 0b11111000) | kanal;
	ADCSRA |= (1 << ADSC);
	
	while(ADCSRA & (1 << ADSC));
	
	return ADCW;
}