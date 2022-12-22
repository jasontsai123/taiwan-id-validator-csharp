using System.Text.RegularExpressions;

namespace TaiwanIdValidator.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Verify the input is a valid GUI Number (中華民國統一編號)
    /// <para>Step 1: 先把統一編號的每個數字分別乘上對應的係數 (1, 2, 1, 2, 1, 2, 4, 1)</para>
    /// <para>Step 2: 再把個別乘積的十位數與個位數相加，得出八個小於 10 的數字</para>
    /// <para>Step 3: 檢查把這 8 個數字相加之後計算此和除以 5(112年4月以後的規則) or 10 的餘數</para>
    /// <para>
    /// Step 4:
    /// <code>
    ///     4-1: 若是餘數為 0，則為正確的統一編號
    ///     4-2: 若是餘數為 9，且原統一編號的第七位是 7，則也為正確的統一編號
    /// </code>
    /// </para>
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsGuiNumberValid(this string input)
    {
        if (new Regex("^\\d{8}$").IsMatch(input) == false)
        {
            return false;
        }

        var numericalValueArray = input.Select(c => int.Parse(c.ToString())).ToArray();
        // 邏輯乘數
        var multipliers = new List<int> { 1, 2, 1, 2, 1, 2, 4, 1 };
        var checksum = multipliers
            .Select(
                (multiplier, index) =>
                {
                    // 乘積
                    var product = numericalValueArray[index] * multiplier;
                    // 乘積之和
                    return (product % 10) + Math.Floor(product / 10m);
                }
            )
            .Sum();

        // 預計112年4月以後，檢查邏輯由可被『10』整除改為可被『5』整除。
        var divisor = 5;

        // Step 3 & Step 4
        var secondLast = numericalValueArray[6];
        return checksum % divisor == 0 || (secondLast == 7 && (checksum + 1) % divisor == 0);
    }

    /// <summary>
    /// Verify the input is a valid National identification number (中華民國身分證字號)
    /// <para>Step 1: 首碼英文代碼轉換為數值</para>
    /// <para>Step 2: 再把每一個數字依序乘上1、9、8、7、6、5、4、3、2、1、1</para>
    /// <para>Step 3: 套入公式 (n0×1 + n1×9 + n2×8 + n3×7 + n4×6 + n5×5 + n6×4 + n7×3 + n8×2 + n9×1 + n10×1) % 10 = 0</para>
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsNationalIdentificationNumberValid(this string input)
    {
        if (new Regex("^([A-Z]{1})([1,2,8,9]{1})(\\d{8})$").IsMatch(input) == false)
        {
            return false;
        }

        return VerifyTaiwanIdIntermediateString(input);
    }

    /// <summary>
    /// Verify the input is a valid Resident certificate number (外僑及大陸人士在台居留證、旅行證統一證號)
    /// <para>Step 1: 首碼英文代碼轉換為數值，第二位英文字母按上表轉換為對應數值的個位數</para>
    /// <para>Step 2: 再把每一個數字依序乘上1、9、8、7、6、5、4、3、2、1、1</para>
    /// <para>Step 3: 套入公式 (n0×1 + n1×9 + n2×8 + n3×7 + n4×6 + n5×5 + n6×4 + n7×3 + n8×2 + n9×1 + n10×1) % 10 = 0</para>
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsResidentCertificateNumberValid(this string input)
    {
        if (new Regex("^([A-Z])(A|B|C|D|8|9)(\\d{8})$").IsMatch(input) == false)
        {
            return false;
        }

        return VerifyTaiwanIdIntermediateString(input);
    }

    /// <summary>
    /// Verify the input is a valid citizen digital certificate (自然人憑證)
    /// <para>驗證規則為兩碼英文 + 14 碼數字</para>
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsCitizenDigitalCertificateValid(this string input)
    {
        return new Regex("^([A-Z]{2})(\\d{14})$").IsMatch(input);
    }

    /// <summary>
    /// Verify the input is a valid E-Invoice cell phone barcode (電子發票手機條碼)
    /// <para>總長度為 8 碼</para>
    /// <para>第 1 碼為 /</para>
    /// <para>第 2~8 碼由 0~9 (數字), A-Z (大寫英文字母), .(period), -(hyphen), +(plus) 組成</para>
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsEInvoiceCellPhoneBarcodeValid(this string input)
    {
        return new Regex("^\\/[\\dA-Z.\\-+]{7}$").IsMatch(input);
    }

    /// <summary>
    /// Verify the input is a valid E-Invoice donate code (電子發票捐贈碼)
    /// <para>總長度為 3~7 碼 0~9 的數字</para>
    /// </summary>
    /// <param name="input"></param>
    /// <returns>bool</returns>
    public static bool IsEInvoiceDonateCodeValid(this string input)
    {
        return new Regex("^[\\d]{3,7}$").IsMatch(input);
    }

    /// <summary>
    /// 縣市首碼英文代碼的對照表
    /// </summary>
    private static readonly Dictionary<string, string> CityCodeDic = new Dictionary<string, string>()
    {
        { "A", "10" }, // 台北市
        { "B", "11" }, // 台中市
        { "C", "12" }, // 基隆市
        { "D", "13" }, // 台南市
        { "E", "14" }, // 高雄市
        { "F", "15" }, // 新北市
        { "G", "16" }, // 宜蘭縣
        { "H", "17" }, // 桃園市
        { "I", "34" }, // 嘉義市
        { "J", "18" }, // 新竹縣
        { "K", "19" }, // 苗栗縣
        { "M", "21" }, // 南投縣
        { "N", "22" }, // 彰化縣
        { "O", "35" }, // 新竹市
        { "P", "23" }, // 雲林縣
        { "Q", "24" }, // 嘉義縣
        { "T", "27" }, // 屏東縣
        { "U", "28" }, // 花蓮縣
        { "V", "29" }, // 台東縣
        { "W", "32" }, // 金門縣
        { "X", "30" }, // 澎湖縣
        { "Z", "33" }, // 連江縣
        { "L", "20" }, // 台中縣
        { "R", "25" }, // 台南縣
        { "S", "26" }, // 高雄縣
        { "Y", "31" }, // 陽明山管理局
    };

    /// <summary>
    /// 首碼英文代碼等價表
    /// </summary>
    private static readonly Dictionary<char, char> ResidentCertificateNumberDic = new Dictionary<char, char>()
    {
        { 'A', '0' },
        { 'B', '1' },
        { 'C', '2' },
        { 'D', '3' },
        { 'E', '4' },
        { 'F', '5' },
        { 'G', '6' },
        { 'H', '7' },
        { 'I', '4' },
        { 'J', '8' },
        { 'K', '9' },
        { 'L', '0' },
        { 'M', '1' },
        { 'N', '2' },
        { 'O', '5' },
        { 'P', '3' },
        { 'Q', '4' },
        { 'R', '5' },
        { 'S', '6' },
        { 'T', '7' },
        { 'U', '8' },
        { 'V', '9' },
        { 'W', '2' },
        { 'X', '0' },
        { 'Y', '1' },
        { 'Z', '3' },
    };

    /// <summary>
    /// Verify the intermediate string for isNationalIdentificationNumberValid and isResidentCertificateNumberValid
    /// <para>Step 1: 首碼英文代碼轉換為數值，居留證則是第二碼英文代碼也轉為數值</para>
    /// <para>Step 2: 再把每一個數字依序乘上1、9、8、7、6、5、4、3、2、1、1</para>
    /// <para>Step 3: 套入公式 (n0×1 + n1×9 + n2×8 + n3×7 + n4×6 + n5×5 + n6×4 + n7×3 + n8×2 + n9×1 + n10×1) % 10 = 0</para>
    /// </summary>
    /// <param name="id">身分證 or 居留證</param>
    /// <returns>bool</returns>
    private static bool VerifyTaiwanIdIntermediateString(this string id)
    {
        // if is not a number (舊版居留證編號)
        var secondChar = id[1];
        if (int.TryParse(secondChar.ToString(), out _) == false)
        {
            var idArray = id.ToArray();
            idArray[1] = ResidentCertificateNumberDic[secondChar];
            id = string.Join("", idArray);
        }

        var firstEngLetter = id.First().ToString();
        var numericalValueArray = id
            .Replace(firstEngLetter, CityCodeDic[firstEngLetter]) // 首碼英文代碼轉換為縣市對應數值
            .Select(c => int.Parse(c.ToString()))
            .ToArray();

        // 權重表
        var weights = new int[] { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };
        // 套入公式 (n0×1 + n1×9 + n2×8 + n3×7 + n4×6 + n5×5 + n6×4 + n7×3 + n8×2 + n9×1 + n10×1) % 10 = 0
        var result = weights.Select((weight, index) => numericalValueArray[index] * weight).Sum();
        return result % 10 == 0;
    }
}
