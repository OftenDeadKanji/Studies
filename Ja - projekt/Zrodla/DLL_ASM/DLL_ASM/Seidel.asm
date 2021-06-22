.data
	Aaddr DQ 0
	Baddr DQ 0
	alfa DQ 0
	beta DQ 0
	variablesNumber DQ 0
	xOld DQ 0
	xNew DQ 0
	condition DQ 0
	isReady DQ 0
	precision REAL4 0.0
	maxIterations DQ 0
	threadsNumber DQ 0

	minus REAL4 -0.0
	mutex DWORD 0

.code
SeidelAsm PROC
	;zmienne lokalne
	LOCAL lowerBound:QWORD					;dolna granica przedzia³u dla w¹tku
    LOCAL upperBound:QWORD					;górna granica przedzia³u dla w¹tku
	LOCAL boolCondition:QWORD				;zmienna wykorzystywana przy synchronizacji
	LOCAL counter:QWORD						;licznik pêtli

	;POBRANIE ARGUMENTÓW
	MOV Aaddr, RCX							;macierz A
	MOV Baddr, RDX							;wektor B
	MOV alfa, R8							;macierz alfa
	MOV beta, R9							;wektor beta

	MOV EAX, DWORD PTR [RSP + 80]
	MOV variablesNumber, RAX				;liczba niewiadomych

	MOV RAX, QWORD PTR [RSP + 88]
	MOV xOld, RAX							;X poprzedniej iteracji

	MOV RAX, QWORD PTR [RSP + 96]
	MOV xNew, RAX							;X nowej iteracji

	MOV EAX, DWORD PTR [RSP + 104]
	MOV lowerBound, RAX						;dolna granica przedzia³u dla w¹tku

	MOV EAX, DWORD PTR [RSP + 112]
	MOV upperBound, RAX						;górna granica przedzia³u dla w¹tku

	MOV RAX, QWORD PTR [RSP + 120]
	MOV condition, RAX						;suma wyliczana do precyzji

	MOV RAX, QWORD PTR [RSP + 128]
	MOV isReady, RAX						;tablica booli wykorzystywana do synchronizacji

	MOVSS XMM0, DWORD PTR [RSP + 136]
	MOVSS precision, XMM0					;ustalony poziom precyzji

	MOV EAX, DWORD PTR [RSP + 144]
	MOV maxIterations, RAX					;maksymalna liczba iteracji

	MOV counter, 0							;wyzerowanie lokalnego licznika pêtli

	;zabezpieczenie rejestrów
	PUSH RBX

	;ROZPOCZÊCIE G£ÓWNEJ CZÊŒCI FUNKCJI

	;PÊTLA FOR
	;PRZYPISANIE i = lowerBound
	MOV RAX, lowerBound
	MOV R8, RAX

LOOP1:
	;PORÓWNANIE i < upperBound
	MOV RAX, R8
	CMP RAX, upperBound
	JE END1

	;PRZYPISANIE divisor = A[i][i]
	MOV RCX, R8
	MOV RDX, QWORD PTR [Aaddr]
	MOV RAX, QWORD PTR [RDX + RCX * 8]
	MOVSS XMM0, DWORD PTR [RAX + RCX * 4]
	MOVSS XMM1, minus
	XORPS XMM0, XMM1
	MOVSS XMM2, XMM0

	;ZAGNIE¯D¯ONA PÊTLA FOR
	;PRZYPISANIE j = 0
	MOV R9, 0

LOOP2:
	;PORÓWNANIE j < variablesNumber
	MOV RAX, R9
	CMP RAX, variablesNumber
	JE END2

	;A[i][j] -> XMM0
	MOV RAX, R8
	MOV RCX, R9
	MOV RDX, QWORD PTR [Aaddr]
	MOV RAX, QWORD PTR [RDX + RAX * 8]
	MOVSS XMM0, DWORD PTR [RAX + RCX * 4]
	; XMM0 / XMM2
	DIVSS XMM0, XMM2
	; alfa[i][j] = XMM0 (= -A[i][j] / XMM2)
	MOV RAX, R8
	MOV RCX, R9
	MOV RDX, QWORD PTR [alfa]
	MOV RAX, QWORD PTR [RDX + RAX * 8]
	MOVSS DWORD PTR [RAX + RCX * 4], XMM0
	INC R9
	JMP LOOP2

