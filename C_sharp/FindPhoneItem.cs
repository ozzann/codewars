/*
Source: http://www.codewars.com/kata/56baeae7022c16dd7400086e

Description:
John keeps a backup of his old personal phone book as a text file. 
On each line of the file he can find the phone number 
(formated as +X-abc-def-ghij where X stands for one or two digits), 
the corresponding name between < and > and the address.
Unfortunately everything is mixed, things are not always in the same order, 
lines are cluttered with non-alpha-numeric characters like
"/+1-541-754-3010 156 Alphand_St. <J Steeve>\n".

The goal: given the lines of his phone book and a phone number 
returns a string for this number :
"Phone => num, Name => name, Address => adress".

It can happen that, for a few phone numbers, there are many people 
for a phone number -say nb- , then return : "Error => Too many people: nb"
or it can happen that the number nb is not in the phone book, in that case
return: "Error => Not found: nb"

Examples:
s = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, 
Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010!\n";

Phone(s, "1-541-754-3010") should return 
"Phone => 1-541-754-3010, Name => J Steeve, Address => 156 Alphand St."

*/



using System;
using System.Text.RegularExpressions;

namespace FindPhoneItem
{
    class Program
    {
        static void Main(string[] args)
        {
            string phoneNumber = "1-121-544-8974";

            String phoneBook = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
    + "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
    + "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
    + "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
    + "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
    + "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
    + "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
    + "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
    + "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.  Eldorado\n"
    + "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
    + "<P Salinge> Main Street, +1-098-512-2222, Denve\n" + "<P Salinge> Main Street, +1-098-512-2222, Denve\n";

            string result = Phone(phoneBook, phoneNumber);
            Console.WriteLine(result);

            Console.ReadLine();
        }


        public static string Phone(string phoneBook, string phoneNumber)
        {
            string correctPhoneItem = "";
            string[] phones = phoneBook.Split('\n');

            int pos = 0;
            int matchesCounter = 0;
            while (matchesCounter <= 2 && pos < phones.Length)
            {
                // First: find phone number by pattern
                string phoneItem = phones[pos];
                string phonePattern = @"\+" + phoneNumber + @"([^0-9]{1}|$)";
                Regex phoneRegexp = new Regex(phonePattern);
                bool isMatch = phoneRegexp.IsMatch(phoneItem);

                // So, the phone number has been found
                if ( isMatch )
                {
                    // erase phone part from string
                    phonePattern = @"\+" + phoneNumber;
                    Regex rgxPhone = new Regex(phonePattern);
                    phoneItem = rgxPhone.Replace(phoneItem, "");

                    // Now looking for person name in the string...
                    string namePattern = @"<.*>";
                    Match nameMatch = Regex.Match(phoneItem, namePattern);
                    string name = nameMatch.Value;

                    // remove brackets(<>) to get extinct person name
                    string bracketsPattern = @"[<>]+";
                    Regex brackets = new Regex(bracketsPattern);
                    name = brackets.Replace(name, "");

                    // erase name part from string
                    Regex rgxName = new Regex(namePattern);
                    phoneItem = rgxName.Replace(phoneItem, "");

                    // When name and phone parts are erased string contains only adress part
                    string nonAdressPattern = @"[\\_\*&\?|/\)\(\+:;\$]+";
                    Regex nonAdress = new Regex(nonAdressPattern);
                    phoneItem = nonAdress.Replace(phoneItem, " ");

                    // Remove redundant space symbols
                    // 1) from the left side
                    string ltrimPattern = @"^\s*";
                    Regex ltrim = new Regex(ltrimPattern);
                    phoneItem = ltrim.Replace(phoneItem, "");

                    // 2) from the right side
                    string rtrimPattern = @"\s*$";
                    Regex rtrim = new Regex(rtrimPattern);
                    phoneItem = rtrim.Replace(phoneItem, "");

                    // 3) remove space duplicates
                    string trimPattern = @"\s{2,}";
                    Regex trim = new Regex(trimPattern);
                    phoneItem = trim.Replace(phoneItem, " ");
                    string address = phoneItem;

                    // Here is the correct information for particular phone number
                    correctPhoneItem = "Phone => " + phoneNumber +
                        ", Name => " + name +
                        ", Address => " + address;

                    matchesCounter++;
                }
                pos++;
            }

            if (matchesCounter == 1)
            {
                return correctPhoneItem;
            }
            else if (matchesCounter > 1)
            {
                // if there are more than one matches for a phone number
                // the function should return error
                return "Error => Too many people: " + phoneNumber;
            }
            else
            {
                return "Error => Not found: " + phoneNumber;
            }
        }
    }
}
