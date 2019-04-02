/**
 * Verify the input is a valid GUI Number (中華民國統一編號)
 * 規則:
 * Step 1: 把統一編號的每個數字分別乘上對應的係數 (1, 2, 1, 2, 1, 2, 4, 1)
 * Step 2: 把個別乘積的十位數與個位數相加，得出八個小於 10 的數字
 * Step 3: 檢查把這 8 個數字相加之後計算此和除以 10 的餘數
 * Step 4:
 *  4-1: 若是餘數為 0，則為正確的統一編號
 *  4-2: 若是餘數為 9，且原統一編號的第七位是 7，則也為正確的統一編號
 *
 * 範例: 12345675
 * Step 1:
 * 1 * 1 = 1
 * 2 * 2 = 4
 * 3 * 1 = 3
 * 4 * 2 = 8
 * 5 * 1 = 5
 * 6 * 2 = 12
 * 7 * 4 = 28
 * 5 * 1 = 5
 *
 * Step 2:
 * 1 -> 1
 * 4 -> 4
 * 3 -> 3
 * 8 -> 8
 * 5 -> 5
 * 12 -> 1 + 2 = 3
 * 28 -> 2 + 8 = 10
 * 5 -> 5
 *
 * Step 3:
 * (1 + 4 + 3 + 8 + 5 + 3 + 10 + 5) % 10 = 9
 *
 * @param { string | number } input GUI Number
 * @returns { boolean }
 */
export function isGuiNumberValid(input: string | number): boolean {
  const GUI_NUMBER_COEFFICIENTS = [1, 2, 1, 2, 1, 2, 4, 1]

  try {
    const n = input.toString()
    const regex: RegExp = /^\d{8}$/

    if (!regex.test(n)) {
      throw new Error('GUI number should be a 8-digit string.')
    }

    const checksum = GUI_NUMBER_COEFFICIENTS.reduce((sum, c, index) => {
      const product = c * parseInt(n.charAt(index), 10) // Step 1
      return sum + (product % 10) + Math.floor(product / 10) // Step 2
    }, 0)

    if (
      // Step 3 & Step 4
      checksum % 10 === 0 ||
      (parseInt(n.charAt(6), 10) === 7 && (checksum + 1) % 10 === 0)
    ) {
      return true
    }

    return false
  } catch (e) {
    console.error(e.message)
    return false
  }
}

/**
 *  Verify the input is a valid National Identification Number (中華民國身分證字號)
 *  A=10 台北市     J=18 新竹縣     S=26 高雄縣
 *  B=11 台中市     K=19 苗栗縣     T=27 屏東縣
 *  C=12 基隆市     L=20 台中縣     U=28 花蓮縣
 *  D=13 台南市     M=21 南投縣     V=29 台東縣
 *  E=14 高雄市     N=22 彰化縣     W=32 金門縣*
 *  F=15 台北縣     O=35 新竹市*    X=30 澎湖縣
 *  G=16 宜蘭縣     P=23 雲林縣     Y=31 陽明山
 *  H=17 桃園縣     Q=24 嘉義縣     Z=33 連江縣*
 *  I=34 嘉義市*    R=25 台南縣
 *
 * @param { string } input National Identification Number
 * @returns { boolean }
 */
export function isNationalIdentificationNumberValid(input: string): boolean {
  const ALPHABET_CODE_LIST = [
    1, // A
    10, // B
    19, // C
    28, // D
    37, // E
    46, // F
    55, // G
    64, // H
    39, // I
    73, // J
    82, // K
    2, // L
    11, // M
    20, // N
    48, // O
    29, // P
    38, // Q
    47, // R
    56, // S
    65, // T
    74, // U
    83, // V
    21, // W
    3, // X
    12, // Y
    30 // Z
  ]

  try {
    const regex: RegExp = /^[A-Z][1,2]\d{8}$/

    if (!regex.test(input)) {
      throw new Error('National Identification number format incorrect.')
    }

    const result =
      ALPHABET_CODE_LIST[input.charCodeAt(0) - 65] +
      [8, 7, 6, 5, 4, 3, 2, 1].reduce(
        (sum: number, coefficient: number, index: number) =>
          sum + coefficient * parseInt(input.charAt(index + 1), 10), // Σ coefficient * digit
        0
      ) +
      parseInt(input.charAt(9), 10)

    if (result % 10 === 0) {
      return true
    }
    return false
  } catch (e) {
    console.error(e.message)
    return false
  }
}

/**
 * Verify the input is a valid citizen digital certificate (自然人憑證)
 * 驗證規則為兩碼英文 + 14 碼數字
 * @param { string | number } input citizen digital certificate
 * @returns { boolean }
 */
export function isCitizenDigitalCertificateValid(input: string): boolean {
  try {
    const n = input.toString()
    const regex: RegExp = /^[A-Z]{2}\d{14}$/

    if (!regex.test(n)) {
      throw new Error('Citizen digital certificate format incorrect.')
    }

    return true
  } catch (e) {
    console.error(e.message)
    return false
  }
}
