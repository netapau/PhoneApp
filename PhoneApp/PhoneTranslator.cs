using System;
using System.Text;

namespace PhoneApp
{
    public class PhoneTranslator
    {
        // LOGIQUE DE L'APP
        string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Numbers = "22233344455566677778889999";
        
        public String ToNumber(string alphanumericPhoneNumber)
        {
            var NumericPhoneNumber = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(alphanumericPhoneNumber))
            {
                alphanumericPhoneNumber = alphanumericPhoneNumber.ToUpper();
                foreach (var c in alphanumericPhoneNumber)
                {
                    if ("0123456789".IndexOf(c) >= 0)
                    {
                        NumericPhoneNumber.Append(c);
                    }
                    else
                    {
                        var Index = Letters.IndexOf(c);
                        if (Index >= 0)
                        {
                            NumericPhoneNumber.Append(Numbers[Index]);
                        }
                    }
                }
            }
            return NumericPhoneNumber.ToString();
        }

        public PhoneTranslator()
        {
        }
    }
}