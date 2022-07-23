# taiwan-id-validator-csharp
中華民國統一編號、身分證字號驗證規則

將原作者 [Will 保哥](https://github.com/doggy8088) [taiwan-id-validator2](https://github.com/doggy8088/taiwan-id-validator2) 
及 [enylin](https://github.com/enylin) [taiwan-id-validator](https://github.com/enylin/taiwan-id-validator) 翻寫為C#版本

## Features

* 台灣身分證字號驗證
* 新舊式外來人口統一證號
* 公司統一編號驗證 (112年4月以後更換為新版規則)
* 自然人憑證編號驗證
* 電子發票手機條碼驗證
* 電子發票捐贈碼驗證

## Usage

```csharp
using TaiwanIdValidator.Extensions;

Console.WriteLine("12345675".IsGuiNumberValid()); // 統一編號
Console.WriteLine("A12345678".IsNationalIdentificationNumberValid()); // 身分證字號
Console.WriteLine("AA00000009".IsResidentCertificateNumberValid()); // 居留證編號
Console.WriteLine("AA12345678901234".IsCitizenDigitalCertificateValid()); // 自然人憑證
Console.WriteLine("/U.5+A33".IsEInvoiceCellPhoneBarcodeValid()); // 手機條碼
Console.WriteLine("001".IsEInvoiceDonateCodeValid()); // 捐贈碼

var s = "12345675";

if (s.IsGuiNumberValid())
{
   Console.WriteLine(s + " is a valid GUI Number.");
}
else
{
   Console.WriteLine(s + " is not a valid GUI Number.");
}
```
