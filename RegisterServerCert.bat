rem You can find your cert's thumprint by:
rem Openning MMC
rem Adding the Certificates/Computer Account/Local computer snap-in
rem Navigating to Certificates (Local Computer)/Personal/Certificates
rem Openning the cert Issued To 'localhost' and Issued By 'SelfSignedCA'
rem Clicking on the Details Tab
rem Finding the Field called 'Thumbprint'

rem Don't forget to remove the spaces!
netsh http add sslcert ipport=0.0.0.0:44355 certhash=EnterTheThumprintHere appid={a0327398-4069-4d2d-83c0-a0d5e6cc71b5}