# SoapKestrelServer

## Test Soap Server

### Start WcfTestClient

Url is: `http://localhost:58902/Service.asmx`

```powershell
Resolve-Path "C:\Program *\Microsoft Visual Studio\*\*\Common7\IDE\WcfTestClient.exe" | Select-Object -First 1 | %{Start-Process $_}
```

### Capture request with Fiddler

```
POST http://localhost:58902/Service.asmx HTTP/1.1
Content-Type: text/xml; charset=utf-8
SOAPAction: "http://tempuri.org/IServiceContract/Ping"
Host: localhost:58902
```

```xml
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
  <s:Body>
    <Ping i:nil="true" xmlns="http://tempuri.org/" xmlns:a="http://schemas.datacontract.org/2004/07/" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"/>
  </s:Body>
</s:Envelope>
```

### Get Response

```xml
<?xml version="1.0" encoding="utf-8"?>
<s:Envelope xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <PingResponse xmlns="http://tempuri.org/">
            <PingResult>2018-03-06T20:18:36.5217831Z</PingResult>
        </PingResponse>
    </s:Body>
</s:Envelope>
```
