using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksBoard.TaskBoard.Exceptions;

namespace TaskBoard
{
    public static class ValidationHelper
    {
        public static void ValidateStringLength(string value, int minLength, int maxLength, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{parameterName} cannot be null");
            }

            if (value.Length < minLength || value.Length > maxLength)
            {
                throw new ArgumentOutOfRangeException($"{parameterName} length must be between {minLength} and {maxLength}");
            }
        }

        public static void ValidateNumberOfArguments (int expectedValue, int input)
        {
            if (expectedValue != input)
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {expectedValue}, Received: {input}");
        }
    }
}
