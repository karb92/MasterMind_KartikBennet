using System;
using System.Text;

namespace MasterMind_KartikBennet
{
    public class Mastermind
    {
        public Mastermind(int num_attemps)
        {
            secretCode = GenerateCode();
            _validator = new Validator(secretCode);
            _attempts = num_attemps;
        }

        private static Random _random = new Random();
        private static int _attempts { get; set; }
        private static string secretCode { get; set; }
        private IValidator _validator;

        private static string GenerateCode(int length = 4,int max_digit = 6)
        {
            var code = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                code.Append(_random.Next(1, max_digit));
            return code.ToString();
        }

        public GameResponse Guess(string guess,int attempt)
        {

            string response = _validator.Validate(guess);
            bool isGameOver = false;
            
            if (response == _validator.CorrectPattern)
            {
                response = $"Congratulations, you won!)";
                isGameOver = true;
            }
             
            if (attempt >= _attempts)
            {
                response = $"Better Luck Next Time! The secret code is {secretCode}";
                isGameOver = true;
            }
            return new GameResponse { Response = response, IsCompleted = isGameOver };
        }
    }
}
