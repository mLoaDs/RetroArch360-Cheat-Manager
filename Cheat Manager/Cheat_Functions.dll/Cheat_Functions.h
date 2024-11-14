
#define MAX_CHEATS	150

extern "C"

/*struct SCheat
{
	long address;
	long byte1;
	long saved_byte;
	long enabled;
	long saved;
	wchar_t name[];
};
struct SCheatData
{
	struct SCheat c[MAX_CHEATS];
	long num_cheats;
};*/
struct SCheat
{
uint32_t address;
uint8_t byte1;
uint8_t saved_byte;
bool enabled;
bool saved;
char	name[22];
};
struct SCheatData
{
struct SCheat c[MAX_CHEATS];
uint32_t num_cheats;
};

//extern SCheatData Cheat;

//__declspec(dllexport) void __cdecl CreateCheat ();
//__declspec(dllexport) int __cdecl testload ();
//__declspec(dllexport) int __cdecl S9xFillCheat (int index, int address, int byte1, int saved_byte, int enabled, int saved, char name[]);
__declspec(dllexport) int __cdecl S9xLoadCheatFile (const char *);
__declspec(dllexport) int __cdecl S9xSaveCheatFile (const char *);

__declspec(dllexport) SCheatData* __cdecl GetDataPtr();

struct SCheatData data1;