END2:
	;beta[i] = B[i] / XMM2
	;xNew[i] = beta[i]
	MOVSS XMM1, minus
	XORPS XMM2, XMM1
	MOV RAX, R8
	MOV RCX, QWORD PTR [beta]
	MOV RDX, QWORD PTR [Baddr]
	MOVSS XMM0, DWORD PTR [RDX + RAX * 4]
	DIVSS XMM0, XMM2
	MOVSS DWORD PTR [RCX + RAX * 4], XMM0
	MOV RCX, QWORD PTR [xNew]
	MOVSS DWORD PTR [RCX + RAX * 4], XMM0

	;alfa[i][i] = 0
	MOV RAX, R8
	MOV RCX, R8
	MOV RDX, QWORD PTR [alfa]
	MOV RAX, QWORD PTR [RDX + RAX * 8]
	PXOR XMM0, XMM0
	MOVSS DWORD PTR [RAX + RCX * 4], XMM0
	
	;isReady[0][i] = true
	MOV RAX, R8
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 0]
	MOV BYTE PTR [RDX + RAX], 1
	;LOCK DEC boolCondition0
	INC R8
	JMP LOOP1
END1:

	;synchronizacja w¹tków
SynchLoop0:
	MOV RAX, boolCondition
	CMP RAX, 1
	JE SynchLoop0End
	MOV boolCondition, 1
	MOV R8, 0 
ForLoop0:
	MOV RAX, r8
	CMP RAX, variablesNumber
	JE ForLoop0End
	INC R8
	;sprawdzenie czy obliczenia dla danej niewiadomej zosta³y zakoñczone
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 0]
	MOV AL, BYTE PTR [RDX + RAX]
	CMP AL, 1
	JE ForLoop0
	MOV boolCondition, 0
ForLoop0End:
	JMP SynchLoop0
SynchLoop0End:
	MOV boolCondition, 0

	;rozpoczêcie pêtli DO WHILE
DOLOOP:
	INC counter
	;pierwsza pêtla FOR
	MOV RAX, lowerBound
	MOV R8, RAX

LOOP3:
	MOV RAX, R8
	CMP RAX, upperBound
	JE ENDLOOP3
	;sprawdzanie czy i + 4 < upperBound
	ADD RAX, 4
	CMP RAX, upperBound
	JA Rest
	;instrukcje wektorowe, jeœli w¹tek mo¿e przetworzyæ jeszcze min. 4 niewiadome

	;isReady[1][i] = false
	;isReady[2][i] = false
	MOV RAX, R8
	MOV RDX, QWORD PTR [isReady]

	MOV RCX, QWORD PTR [RDX + 8]
	MOV BYTE PTR [RCX + RAX], 0
	MOV BYTE PTR [RCX + RAX + 1], 0
	MOV BYTE PTR [RCX + RAX + 2], 0
	MOV BYTE PTR [RCX + RAX + 3], 0

	MOV RCX, QWORD PTR [RDX + 16]
	MOV BYTE PTR [RCX + RAX], 0
	MOV BYTE PTR [RCX + RAX + 1], 0
	MOV BYTE PTR [RCX + RAX + 2], 0
	MOV BYTE PTR [RCX + RAX + 3], 0
	
	;xOld[i] = xNew[i]
	;przes³anie 4 floatów
	MOV RDX, QWORD PTR [xNew]
	MOV RCX, QWORD PTR [xOld]
	MOVUPS XMM0, [RDX + RAX * 4]
	MOVUPD [RCX + RAX * 4], XMM0

	;isReady[1][i] = true
	MOV RDX, QWORD PTR [isReady]
	MOV RCX, QWORD PTR [RDX + 8]
	MOV BYTE PTR [RCX + RAX], 1
	MOV BYTE PTR [RCX + RAX + 1], 1
	MOV BYTE PTR [RCX + RAX + 2], 1
	MOV BYTE PTR [RCX + RAX + 3], 1

	ADD R8, 4
	JMP LOOP3

	;jeœli w¹tek przetworzy jeszcze mniej ni¿ 4 niewiadome to bez instrukcji wektorowych
Rest:
	MOV RAX, R8

	;xOld[i] = xNew[i]
	MOV RDX, QWORD PTR [xNew]
	MOV RCX, QWORD PTR [xOld]
	MOVSS XMM0, DWORD PTR [RDX + RAX * 4]
	MOVSS DWORD PTR [RCX + RAX * 4], XMM0

	;isReady[1][i] = true
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 8]
	MOV BYTE PTR [RDX + RAX], 1

	INC R8
	JMP LOOP3
ENDLOOP3:

	;synchronizacja w¹tków
