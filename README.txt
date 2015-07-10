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

The client enforces TLS1.2.  Depending on your OS TLS1.2 may not be enabled.
EnableTLS12Windows7.reg will add the necessary keys to your registry to enable TLS1.1 and TLS1.2.
You'll have to reboot your machine before the registry changes will take effect.