# ===================================================================================
#                            checkmodeldbsyntax.py                                  |
# ===================================================================================
#                                                                                   |
# Programmer:     Sandy Wilson (KnightErrant)                                       |
#                                                                                   |
# Creation Date:   9 February 2007                                                  |
# Revision Dates: 11 February 2007 - Refactored string error and faction error      |
#                                       reporting into their own defs.              |
#                 13 February 2007 - Removed MODE_TWONUMBERS, wasn't being used.    |
#                                    Refactored all the textures checking into      |
#                                       a single def.                               |
#                                    Refactored all the mesh file checking into     |
#                                       a single def.                               |
#                                    Added getters for mesh file count and faction  |
#                                       number counts.                              |
#                                                                                   |
# ----------------------------------------------------------------------------------|
#                                                                                   |
#    This script reads the FORMATTED battle_models.modeldb text file and checks the |
# character counts against the actual number of characters in the string.           |
# It also checks the number of entries against the faction number to see if the     |
# user entered a new faction set but forgot to update the faction count number      |
# preceeding that block.                                                            |
#                                                                                   |
# ===================================================================================

# Imports. We'll use the module os to launch notepad on the output errors file.
import os

# Globals.
global CHECKFILEEXISTS_FLAG
global linenumber
global errorcount
global errorstringcount
global errorfactioncount
global errorfileexistscount
global opt
global MODE_ONENUMBER
global MODE_FILENAME
global MODE_FACTIONNAME
global MODE_TERMINATE
global MODE_OTHER

# Initialize globals.
CHECKFILEEXISTS_FLAG       = False
linenumber                 = 0
errorcount                 = 0
errorstringcount           = 0
errorfactioncount          = 0
errorfileexistscount       = 0
opt                        = 0
MODE_ONENUMBER             = 1
MODE_FILENAME              = 2
MODE_FACTIONNAME           = 3
MODE_TERMINATE             = 4
MODE_OTHER                 = 5

# ===================================================================================
def process_mount_pony( fidin, fidout ) :

    # Globals.
    global linenumber

    # Get the unit name.
    linenumber             = linenumber + 1
    string                 = fidin.readline()              # Read one line.
    token                  = string.split()                # Tokenize the line.
    unitname               = token[1]                      # This is the 2nd token (index 1 in 0-based).

    # Get the number of mesh files.
    linenumber             = linenumber + 1
    string                 = fidin.readline()
    token                  = string.split()                
    nmesh                  = int( token[3] )               # Fourth token is the mesh number (index 3 in 0-based).

    # Check the mesh files.
    processmeshfiles( fidin, fidout, nmesh )
    
    # Get faction number, for this unit only this is third token (index 2 in 0-based indexing).
    linenumber             = linenumber + 1
    string                 = fidin.readline()
    token                  = string.split()                
    factionnumber          = int( token[2] )

    processtexturefiles( fidin, fidout, factionnumber )      # Check the textures files and the faction entry count. 

    processrestofentry( fidin, fidout )                      # Process rest of unit entry. 

    return


# ===================================================================================
def processmountunit( fidin, fidout ) :

    nmesh                  = getmeshfilecount( fidin )
    processmeshfiles( fidin, fidout, nmesh )
    factionnumber          = getfactioncount( fidin )
    processtexturefiles( fidin, fidout, factionnumber )
    processrestofentry( fidin, fidout )

    return


# ===================================================================================
def processunit( fidin, fidout ) :

    global opt

    nmesh                  = getmeshfilecount( fidin )
    processmeshfiles( fidin, fidout, nmesh )
    factionnumber          = getfactioncount( fidin )

    # Check the body texture files, the next faction number comes back in global variable opt.
    processtexturefiles( fidin, fidout, factionnumber )
    factionnumber          = opt                           

    # Check the AttachmentSet textures files and count the faction entries.
    processtexturefiles( fidin, fidout, factionnumber )

    # Process all the stuff at the bottom of the unit definition. No faction counting here.
    processrestofentry( fidin, fidout )

    return


