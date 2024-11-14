#include <stdio.h>
#include "stdint.h"
#include "stdbool.h"
#include "string.h"
#include "inttypes.h"
#include "Cheat_Functions.h"

	//struct SCheatData Cheat;

/*int __cdecl testload ()
{
	//SCheatData Cheat;
	S9xLoadCheatFile("C:\\Users\\Diane\\Desktop\\snes9x\\Cheats\\Super Mario World (U) [!].cht");
	//printf("%i", Cheat.c[1].address);
	
	return Cheat.c[1].address;
}*/

/*int __cdecl S9xFillCheat (int index, int address, int byte1, int saved_byte, int enabled, int saved, char name[])
{
	Cheat.c[index].address = address;
	Cheat.c[index].byte1 = byte1;
	Cheat.c[index].saved_byte = saved_byte;
	Cheat.c[index].enabled = enabled;
	Cheat.c[index].saved = saved;
	//Cheat.c[index].name[] = name[];
	Cheat.num_cheats=index;
	index=200;
}
*/
/*int __cdecl S9xGetCheat (int index, int *address, int *byte1, int *saved_byte, int *enabled, int *saved, char *name[])
{
	address<-Cheat.c[index].address;
	byte1<-Cheat.c[index].byte1;
	saved_byte<-Cheat.c[index].saved_byte;
	enabled<-Cheat.c[index].enabled;
	saved<-Cheat.c[index].saved;
	//Cheat.c[index].name[] = name[];
	//index=Cheat.num_cheats;
}*/
// = new SCheatData();
int __cdecl S9xLoadCheatFile (const char *filename)
{
	printf("Entering DLL\n");
	FILE	*fs;
	uint8_t data[28];
	data1.num_cheats = 0;
	printf("Pointer Value: %i\n & File Name: %s\n ", &data1, filename);
	fs = fopen(filename, "rb");
	if (!fs)
	return (-1);
	while (fread((void *) data, 1, 28, fs) == 28)
	{
		data1.c[data1.num_cheats].enabled = (data[0] & 4) == 0;
		data1.c[data1.num_cheats].byte1 = data[1];
		data1.c[data1.num_cheats].address = data[2] | (data[3] << 8) | (data[4] << 16);
		data1.c[data1.num_cheats].saved_byte = data[5];
		data1.c[data1.num_cheats].saved = (data[0] & 8) != 0;
		memmove(data1.c[data1.num_cheats].name, &data[8], 20);
		data1.c[data1.num_cheats++].name[20] = 0;
	}
	fclose(fs);
	printf("NumCheats before: %i\nLeaving DLL\n", data1.num_cheats);
	//data1.num_cheats = 0;
	return (1);
}

int __cdecl S9xSaveCheatFile (const char *filename)
{
	if (data1.num_cheats == 0)
	{
		remove(filename);
		return (1);
	}
	FILE	*fs;
	uint8_t data[28];
	fs = fopen(filename, "wb");
	if (!fs)
		return (-1);
	for (uint32_t i = 0; i < data1.num_cheats; i++)
	{
		memset(data, 0, 28);
		if (i == 0)
		{
			data[6] = 254;
			data[7] = 252;
		}
		if (!data1.c[i].enabled)
			data[0] |= 4;
		if (data1.c[i].saved)
			data[0] |= 8;
		data[1] = data1.c[i].byte1;
		data[2] = (uint8_t) (data1.c[i].address >> 0);
		data[3] = (uint8_t) (data1.c[i].address >> 8);
		data[4] = (uint8_t) (data1.c[i].address >> 16);
		data[5] = data1.c[i].saved_byte;
		memmove(&data[8], data1.c[i].name, 19);
		if (fwrite(data, 28, 1, fs) != 1)
		{
			fclose(fs);
			return (-1);
		}
	}
	return (fclose(fs) == 0);
}


SCheatData* __cdecl GetDataPtr()
{
    return &data1;
}

