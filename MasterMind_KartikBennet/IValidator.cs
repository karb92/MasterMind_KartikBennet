using System;
namespace MasterMind_KartikBennet
{
    public interface IValidator
    {
        public string CorrectPattern { get; }
        public string Validate(string guess);
        
    }
}
