using System;

namespace PrintTicket
{
    internal class PrintTicket
    {

        public static string Today()
        {
            DateTime today = DateTime.Now;
            string formatted_date = (today.ToString("MM-dd-yyyy").Replace('-', '/'));
            return formatted_date;
        }

        public static void Ticket(int entry_type, double entry_price)
        {
            string entry_type_str;

            if (entry_type == 1)
            {
                entry_type_str = "Individual Ticket";
            }
            else if (entry_type == 2)
            {
                entry_type_str = "Passport Ticket";
            }
            else
            {
                entry_type_str = "Ticket";
            }

            string business_name = "ADVENTURE CIRCUIT";
            string business_address = "Filo Serrano, D5881 Merlo, San Luis";
            string business_phone = "+54 266 488-3207";
            string line = new string('*', 47);

            TextFormat.TextFormat.Format(
                $"{business_name}\n{line}\n\nAddress: {business_address}\nPhone: {business_phone}\n\n{line}\n\nPURCHASE RECEIPT\n\n{line}\n\nDescription:               {entry_type_str}\nDate:                             {PrintTicket.Today()}\n\n{line}\nTOTAL ${entry_price:F2}\n{line}\nTHANK YOU VERY MUCH!",
                ConsoleColor.Gray, ConsoleColor.Black,
                horizontalAlignment: "center",
                verticalAlignment: "center"
            );
        }
            
    }
}