SynchLoop1:
	MOV RAX, boolCondition
	CMP RAX, 1
	JE SynchLoop1End
	MOV boolCondition, 1
	MOV R8, 0 
ForLoop1:
	MOV RAX, r8
	CMP RAX, variablesNumber
	JE ForLoop1End
	INC R8
	;sprawdzenie czy obliczenia dla danej niewiadomej zosta³y zakoñczone
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 8]
	MOV AL, BYTE PTR [RDX + RAX]
	CMP AL, 1
	JE ForLoop1
	MOV boolCondition, 0
ForLoop1End:
	JMP SynchLoop1
SynchLoop1End:
	MOV boolCondition, 0

	;druga pêtla FOR
	MOV RAX, lowerBound
	MOV R8, RAX

LOOP4:
	MOV RAX, R8
	CMP RAX, upperBound
	JE ENDLOOP4

	;isReady[1][i] = false
	;isReady[2][i] = false
	MOV RAX, R8
	MOV RDX, QWORD PTR [isReady]
	MOV RCX, QWORD PTR [RDX + 16]
	MOV BYTE PTR [RCX + RAX], 0
	MOV RCX, QWORD PTR [RDX + 24]
	MOV BYTE PTR [RCX + RAX], 0

	;xNew[i] = beta[i]
	MOV RAX, R8
	MOV RDX, QWORD PTR [beta]
	MOVSS XMM0, DWORD PTR [RDX + RAX * 4]
	MOV RDX, QWORD PTR [xNew]
	MOVSS DWORD PTR [RDX + RAX * 4], XMM0

	;pierwsza zagnie¿d¿ona pêtla FOR
	;j = i + 1
	MOV RAX, R8
	INC RAX
	MOV R9, RAX

LOOP5:
	MOV RAX, R9
	CMP RAX, variablesNumber
	JE ENDLOOP5
	MOV RAX, R8
	MOV RBX, R9

	;RCX = alfa[i]
	MOV RCX, QWORD PTR [alfa]
	MOV RCX, QWORD PTR [RCX + RAX * 8]

	;RDX = xOld
	MOV RDX, QWORD PTR [xOld]
	MOVSS XMM0, DWORD PTR [RCX + RBX * 4]
	MOVSS XMM1, DWORD PTR [RDX + RBX * 4]
	MULSS XMM0, XMM1

	;xNew[i] += XMM0 (=alfa[i][j] * xOld[j])
	MOV RBX, R8
	MOV RCX, QWORD PTR [xNew]
	ADDSS XMM0, DWORD PTR [RCX + RBX * 4]
	MOVSS DWORD PTR[RCX + RBX * 4], XMM0
	INC R9
	JMP LOOP5

ENDLOOP5:

	;druga zagnie¿d¿ona pêtla FOR
	MOV R9, 0
LOOP6:
	MOV RAX, R9
	CMP RAX, R8
	JE ENDLOOP6

	;przygotowanie tablicy isReady[2]
	MOV RCX, QWORD PTR [isReady]
	MOV RCX, QWORD PTR [RCX + 16]
	MOV RBX, R9

	;pêtla WHILE
	XOR RDX, RDX

LOOP7:
	;oczekiwanie na zg³oszenie gotowaœci obliczeñ dla danej niewiadomej
	MOV DL, BYTE PTR [RCX + RBX]
	CMP DL, 0
	JE LOOP7

ENDLOOP7:
	;xNew[i] += alfa[i][j] * xNew[j];
	MOV RAX, R8
	MOV RBX, R9

	;RCX = alfa[i]
	MOV RCX, QWORD PTR [alfa]
	MOV RCX, QWORD PTR [RCX + RAX * 8]

	;RDX = xNew
	MOV RDX, QWORD PTR [xNew]
	MOVSS XMM0, DWORD PTR [RCX + RBX * 4]
	MOVSS XMM1, DWORD PTR [RDX + RBX * 4]
	MULSS XMM0, XMM1

	;xNew[i] += XMM0 (=alfa[i][j] * xNew[j])
	MOV RBX, R8
	MOV RCX, QWORD PTR [xNew]
	ADDSS XMM0, DWORD PTR [RCX + RBX * 4]
	MOVSS DWORD PTR[RCX + RBX * 4], XMM0
	INC R9
	JMP LOOP6

ENDLOOP6:
	;isReady[2][i] = true
	MOV RAX, R8
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 16]
	MOV BYTE PTR [RDX + RAX], 1
	INC R8
	JMP LOOP4

ENDLOOP4:

	;synchronizacja w¹tków
