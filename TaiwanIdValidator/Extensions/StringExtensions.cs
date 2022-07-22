namespace TaiwanIdValidator.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Verify the input is a valid GUI Number (中華民國統一編號)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsGuiNumberValid(this string input)
    {
        return false;
    }

    /// <summary>
    /// Verify the input is a valid National identification number (中華民國身分證字號)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsNationalIdentificationNumberValid(this string input)
    {
        return VerifyTaiwanIdIntermediateString(input);
    }
    
    /// <summary>
    /// Verify the input is a valid Resident certificate number (舊式外僑及大陸人士在台居留證、旅行證統一證號)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsOriginalResidentCertificateNumberValid(this string input)
    {
        return VerifyTaiwanIdIntermediateString(input);
    }
    
    /// <summary>
    /// Verify the input is a valid citizen digital certificate (自然人憑證)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsCitizenDigitalCertificateValid(this string input)
    {
        return false;
    }
    
    /// <summary>
    /// Verify the input is a valid E-Invoice cell phone barcode (電子發票手機條碼)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsEInvoiceCellPhoneBarcodeValid(this string input)
    {
        return false;
    }
    
    /// <summary>
    /// Verify the input is a valid E-Invoice donate code (電子發票捐贈碼)
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsEInvoiceDonateCodeValid(this string input)
    {
        return false;
    }
    
    /// <summary>
    /// Verify the intermediate string for isNationalIdentificationNumberValid and isResidentCertificateNumberValid
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    private static bool VerifyTaiwanIdIntermediateString(this string input)
    {
        return false;
    }
}