# ===================================================================================
def processmeshfiles( fidin, fidout, nmesh ) :

    global CHECKFILEEXISTS_FLAG
    global linenumber

    for ii in range( nmesh ) :
        linenumber         = linenumber + 1
        string             = fidin.readline()
        token              = string.split()
        nchar0             = int( token[0] )
        nchar1             = len( token[1] )
        if nchar0 != nchar1 :
            processstringerror( fidout, nchar0, nchar1, token[1] )

        if CHECKFILEEXISTS_FLAG == True :
            filename       = "../" + token[1]
            exist_flag     = os.path.lexists( filename ) 
            if exist_flag == False :
                processfileexistserror( fidout, token[1] )

    return


# ===================================================================================
def processtexturefiles( fidin, fidout, factionnumber ) :
    # Note that the second factionnumber for AttachmentSets will be set in processline
    # in the global variable opt.  This is how we will retrieve it in the calling
    # function.

    global linenumber
    global MODE_ONENUMBER      
    global MODE_FILENAME
    global MODE_FACTIONNAME
    global MODE_TERMINATE
    global MODE_OTHER

    processing_flag        = True
    faccnt                 = 0
    while( processing_flag ) :
        linenumber         = linenumber + 1
        string             = fidin.readline()
        mode               = processline( fidout, string )
        # If faction entry increment faction counter.
        if mode == MODE_FACTIONNAME :
            faccnt         = faccnt + 1
        # If one number or other then we're done.
        elif ( mode == MODE_ONENUMBER ) | ( mode == MODE_OTHER ) :
            processing_flag = False
            if faccnt != factionnumber :
                processfactionerror( fidout, factionnumber, faccnt )
        elif mode == MODE_FILENAME :
            pass                                           # No-op, filenames already been checked.
        else :
            print 'Error in processtexturefiles! Fell through switch construct, this should not happen...'
            fidout.write( 'Error in processtexturefiles! Fell through switch construct, this should not happen...\n' )

    return


# ===================================================================================
def processrestofentry( fidin, fidout ) :

    global linenumber
    global MODE_TERMINATE

    # We only care about seeing the termination string here.
    processing_flag        = True
    while( processing_flag ) :
        linenumber         = linenumber + 1
        string             = fidin.readline()
        mode               = processline( fidout, string )
        if mode == MODE_TERMINATE :
            processing_flag = False

    return


# ===================================================================================
def getmeshfilecount( fidin ) :

    global linenumber

    linenumber             = linenumber + 1
    string                 = fidin.readline()
    token                  = string.split()                
    meshfilecount          = int( token[1] )               

    return meshfilecount


# ===================================================================================
def getfactioncount( fidin ) :

    global linenumber

    linenumber             = linenumber + 1
    string                 = fidin.readline()
    token                  = string.split()                
    if len(token) == 1 :
       factioncount        = int( token[0] )               
    else :
       factioncount        = int( token[2] )               

    return factioncount


