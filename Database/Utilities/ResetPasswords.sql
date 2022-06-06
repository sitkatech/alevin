-- this script is used to reset all user passwords.

use AlevinDB
if (@@error != 0) goto failed

-- Set all user's passwords to be "password#1" for testing and QA environments
    exec ('update dbo.[PersonLoginAccount] set [PasswordHash] = ''UrFd2oinFLZ84RTumt7wHOF+F5G0jnLzDMjHY+M0FL0='', PasswordSalt = ''10000:nG0bXssoKynZKz6hKh+jeMEgLTgpggSAOIorUYlv6vg=''')
    if (@@error != 0) goto failed
goto goodbye

failed:

raiserror('The database password reset script failed. Additional error details should be available above.', 16, 1)

goodbye:

use master