SynchLoop2:
	MOV RAX, boolCondition
	CMP RAX, 1
	JE SynchLoop2End
	MOV boolCondition, 1
	MOV R8, 0 
ForLoop2:
	MOV RAX, r8
	CMP RAX, variablesNumber
	JE ForLoop2End
	INC R8
	;sprawdzenie czy obliczenia dla danej niewiadomej zosta³y zakoñczone
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 16]
	MOV AL, BYTE PTR [RDX + RAX]
	CMP AL, 1
	JE ForLoop2
	MOV boolCondition, 0
ForLoop2End:
	JMP SynchLoop2
SynchLoop2End:
	MOV boolCondition, 0

	;trzecia pêtla FOR
	MOV RAX, lowerBound
	MOV R8, RAX

LOOP8:
	MOV RAX, R8
	CMP RAX, upperBound
	JE ENDLOOP8

	;isReady[1][i] = false
	;isReady[3][i] = false
	MOV RAX, R8
	MOV RDX, QWORD PTR [isReady]
	MOV RCX, QWORD PTR [RDX + 8]
	MOV BYTE PTR [RCX + RAX], 0
	MOV RCX, QWORD PTR [RDX + 24]
	MOV BYTE PTR [RCX + RAX], 0

	;obliczanie sumy do sprawdzenia precyzji
	;condition[i] = 0
	MOV RAX, R8
	MOV RDX, QWORD PTR [condition]
	MOV DWORD PTR [RDX + RAX * 4], 0
	;condition[i] += abs(xNew[i] - xOld[i])
	MOV RCX, QWORD PTR [xNew]
	MOVSS XMM0, DWORD PTR [RCX + RAX * 4]
	MOV RCX, QWORD PTR [xOld]

	MOVSS XMM1, DWORD PTR [RCX + RAX * 4]
	SUBSS XMM0, XMM1
	XORPS XMM1, XMM1
	COMISS XMM0, XMM1
	JNB SKIPABS
	MOVSS XMM1, minus
	XORPS XMM0, XMM1

SKIPABS:
	;condition[i] /= variablesNumber
	CVTSI2SS XMM1, variablesNumber
	DIVSS XMM0, XMM1
	MOVSS DWORD PTR [RDX + RAX * 4], XMM0

	;isReady[3][i] = true
	MOV RAX, R8
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 24]
	MOV BYTE PTR [RDX + RAX], 1
	INC R8
	JMP LOOP8

ENDLOOP8:

	;synchronizacja w¹tków
SynchLoop3:
	MOV RAX, boolCondition
	CMP RAX, 1
	JE SynchLoop3End
	MOV boolCondition, 1
	MOV R8, 0 
ForLoop3:
	MOV RAX, r8
	CMP RAX, variablesNumber
	JE ForLoop3End
	INC R8
	;sprawdzenie czy obliczenia dla danej niewiadomej zosta³y zakoñczone
	MOV RDX, QWORD PTR [isReady]
	MOV RDX, QWORD PTR [RDX + 24]
	MOV AL, BYTE PTR [RDX + RAX]
	CMP AL, 1
	JE ForLoop3
	MOV boolCondition, 0
ForLoop3End:
	JMP SynchLoop3
SynchLoop3End:
	MOV boolCondition, 0

	;czwarta pêtla FOR - sumowanie sk³adników sumy precyzji
	PXOR XMM3, XMM3
	MOV R8, 0

LOOP9:
	MOV RAX, R8
	CMP RAX, variablesNumber
	JE ENDLOOP9
	;XMM3 += condition[i]
	MOV RAX, R8
	MOV RDX, QWORD PTR [condition]
	MOVSS XMM1, DWORD PTR [RDX + RAX * 4]
	ADDSS XMM1, XMM3
	MOVSS XMM3, XMM1
	INC R8
	JMP LOOP9

ENDLOOP9:
	;warunek pêtli DO WHILE

	;precyzja
	MOVSS XMM0, XMM3
	MOVSS XMM1, precision
	CMPLESS XMM0, XMM1
	CVTSS2SI RAX, XMM0
	CMP RAX, 0
	JNZ	ENDDOLOOP

	;liczba iteracji
	MOV RAX, counter
	CMP RAX, maxIterations
	JAE	ENDDOLOOP
	JMP DOLOOP

	;koniec pêtli DO-WHILE -> koniec obliczeñ
ENDDOLOOP:

	;przywrócenie stanu rejestrów
	POP RBX
	
	RET
SeidelAsm ENDP
END