using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectBaseCore.Database
{
    public class CommandStringProcessor
    {
        /// <summary>
        /// Parameter character that is used by specific database.
        /// </summary>
        public char DbBasedParameterCharacter { get; set; }

        /// <summary>
        /// List of parameter characters that are used by all databases.
        /// </summary>
        public List<char> ParameterCharacters { get; set; }

        /// <summary>
        /// Regular expression text to find global parameters.
        /// </summary>
        public string GlobalParameterRegExp { get; set; }

        public CommandStringProcessor()
        {
            ParameterCharacters = new List<char>() { ':', '@', '$' };
            GlobalParameterRegExp = "\\.p\\.\\w";
        }

        public CommandStringProcessor(char dbBasedParameterCharacter)
        {
            ParameterCharacters = new List<char>() { ':', '@', '$' };
            GlobalParameterRegExp = "\\.p\\.\\w";
            DbBasedParameterCharacter = dbBasedParameterCharacter;
        }

        /// <summary>
        /// Produces processable Command text from raw Command text that includes global parameter definitions.
        /// </summary>
        public string GetPreparedGlobalCommandString(string CommandString)
        {
            StringBuilder sbuilder = new StringBuilder(CommandString);

            Regex rex = new Regex(GlobalParameterRegExp);
            MatchCollection mcol = rex.Matches(CommandString);

            foreach (Match item in mcol)
            {
                sbuilder[item.Index] = ' ';
                sbuilder[item.Index + 1] = ' ';
                sbuilder[item.Index + 2] = DbBasedParameterCharacter;
            }

            return sbuilder.ToString();
        }

        /// <summary>
        /// Produces database specific processable Command text from raw Command text that includes database based parameter definitions.
        /// </summary>
        public string GetPreparedLocalCommandString(string CommandString)
        {
            StringBuilder result = new StringBuilder(CommandString);

            for (int i = 0; i < result.Length; i++)
            {
                foreach (char c in ParameterCharacters)
                {
                    if(result[i] == c)
                    {
                        result[i] = DbBasedParameterCharacter;
                    }
                }
            }
            
            return result.ToString();
        }
    }
}
