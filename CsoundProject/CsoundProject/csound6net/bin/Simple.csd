<CsoundSynthesizer>
<CsOptions>
	-o simple.wav
</CsOptions>
<CsInstruments>
sr = 44100
kr = 4410
ksmps = 10
nchnls = 1

	instr 1
	a1 oscil p4, p5, 1
	out a1
	endin

</CsInstruments>
<CsScore>
f1 0	2048	10	1

i 1	0	2	10000	440.0
i 1 2.0 .75 10000 220.0
e 3
</CsScore>
</CsoundSynthesizer>
