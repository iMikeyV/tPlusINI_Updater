# tPlusINI_Updater
Updates .ini for T Plus program
 
  
### Problem:
TPlus is set for the wrong numbers of registers which causes the program to look for nonexistent registers, making the load up time incredibly slow (up to 5 minutes)   

Analysts would normally have to manually adjust the .INI  
 
### Solution:  
Program reads INI, displays current set up and asks analyst if it needs to be updated. (2 or 3 registers)
If it does, program will back up INI settings, and then rewrite them accordingly. 

See program comments for details
