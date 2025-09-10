using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusIntroWithIocAndProjRef
{
    // internal, instead of public or private, means other classes in this assembly (project) can use this method, but classes outside of this assembly cannot. Meaning, if another project references this project, it cannot use this class or its methods.
    internal enum VersionToCall
    {
        V1 = 1,
        V2 = 2,
        Unknown = 0
    }

    internal class VersionHandler
    {
        internal static VersionToCall DetermineVersionToCall(string userPrompt, string[]? args = null) // by using the ? here, we can use null as default instead of an empty array.
        {
            var versionToCall = VersionToCall.Unknown;

            // the question mark makes sure args was provided and isn't null before we try to access its Length property.
            // Separately, maybe there is a way we could do this using .Any() instead of comparing length? We'd still need to make sure args isn't null first though.
            // comparable to:
            //   if (args != null && args.Length > 0)
            if (args?.Length > 0)
            {
                versionToCall = ConvertUserInputToVersion(args[0]);
            }

            if (versionToCall == VersionToCall.Unknown)
            {
                versionToCall = GetValidVersionInputFromUser(userPrompt);
            }

            return versionToCall;
        }

        internal static VersionToCall ConvertUserInputToVersion(string? input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                // let's see if the user entered 1, v1, V1, 2, v2, or V2. If they did, return the appropriate enum value. Otherwise, return Unknown.

                if (input ==
                    ((int)VersionToCall.V1).ToString() // this is similar to input == "1", but if we ever change the enum value, this will automatically update too. We're casting the enum to its base value of an int. Then we call ToString() to convert the int to a string for comparison since input from the console is always a string.
                    || string.Equals(input, VersionToCall.V1.ToString(), StringComparison.OrdinalIgnoreCase)) // this part compares the string when the user types 'v' before the version number. We're comparing to the string representation of the enum value and ignoring differences in casing.
                {
                    return VersionToCall.V1;
                }
                else if (input ==
                    ((int)VersionToCall.V2).ToString() // this part compares the string when the user typed an integer only; we grab the backing int value of the enum and convert it to a string for comparison since input from the console is always a string. Just like the V1 part above.
                    || string.Equals(input, VersionToCall.V2.ToString(), StringComparison.OrdinalIgnoreCase)) // similar to input == "v2" || input == "V2", except we're ignoring any potential differences in casing (upper/lower). Just like the V1 part above.
                {
                    return VersionToCall.V2;
                }
            }

            return VersionToCall.Unknown;
        }

        /// <summary>
        /// We know we're going to prompt the user at least once, so we can use a do/while loop instead of a while loop to indicate that.
        /// </summary>
        /// <param name="userPrompt">This will be the prompt displayed to the user.</param>
        /// <returns>The input from the user, after it's confirmed to be valid</returns>
        /// <exception cref="ArgumentException">Thrown if the userPrompt is null or empty</exception>
        internal static VersionToCall GetValidVersionInputFromUser(string userPrompt)
        {
            if (string.IsNullOrWhiteSpace(userPrompt))
            {
                throw new ArgumentException("userPrompt cannot be null, empty, or whitespace.", nameof(userPrompt));
            }

            var userInput = string.Empty;
            var versionToCall = VersionToCall.Unknown;
            var isRetry = false;

            do
            {
                if (isRetry)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                isRetry = true; // unless input is valid, then every subsequent attempt is a retry.

                Console.WriteLine(userPrompt);
                userInput = Console.ReadLine();

                versionToCall = ConvertUserInputToVersion(userInput);

            } while (versionToCall == VersionToCall.Unknown);

            return versionToCall;
        }

        /// <summary>
        /// unused. See the version of this method that uses a do/while loop instead of a while loop.
        /// </summary>
        /// <param name="userPrompt">This will be the prompt displayed to the user.</param>
        /// <returns>The input from the user, after it's confirmed to be valid</returns>
        /// <exception cref="ArgumentException"></exception>
        //internal static VersionToCall GetValidVersionInputFromUserWithWhileInsteadOfDoWhile(string userPrompt)
        //{
        //    if (string.IsNullOrWhiteSpace(userPrompt))
        //    {
        //        throw new ArgumentException("userPrompt cannot be null, empty, or whitespace.", nameof(userPrompt));
        //    }

        //    var versionToCall = VersionToCall.Unknown; // this is the variable we'll return at the end of the method. We update it from within the while loop.
        //    var userInput = string.Empty;
        //    var loopCounter = 0;
        //    while (versionToCall == VersionToCall.Unknown)
        //    {
        //        if (loopCounter > 0)
        //        {
        //            Console.WriteLine("Invalid input. Please try again.");
        //        }
        //        Console.WriteLine(userPrompt);
        //        userInput = Console.ReadLine();
        //        versionToCall = ConvertUserInputToVersion(userInput);

        //        loopCounter++;
        //    } 

        //    return versionToCall; 
        //}
    }
}
