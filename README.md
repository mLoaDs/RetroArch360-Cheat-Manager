<img width="353" alt="unnamed2" src="https://github.com/user-attachments/assets/528b2053-1af7-4d11-b6b6-6417983affa3">

# RetroArch360-Cheat-Manager
Cheat-Manager for Unofficial RetroArch 360 cores by gavin_darkglider

A Database Program that will generate cht files that work with the Aurora enabled retroarch cores. The Official Retroarch build for the Xbox 360 does not support cht files, so go get the unofficial version.

load cheat file in Unofficial RetroArch360 https://github.com/mLoaDs/RetroArch360-Cheat-Manager/wiki

This is still in the beta stages, but has basic functionality.

Currently creating cheats for
-----------------------------
1. Nintendo
2. Super Nintendo
3. GameBoy/GameBoy Color - Retro Arch Doesnt Currently support
4. GameBoy Advanced - Retro Arch Doesnt Currently support
5. Sega Genisis/Megadrive

Features:
---------
- Create/Modify Game Info
- Create/Modify Cheat info
- Export Cheat files from database. (RetroArch/Snes9x,FCEUX,ZSNES,Genesis/Kega Fusion.)
- Determine if you have roms for games in database, so you dont have to export whole database. This requires having a copy of the roms on the computer, as I have yet to 
  implement FTP functionallity.
- Added Genesis Cheats to Database.
- Added the ability for the app to create a blank DB if the DB isnt found.
- GameGenie <> Hex conversion. Needed for some emulators(Eg. Snes9x) Does on the fly while creating cht files.
- Added Progress Bar(So you know the app hasnt Frozen)
- Sorting game list by system
- Added Info about DB(How many games, cheats, and games you have)
- Fixed File Name issues with the Xbox.
- Added About.
- Can now update sha256 hashes for your rom set. Just click on the hash in modify game, and choose your rom.  Only works with rom files, so dont forget to unzip them if you 
  store your games that way.
- Fixed bug with SNES9X/ZSNES export where blank cheats were getting put in file.
- Added GameGear Support.
- Added GameGenie2Hex converter, for easy modification of GG Codes, and it is cool to have.
- Fixed Cheats for GBA, and GB/GBC, so now they work. Thank you Felida for cracking that one.
- Added GameGear Cheats to DB. Thank you Felida, once again, for your hard work on the DB.
- Added search, and sort functions.
- FTP Functionallity

Features to add.
----------------
1. Import Functions(Some have been worked on, Mainly to save me time building the DB, but the end user cant access them. Yet. :)
2. Export to cht files for other emulators(coming along, but still a bunch to add)
3. Finish adding other emulator cores/cheats to Database(Still needs to be done).
4. Add an option to auto rename cht files to match rom names for emulators that require this.

NOTE: IF YOU HAVE ISSUES WITH SCANNING ROMS NOT FINDING YOUR ROMS, IT IS BECAUSE THERE ARE MULTIPLE VERSIONS OF EVERY ROM, AND I ONLY SAVED 1 SHA256 SUM( EVERY VERSIONS IS DIFFERENT) TO THE DATABASE, AS I DONT HAVE EVERY VERSION OF EVERY ROM. YOU CAN MANUALLY SET THAT YOU HAVE A GAME UNDER MODIFY GAME.

Special Thanks to: Swizzy, and Felida for helping me track down the bugs, and Felida for helping with the Database.
https://www.realmodscene.com/index.php?/topic/5032-cheat-manager-for-emulators/&tab=comments#comment-40404