# ===================================================================================
def processline( fidout, string ):
    import re

    global CHECKFILEEXISTS_FLAG
    global linenumber
    global MODE_ONENUMBER      
    global MODE_FILENAME
    global MODE_FACTIONNAME
    global MODE_TERMINATE
    global MODE_OTHER
    global opt

    # Is this a termination string? that is, is it
    #  16 -0.090000004 0 0 -0.34999999 0.80000001 0.60000002 or   
    #  0 -1 0 0 0 0 0 0                                         
    nminusone              = re.search( '0\s-1\s0\s0\s0\s0\s0\s0', string )
    nfunnynumber           = re.search( '[0-9]+\s-0.090000004\s', string )
    if ( nminusone != None ) | ( nfunnynumber != None ):
        mode               = MODE_TERMINATE
        return mode

    # Tokenize string for all the following tests.
    token                  = string.split()
    ntoks                  = len( token )
    num                    = int( token[0] )

    # Test if its a single number.
    if ntoks == 1 :
        mode               = MODE_ONENUMBER
        opt                = num 
        return mode

    # Test if its a number/factionname pair.
    if isfactionname( token[1] ) :
        mode               = MODE_FACTIONNAME
        nchars             = len( token[1] )
        if nchars != num :
            processstringerror( fidout, num, nchars, token[1] )
        return mode

    # Test if it is an "other" case, that is, not a filename with a '/' character in it.
    nstart                 = token[1].find( '/' )
    if nstart == -1 :
        mode               = MODE_OTHER
        nchars             = len( token[1] )
        if nchars != num :
            processstringerror( fidout, num, nchars, token[1] )
        return mode

    # Finally, it must be a filename. Unfortunately, CA puts spaces
    # in their filenames so we have to glue it together properly.
    # We've done the .mesh case elsewhere so we only have to do the
    # .texture or the .spr files.
    mode                   = MODE_FILENAME
    sprite_flag            = False
    for ii in range( 1, ntoks ) :
        nstart             = token[ii].find( '.spr' )
        if nstart > 0 :
            sprite_flag    = True
            break

    if sprite_flag :
        sep                = ' '
        if ii == 1 :
            filename       = token[ii]
        else :
            filename       = sep.join( token[1:ii+1] )
        if ii < ntoks-1 :
            opt            = int( token[ntoks-1] )
        nchars             = len( filename )
        if nchars != num :
           processstringerror( fidout, num, nchars, token[1] )

        if CHECKFILEEXISTS_FLAG == True :
            tpath          = "../" + filename
            exist_flag     = os.path.lexists( tpath )    
            if exist_flag == False :
                processfileexistserror( fidout, filename )
        return mode

    texture_flag           = False
    for ii in range( 1, ntoks ) :
        nstart             = token[ii].find( '.texture' )
        if nstart > 0 :
            texture_flag   = True
            break

    if texture_flag :
        sep                = ' '
        if ii == 1 :
            filename       = token[ii]
        else :
            filename       = sep.join( token[1:ii+1] )
        if ii < ntoks-1 :
            opt            = int( token[ntoks-1] )
        nchars             = len( filename )
        if nchars != num :
           processstringerror( fidout, num, nchars, token[1] )

        if CHECKFILEEXISTS_FLAG == True :
            tpath          = "../" + filename
            exist_flag     = os.path.lexists( tpath )    
            if exist_flag == False :
                processfileexistserror( fidout, filename )
        return mode
    else :
        print 'Untrapped error on line ' + str( linenumber ) + ' in function processline!'
        fidout.write( 'Untrapped error on line ' + str( linenumber ) + ' in function processline!\n' )
        
    return 0


# ===================================================================================
def isfactionname( string ) :
    if string == 'england' :
        return True
    elif string == 'scotland' :
        return True
    elif string == 'france' :
        return True
    elif string == 'hre' :
        return True
    elif string == 'denmark' :
        return True
    elif string == 'spain' :
        return True
    elif string == 'portugal' :
        return True
    elif string == 'milan' :
        return True
    elif string == 'venice' :
        return True
    elif string == 'papal_states' :
        return True
    elif string == 'sicily' :
        return True
    elif string == 'poland' :
        return True
    elif string == 'russia' :
        return True
    elif string == 'hungary' :
        return True
    elif string == 'byzantium' :
        return True
    elif string == 'moors' :
        return True
    elif string == 'egypt' :
        return True
    elif string == 'turks' :
        return True
    elif string == 'mongols' :
        return True
    elif string == 'timurids' :
        return True
    elif string == 'aztecs' :
        return True
    elif string == 'slave' :
        return True
    elif string == 'merc' :
        return True
    elif string == 'saxons' :
        return True
    elif string == 'normans' :
        return True
    else :
        return False

    return False


# ===================================================================================
def processstringerror( fidout, nchar0, nchar1, string ):
    global linenumber
    global errorcount
    global errorstringcount
    errorcount             = errorcount + 1
    errorstringcount       = errorstringcount + 1
    errorstring            = '****** String count  error at line ' + str( linenumber ) + ', count says ' + str( nchar0 ) + ' but string has ' + str( nchar1 ) + ' characters \n'
    print errorstring
    fidout.write( errorstring )

    return


