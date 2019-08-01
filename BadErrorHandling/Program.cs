using System;

namespace BadErrorHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Error_None();
            Error_Pointless();
            Error_NoBubble();
            Error_Hide();
            Error_Mask();
        }

        // no error handling, but at least the exception will bubble up
        static void Error_None()
        {

            FlakeyService.DoEverything();

            // todo error handling

        }

        // pointless, but at least the exception bubbles up
        static void Error_Pointless()
        {
            try
            {
                FlakeyService.DoEverything();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // they'll know something bad happened, but not what it was
        static bool Error_NoBubble()
        {
            var success = true;
            try
            {
                FlakeyService.DoEverything();
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

        // catch and hide the error
        static void Error_Hide()
        {
            try
            {
                FlakeyService.DoEverything();
            }
            catch (Exception ex)
            {
                // todo error handling
            }
        }

        // mask the error with potentially misleading details, 
        // hide the real details
        static string Error_Mask()
        {
            string errorMessage = null;
            try
            {
                FlakeyService.DoEverything();
            }
            catch (Exception ex)
            {
                errorMessage = "Network service failed!";
            }
            return errorMessage;
        }
    }
}
