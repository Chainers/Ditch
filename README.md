# Ditch
Creat and broadcast transactions to blockchain

# Sources

The library is written based on the article https://steemit.com/steem/@xeroc/steem-transaction-signing-in-a-nutshell as well as the existing code:

    https://github.com/steemit/steem
    https://github.com/xeroc/piston-lib
    https://github.com/xeroc/python-graphenelib

# Usage

The essence of the library is to generate a transaction according to the required operations (vote, comment, etc.), sign the transaction and broadcast to the Graphene-based blockchain. For transaction signing we announced earlier our standalone Cryptography.ECDSA lib which is being used by Ditch lib for the signing purpose.

![Image of chainers libs](https://steemitimages.com/0x0/https://steemitimages.com/DQmaftMx6enBa1Yercb2Cz4UHV6UT2BXJSZmReS58TBLAM3/table_chainers_libs.PNG)