# ===================================================================================
def processfactionerror( fidout, factionnumber, faccnt ):
    global linenumber
    global errorcount
    global errorfactioncount
    errorcount             = errorcount + 1
    errorfactioncount      = errorfactioncount + 1
    errorstring            = '****** Faction count error at line ' + str( linenumber ) + ', count says ' + str( factionnumber ) + ' but number of entries is ' + str( faccnt ) + '\n'
    print errorstring
    fidout.write( errorstring )
    return


# ===================================================================================
def processfileexistserror( fidout, filename ):
    global linenumber
    global errorcount
    global errorfileexistscount
    errorcount             = errorcount + 1
    errorfileexistscount   = errorfileexistscount + 1
    errorstring            = '****** File does not exist error at line ' + str( linenumber ) + ', filename: ' + str( filename ) 
    print errorstring
    fidout.write( errorstring )
    return


# ===================================================================================
# Start of main routine.                                                            |
# ===================================================================================

# Open the modeldb input file.
#fidin                      = open( 'formatted_battle_models.modeldb', 'r' )   
fidin                      = open( 'battle_models.modeldb', 'r' )   

# Open the error output file.
fidout                     = open( 'modeldbsyntaxerrors.txt', 'w' )

# Get first line.
linenumber                 = linenumber + 1
string                     = fidin.readline()
token                      = string.split()

# This is the unit count.
unitcount                  = int( token[7] )

# Process the first mount entry as custom because its formatting is non-standard.
process_mount_pony( fidin, fidout )
sectionnumber              = 1                  

# Loop.
while True :
    # Get the unit name (and check for end of file).
    linenumber             = linenumber + 1
    string                 = fidin.readline()
    if string == '' :
        break
    token                  = string.split()
    unitname               = token[1]
    sectionnumber          = sectionnumber + 1

    # Check count on the name.
    nchar0                 = int( token[0] )
    nchar1                 = len( unitname )
    if nchar0 != nchar1 :
        processstringerror( fidout, nchar0, nchar1, unitname )

    # Check for a mount unit.
    imnt                   = unitname.find( 'mount_' )     # Underscore _ matters else we would match mounted_sergeants!
    if imnt > -1 :
        print 'Unit: ' + str( sectionnumber ) + ', processing a mount unit:   ' + unitname
        processmountunit( fidin, fidout )
    else :
        print 'Unit: ' + str( sectionnumber ) + ', processing a regular unit: ' + unitname
        processunit( fidin, fidout )

# Done!
fidin.close()

# Output statistics.
string1                    = 'Unit count at top of file       = ' + str( unitcount ) 
string2                    = 'Number of processed unit models = ' + str( sectionnumber ) 
string3                    = 'It is advisable that these two numbers should match.'
string4                    = 'Total errors:               ' + str( errorcount ) 
string5                    = 'String  count errors:       ' + str( errorstringcount ) 
string6                    = 'Faction count errors:       ' + str( errorfactioncount ) 
print string1
print string2
print string3
print string4
print string5
print string6
if CHECKFILEEXISTS_FLAG == True :
   print 'File does not exist errors: ' + str( errorfileexistscount )


fidout.write( string1 + '\n')
fidout.write( string2 + '\n')
fidout.write( string3 + '\n')
fidout.write( string4 + '\n')
fidout.write( string5 + '\n')
fidout.write( string6 + '\n')
if CHECKFILEEXISTS_FLAG == True :
   fidout.write( 'File does not exist errors: ' + str( errorfileexistscount ) + '\n' )

fidout.close()


# Launch notepad on the modeldbsyntaxerrors.txt file.
args                       =  [ 'arg0', 'modeldbsyntaxerrors.txt' ] 
os.execv( "c:/windows/system32/notepad.exe", args )
