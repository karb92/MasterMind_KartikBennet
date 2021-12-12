using System;
using System.Text;

namespace MasterMind_KartikBennet
{
    public class Validator: IValidator
    {

        private readonly string _code;

        public string CorrectPattern { get => "++++"; }

        public Validator(string code)
        {
            _code = code;
        }

        

        public string Validate(string guess)
        {
            var builder = new StringBuilder(guess.Length);

            for (int i = 0; i < guess.Length; i++)
            {
                var digit = guess[i];
                if (_code.Contains(digit))
                    builder.Append(_code[i] == digit ? '+': '-');
                else
                    builder.Append(' ');
            }
            return builder.ToString();
        }
    }
}
