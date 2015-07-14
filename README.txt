Before the sample app will work you'll have to create the certificates.
Unfortunately, I haven't found a way to fully automate this process.

First, you need to run CreateRootCert.bat.
	It'll prompt you for a password, you'll need to enter this password again when creating your server and client certs.
Then run MMC and open the Certificates/Computer Account/Local computer snap-in.
Expand Certificates (Local Computer) and Trusted Root Certification Authorities.
Right click on Certificates and select All Tasks/Import.
Browse to your C: drive and select rootca.cer.
Everything else in the import wizard should be left at its default value.

Next run CreateClientAndServerCerts.bat.

Next open RegisterServerCert.bat and follow the instructions in it before running it.

EnableTLSq2Windows7.reg does two things:
a)	It enables TLS1.2, which is disabled by default on Windows 7.
b)	It stops the server from attempting to send a full list of the trusted root certificates to the client.
	Most Windows 7 machines have more trusted root certificates than WCF can send, which causes the list to be truncated.
	Which causes the TLS authentication to fail.
A reboot is required for the registry updates to take effect.


The client can use any certificate that chains to a cert in your server's trusted root store.
This sample app doesn't go into detail on how to restrict the acceptable trusted root certs for the server.
But, briefly, you need makeCTL.exe.  Using it you can create a Certificate Trust List, that includes only the certs you
want your server to accept.  Import the CTL into the Intermediate Certificate Authority folder for your local computer using MMC.
Then, instead of executing RegisterServerCert.bat, use the below netsh command template:

netsh http add sslcert ipport=0.0.0.0:44355 certhash=EnterYourThumbprintHere appid={a0327398-4069-4d2d-83c0-a0d5e6cc71b5} sslctlidentifier=NameOfTheCTLYouCreated sslctlstorename=CA