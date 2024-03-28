using PlaySound;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Adventure Circuit";
        double ticket_price = 1500;
        double summary_individuals = 0;
        double summary_passports = 0;
        double summary_people = 0;
        double summary_earnings = 0;
        double summary_earnings_individuals = 0;
        double summary_earnings_passports = 0;
        double summary_people_paassports = 0;
        double summary_people_10_15 = 0;
        double summary_average_age;
        double summary_age_accumulator = 0;

        do
        {
            Console.CursorVisible = false;
            PrintMenu.MainMenu();
            bool end_process = false;
            double passport_members = 0;
            double passport_members_counter = 0;

            char pressed_key = Console.ReadKey(true).KeyChar;
            switch (pressed_key)
            {
                // Individual entry
                case '1':
                    PrintMenu.IndividualEntry();

                    do
                    {
                        TextFormat.TextFormat.Format(
                            "\n\n\nAge: ",
                            ConsoleColor.White, ConsoleColor.Black,
                            "left", "top");
                        double age;
                        if (double.TryParse(Console.ReadLine(), out age))
                        {
                            if (age != 0)
                            {
                                if (age > 180)
                                {
                                    Console.CursorVisible = false;
                                    Console.Clear();
                                    TextFormat.TextFormat.Format(
                                        "The provided data is invalid. Please try again.",
                                        ConsoleColor.Red, ConsoleColor.Black,
                                        "center", "center");
                                    Console.ResetColor();
                                    PlaySound.PlaySound.ErrorSound();
                                    TextFormat.TextFormat.Format(
                                        "Press any key to continue...",
                                        ConsoleColor.Gray, ConsoleColor.Black,
                                        "center", "bottom");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    PrintMenu.IndividualEntry();
                                }
                                else if (age >= 16)
                                {
                                    Console.Clear();
                                    PrintTicket.PrintTicket.Ticket(1, ticket_price);
                                    PlaySound.PlaySound.SuccessfulSound();
                                    TextFormat.TextFormat.Format(
                                        "Press any key to continue...",
                                        ConsoleColor.Gray, ConsoleColor.Black,
                                        "center", "bottom");

                                    summary_earnings += ticket_price;
                                    summary_earnings_individuals += 1500;
                                    summary_individuals += 1;
                                    summary_age_accumulator += age;
                                    summary_people += 1;

                                    Console.ReadKey(true);
                                    end_process = true;
                                }
                                else
                                {
                                    Console.CursorVisible = false;
                                    Console.Clear();
                                    TextFormat.TextFormat.Format(
                                        "You cannot enter becasue you are under 16 years old.",
                                        ConsoleColor.Red, ConsoleColor.Black,
                                        "center", "center");
                                    Console.ResetColor();
                                    PlaySound.PlaySound.ErrorSound();
                                    TextFormat.TextFormat.Format(
                                        "Press any key to continue...",
                                        ConsoleColor.Gray, ConsoleColor.Black,
                                        "center", "bottom");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                    PrintMenu.IndividualEntry();
                                }
                            }
                            else
                            {
                                end_process = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("The provided data is invalid. Please try again.");
                        }
                    } while (end_process == false);
                    break;

                // Group entry
                case '2':
                    do
                    {
                        PrintMenu.PassportEntry();
                        TextFormat.TextFormat.Format(
                            "\n\nMembers in the group (4 to 10): ",
                            ConsoleColor.White, ConsoleColor.Black,
                            "left", "top");
                        
                        if (double.TryParse(Console.ReadLine(), out passport_members))
                        {
                            if (passport_members == 0)
                            {
                                end_process = true;
                            }

                            else
                            {
                                if (passport_members < 4 || passport_members > 10)
                                {
                                    Console.CursorVisible = false;
                                    Console.Clear();
                                    TextFormat.TextFormat.Format(
                                        "The number of members entered is invalid. It must be within a range of 4 to 10. Please try again.",
                                        ConsoleColor.Red, ConsoleColor.Black,
                                        "center", "center");
                                    PlaySound.PlaySound.ErrorSound();
                                    TextFormat.TextFormat.Format(
                                        "Press any key to continue...",
                                        ConsoleColor.Gray, ConsoleColor.Black,
                                        "center", "bottom");
                                    Console.ReadKey(true);
                                    Console.Clear();
                                }

                                else
                                {
                                    double people = 0;
                                    double minors = 0;
                                    double adults = 0;
                                    double age_0_3 = 0;
                                    double acumulator_ages = 0;
                                    double age_4_10 = 0;
                                    double age_11_15 = 0;
                                    double people_10_15 = 0;
                                    double responsible_adults = 0;
                                    double passport_price = 0;
                                    bool finish_process = false;

                                    do
                                    {
                                        finish_process = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format(
                                            $"\n\n\n\nNext, enter the ages of the {passport_members} members of the group: ",
                                            ConsoleColor.White, ConsoleColor.Black,
                                            "left", "top");
                                        Console.WriteLine();
                                        TextFormat.TextFormat.Format(
                                            $"\n\n\n\n\n{passport_members_counter + 1}° age: ",
                                            ConsoleColor.White, ConsoleColor.Black,
                                            "left", "top");
                                        if (double.TryParse(Console.ReadLine(), out double age))
                                        {
                                            passport_members_counter++;
                                            if (age != 0)
                                            {
                                                if (age >= 10 && age <= 15)
                                                {
                                                    people_10_15++;
                                                }

                                                if (age >= 21)
                                                {
                                                    responsible_adults++;
                                                }

                                                if (age > 0 && age <= 3)
                                                {
                                                    people++;
                                                    age_0_3++;
                                                    acumulator_ages += age;
                                                    minors++;
                                                }
                                                else if (age >= 4 && age <= 10)
                                                {
                                                    people++;
                                                    age_4_10++;
                                                    acumulator_ages += age;
                                                    minors++;
                                                }
                                                else if (age >= 11 && age <= 15)
                                                {
                                                    people++;
                                                    age_11_15++;
                                                    acumulator_ages += age;
                                                    minors++;
                                                }
                                                else if (age > 15 && age <= 180)
                                                {
                                                    people++;
                                                    acumulator_ages += age;
                                                    adults++;
                                                }

                                                else
                                                {
                                                    Console.CursorVisible = false;
                                                    Console.Clear();
                                                    passport_members_counter = 0;
                                                    TextFormat.TextFormat.Format(
                                                        "The provided age is invalid. Please try again.",
                                                        ConsoleColor.Red, ConsoleColor.Black,
                                                        "center", "center");
                                                    PlaySound.PlaySound.ErrorSound();
                                                    TextFormat.TextFormat.Format(
                                                        "Press any key to continue...",
                                                        ConsoleColor.Gray, ConsoleColor.Black,
                                                        "center", "bottom");
                                                    Console.ReadKey(true);
                                                    Console.Clear();
                                                    finish_process = true;
                                                }
                                            }

                                            else
                                            {
                                                Console.CursorVisible = false;
                                                Console.Clear();
                                                passport_members_counter = 0;
                                                TextFormat.TextFormat.Format(
                                                    "The provided age is invalid. Please try again.",
                                                    ConsoleColor.Red, ConsoleColor.Black,
                                                    "center", "center");
                                                PlaySound.PlaySound.ErrorSound();
                                                TextFormat.TextFormat.Format(
                                                    "Press any key to continue...",
                                                    ConsoleColor.Gray, ConsoleColor.Black,
                                                    "center", "bottom");
                                                Console.ReadKey(true);
                                                Console.Clear();
                                                finish_process = true;
                                            }
                                        }

                                        else
                                        {
                                            Console.CursorVisible = false;
                                            Console.Clear();
                                            passport_members_counter = 0;
                                            TextFormat.TextFormat.Format("The provided data is invalid. Please try again.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                                            PlaySound.PlaySound.ErrorSound();
                                            TextFormat.TextFormat.Format("Press any key to continue...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                            Console.ReadKey(true);
                                            Console.Clear();
                                            finish_process = true;
                                        }
                                    } while (passport_members_counter != passport_members || finish_process == true);

                                    passport_price += (age_0_3 * (ticket_price * 0.10));
                                    passport_price += (age_4_10 * (ticket_price * 0.50) * 0.85);
                                    passport_price += (age_11_15 * (ticket_price * 0.80) * 0.85);
                                    passport_price += ((adults * ticket_price) * 0.85);
                                    ticket_price = passport_price;

                                    if (responsible_adults == 0 & minors != 0)
                                    {
                                        end_process = true;
                                        Console.CursorVisible = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format(
                                            $"Sorry, we cannot issue this passport because there are no adults aged 21 or more.",
                                            ConsoleColor.Red, ConsoleColor.Black,
                                            "center", "center");
                                        PlaySound.PlaySound.ErrorSound();
                                        TextFormat.TextFormat.Format(
                                            "Press any key to continue...",
                                            ConsoleColor.Gray, ConsoleColor.Black,
                                            "center", "bottom");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        end_process = true;
                                    }

                                    else if ((minors > 0 & minors <= 5) & responsible_adults < 1)
                                    {
                                        end_process = true;
                                        Console.CursorVisible = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format(
                                            $"Sorry, we cannot issue this passport because there are no adults aged 21 or more.", 
                                            ConsoleColor.Red, ConsoleColor.Black,
                                            "center", "center");
                                        PlaySound.PlaySound.ErrorSound();
                                        TextFormat.TextFormat.Format(
                                            "Press any key to continue...",
                                            ConsoleColor.Gray, ConsoleColor.Black,
                                            "center", "bottom");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        end_process = true;
                                    }

                                    else if ((minors >= 6 & minors <= 10) & responsible_adults < 2)
                                    {
                                        end_process = true;
                                        Console.CursorVisible = false;
                                        Console.Clear();
                                        TextFormat.TextFormat.Format(
                                            $"Sorry, we cannot issue this passport because there are no adults aged 21 or more.",
                                            ConsoleColor.Red, ConsoleColor.Black,
                                            "center", "center");
                                        PlaySound.PlaySound.ErrorSound();
                                        TextFormat.TextFormat.Format(
                                            "Press any key to continue...",
                                            ConsoleColor.Gray, ConsoleColor.Black,
                                            "center", "bottom");
                                        Console.ReadKey(true);
                                        Console.Clear();
                                        end_process = true;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        TextFormat.TextFormat.Format($"Would you like to purchase the group passport for ${passport_price}? (y/n)", ConsoleColor.Yellow, ConsoleColor.Black, "center", "center");

                                        do
                                        {
                                            pressed_key = char.ToLower(Console.ReadKey(true).KeyChar);

                                            switch (pressed_key)
                                            {
                                                case 'y':
                                                    summary_people += people;
                                                    summary_people_10_15 += people_10_15;
                                                    summary_earnings_passports += passport_price;
                                                    summary_earnings += passport_price;
                                                    summary_people_paassports += people;
                                                    summary_passports++;
                                                    summary_age_accumulator += acumulator_ages;
                                                    passport_members_counter = 0;
                                                    Console.Clear();
                                                    PrintTicket.PrintTicket.Ticket(2, ticket_price);
                                                    PlaySound.PlaySound.SuccessfulSound();
                                                    TextFormat.TextFormat.Format("Press any key to continue...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                                                    Console.ReadKey();
                                                    end_process = true;
                                                    break;

                                                case 'n':
                                                    passport_members_counter = 0;
                                                    end_process = true;
                                                    break;

                                                default:
                                                    break;
                                            }
                                        } while (end_process == false);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.CursorVisible = false;
                            Console.Clear();
                            TextFormat.TextFormat.Format("The provided data is invalid. Please try again.", ConsoleColor.Red, ConsoleColor.Black, "center", "center");
                            Console.ResetColor();
                            PlaySound.PlaySound.ErrorSound();
                            TextFormat.TextFormat.Format("Press any key to continue...", ConsoleColor.Gray, ConsoleColor.Black, "center", "bottom");
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                    } while (end_process == false);
                    break;

                // Close program
                case '3':
                    
                    if (summary_people == 0)
                    {
                        summary_average_age = 0;
                    }
                    else
                    {
                        summary_average_age = summary_age_accumulator / summary_people;
                    }
                    
                    Console.Clear();
                    TextFormat.TextFormat.Format
                        ($"Total individuals: {summary_individuals} - Total groups: {summary_passports} - Total people: {summary_people}\nRevenue: with Passports: ${summary_earnings_passports:F2} | Individuals: ${summary_earnings_individuals:F2} Total: ${summary_earnings:F2}\nPeople with passport: {summary_people_paassports} - People between 10 and 15: {summary_people_10_15}\nAverage age: {summary_average_age:F3}",
                        ConsoleColor.Blue, ConsoleColor.Black,
                        "left", "center");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    TextFormat.TextFormat.Format($"Are you sure you want to close the application? (y/n)", ConsoleColor.Yellow, ConsoleColor.Black, "center", "center");

                    do
                    {
                        pressed_key = char.ToLower(Console.ReadKey(true).KeyChar);

                        switch (pressed_key)
                        {
                            case 'y':
                                    Environment.Exit(0);
                                    break;
                                
                            case 'n':
                                    end_process = true;
                                    break;

                            default:
                                    break;
                        }
                    } while (end_process == false);
                    break;
                }
        } while (true);
    }
}