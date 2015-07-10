rem Server's cert
makecert -n "CN=localhost" -ic c:\rootca.cer -iv c:\rootca.pvk -sr LocalMachine -ss My -pe -sky exchange -eku 1.3.6.1.5.5.7.3.1

rem Client's cert
makecert -n "CN=client1" -ic c:\rootca.cer -iv c:\rootca.pvk -sr LocalMachine -ss My -pe -sky exchange -eku 1.3.6.1.5.5.7.3.2