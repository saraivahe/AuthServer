# Run Instructions

## 1. Clone repository to local directory and open with Visual Studio

Recommended version 2022

## 2. Publish project to some directory of your choosing (choose publish to folder)

## 3. Add the following line to your hosts file

Usual file location: C:\Windows\System32\drivers\etc\

127.0.0.1 login-dev.com

## 4. Add new site in IIS with the following configurations

Choose the directory you just published as the site path

Protocol: HTTPS

Port: 443

Custom Domain: login-dev.com

IIS Development certificate

## 5. Once the site is running, you can confirm by open the following URL

https://login-dev.com/.well-known/openid-configuration
