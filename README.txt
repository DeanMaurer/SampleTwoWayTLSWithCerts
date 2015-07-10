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