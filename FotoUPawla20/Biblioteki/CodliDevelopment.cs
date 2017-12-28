using System.IO;
using System;
using Microsoft.Win32;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Net;
using System.Net.Mail;

namespace CodliDevelopment
{
    static class WriteText
    {
        public static void LineByLine(string[] lines, string path)
        {
            int Conte = 0;

            using (StreamWriter CT = File.CreateText(path))
            {
                foreach (string Element in lines)
                {
                    if (Conte != lines.Length - 1)
                        CT.WriteLine(Element);
                    else
                        CT.Write(Element);

                    Conte++;
                }
            }
        }

        public static void AddLinesToExistingFile(string[] lines, string path)
        {
            File.AppendAllLines(path, lines);
        }

        public static void AddTextToExistingFile(string Text, string path)
        {
            File.AppendAllText(path, Text);
        }

        public static void Simple(string text, string path)
        {
            using (StreamWriter CT = File.CreateText(path))
            {
                CT.Write(text.Replace("\r", null));
            }
        }
    }
    static class FileStatus
    {
        public static bool IsUsed(FileInfo FilePath)
        {
            FileStream stream = null;

            try
            {
                stream = FilePath.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //Plik jest nieużywany przez nic innego.
            return false;
        }
    }
    static class ChangeCharSize
    {
        public static char GetBigFromString(string abc)
        {
            if (char.IsUpper(abc[0]) == true)
                return abc[0];
            else
                return char.ToUpper(abc[0]);
        }

        public static char GetSmallFromString(string abc)
        {
            if (char.IsLower(abc[0]) == true)
                return abc[0];
            else
                return char.ToLower(abc[0]);
        }

        public static bool IsFirstLetterBig(string abc)
        {
            if (char.IsUpper(abc[0]) == true)
                return true;
            else
                return false;
        }
    }
    static class Endecoder
    {
        public static int Duration(string LicenseType)
        {
            string Typ = String.Empty;

            if (LicenseType.Contains("Type=") == true)
                Typ = LicenseType.Replace("Type=", null);
            else
                Typ = LicenseType;

            switch (Typ)
            {
                case "A":
                    return 3;
                case "F":
                    return 7;
                case "5":
                    return 14;
                case "G":
                    return 30;
                case "X":
                    return 60;

                default:
                    return 0;
            }
        }
    }
    static class TimeX
    {
        public static string GetCurrentDay()
        {
            return string.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        public static string GetCurrentTime()
        {
            return string.Format("{0:dd-MM-yyyy_hh-mm-ss-tt}", DateTime.Now);
        }

        public enum DaysInMonth
        {
            January = 31,
            Febuary = 28,
            March = 31,
            April = 30,
            May = 31,
            June = 30,
            July = 31,
            August = 31,
            September = 30,
            October = 31,
            November = 30,
            December = 31
        }

        public static DateTime IntToDate(int data)
        {
            string Conte = data.ToString();
            string r = Conte[0].ToString() + Conte[1].ToString() + Conte[2].ToString() + Conte[3].ToString();
            string m = Conte[4].ToString() + Conte[5].ToString();
            string d = Conte[6].ToString() + Conte[7].ToString();

            return new DateTime(int.Parse(r), int.Parse(m), int.Parse(d));
        }

        public static string DateToSmartString(DateTime Data)
        {
            string ToReturn = Data.Day.ToString();
            ToReturn += " ";

            switch (Data.Month)
            {
                case 1:
                    ToReturn += "Styczeń";
                    break;

                case 2:
                    ToReturn += "Luty";
                    break;

                case 3:
                    ToReturn += "Marzec";
                    break;

                case 4:
                    ToReturn += "Kwiecień";
                    break;

                case 5:
                    ToReturn += "Maj";
                    break;

                case 6:
                    ToReturn += "Czerwiec";
                    break;

                case 7:
                    ToReturn += "Lipiec";
                    break;

                case 8:
                    ToReturn += "Sierpień";
                    break;

                case 9:
                    ToReturn += "Wrzesień";
                    break;

                case 10:
                    ToReturn += "Październik";
                    break;

                case 11:
                    ToReturn += "Listopad";
                    break;

                case 12:
                    ToReturn += "Grudzień";
                    break;
            }

            ToReturn += " ";
            ToReturn += Data.Year.ToString();

            return ToReturn;
        }

        public static string IntDateToSmartString(int Data)
        {
            var date = IntToDate(Data);

            return DateToSmartString(date);
        }

        public static int DateToInt(DateTime data)
        {
            return int.Parse(data.ToString("yyyyMMdd"));
        }

        public static string DateIntToReadableString(int data)
        {
            string cache = data.ToString();
            char[] Array = cache.ToCharArray();
            string ToReturn = String.Empty;

            if (Array[6] != '0')
                ToReturn += Array[6];

            ToReturn += Array[7];
            ToReturn += " ";

            cache = Array[4].ToString() + Array[5].ToString();
            int month = int.Parse(cache);

            ToReturn += MonthNumToName(month);
            ToReturn += " ";

            ToReturn += Array[0].ToString() + Array[1].ToString() + Array[2].ToString() + Array[3].ToString();

            return ToReturn;
        }

        public static string MonthNumToName(int numer)
        {
            switch (numer)
            {
                case 1:
                    return "Styczeń";

                case 2:
                    return "Luty";

                case 3:
                    return "Marzec";

                case 4:
                    return "Kwiecień";

                case 5:
                    return "Maj";

                case 6:
                    return "Czerwiec";

                case 7:
                    return "Lipiec";

                case 8:
                    return "Sierpień";

                case 9:
                    return "Wrzesień";

                case 10:
                    return "Październik";

                case 11:
                    return "Listopad";

                case 12:
                    return "Grudzień";

                default:
                    return "Invalid";
            }
        }

        public static string[] LastCurrentNextMonth(int CurrentMonthNum)
        {
            string[] ToReturn = new string[3];

            if (CurrentMonthNum == 12)
            {
                ToReturn[0] = "11";
                ToReturn[1] = "12";
                ToReturn[2] = "01";

                return ToReturn;
            }

            if (CurrentMonthNum == 1)
            {
                ToReturn[0] = "12";
                ToReturn[1] = "01";
                ToReturn[2] = "02";

                return ToReturn;
            }

            int Conte = 0;

            int[] integer = new int[3];
            integer[0] = CurrentMonthNum - 1;
            integer[1] = CurrentMonthNum;
            integer[2] = CurrentMonthNum + 1;

            while (Conte != 3)
            {
                ToReturn[Conte] = integer[Conte].ToString();

                if (ToReturn[Conte].Length == 1)
                    ToReturn[Conte] = "0" + ToReturn[Conte];

                Conte++;
            }

            return ToReturn;
        }

        public static string IntToShortString(int SeesHardDate)
        {
            var data = IntToDate(SeesHardDate);

            return data.Day + "-" + data.Month + "-" + data.Year;
        }
    }
    static class VariableX
    {
        public static string[] SplitStringByString(string VariableToSplit, string KeyVariable)
        {
            return VariableToSplit.Split(new string[] { KeyVariable }, StringSplitOptions.None);
            /*
            //Obliczanie współczynnika pętli
            int Granica = KeyVariable.Length - 1;
            Granica = VariableToSplit.Length - Granica;

            //Tablica którą zwróci nasza metoda
            string[] EndArray = new string[0];
            string TemporarryS = String.Empty; //Ciąg pomocniczy

            //Pętla while
            int Conte = 0; //Quantyfikator
            int i = 0; //Quantyfikator zagnieżdżony wewnętrznie
            char[] Znaki = KeyVariable.ToCharArray();
            char[] MiniArray = new char[KeyVariable.Length];

            while (Conte != Granica)
            {
                //Generator tablicy znaków o rozmiarze zmiennej kluczowej
                while (i != KeyVariable.Length)
                {
                    MiniArray[i] = VariableToSplit[Conte + i];
                    i++;
                }

                //Porównywarka wygenerowanej tablicy znaków z zmienną kluczową
                i = 0; //Zerowanie quantyfikatora i, aby mógł zostać ponownie użyty.
                bool Wariograf = true;
                foreach (char E in Znaki)
                {
                    if (E != MiniArray[i])
                    {
                        Wariograf = false;
                        break;
                    }

                    i++;
                }

                i = 0; //Znów resetujemy stan quantyfikatora

                //Okazało się że znaleziono słowo klucz, więc teraz trzeba podzielić
                if (Wariograf == true)
                {
                    //Resetowanie zmiennej pomocniczej
                    TemporarryS = String.Empty;

                    while (i != Conte)
                    {
                        TemporarryS += VariableToSplit[i];
                        i++;
                    }

                    //Usuwanie z naszej zmiennej do podzielenia już podzielonych wyrazów;
                    VariableToSplit = VariableToSplit.Replace(TemporarryS + KeyVariable, null);

                    //Zmiana wartości Quantyfikatora pierwszego stopnia oraz zmiennej granicznej
                    Granica = Granica - TemporarryS.Length - KeyVariable.Length;
                    Conte = 0;
                    i = 0;

                    //Dodawanie zmiennej TemporarryS do tablicy wyjściowej
                    Array.Resize(ref EndArray, EndArray.Length + 1);
                    EndArray[EndArray.Length - 1] = TemporarryS;
                }

                Conte++;
            }

            return EndArray;*/
        }

        public static string InkrementujStringa(string liczba)
        {
            if (liczba == null)
                return "1";

            int Courtois = int.Parse(liczba);
            Courtois++;

            return Courtois.ToString();
        }
    }
    static class ConnectionX
    {
        public static bool SendEmailViaGoogle(string Login, string Password, string ReciverMail, string Message, string Subject)
        {
            string email = Login;
            string password = Password;
            try
            {
                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);

                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(ReciverMail));
                msg.Subject = Subject;
                msg.Body = Message;
                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
            }

            catch
            {
                return false;
            }

            return true;
        }
    }
}
