using System;
using CHIS.Core.UnitOfWork;
using CHIS.Core.Domain;


namespace CHIS.Console
{
    class Program
    {
        static void Main(string[] args)
        {

           

            System.Console.WriteLine("Completed");
            System.Console.ReadLine();
        }

        static void CreateAccount()
        {
            using (UnitOfWork work = new UnitOfWork(new hotel_dbContext()))
            {

                var account = new accounts()
                {
                    account_number = "test",
                    account_type_id = 1,
                    address1 = "Test",
                    address2 = "test",
                    alias = "",
                    card_holder = "",
                    card_number = "",
                    city = "",
                    country = "",
                    created = DateTime.Now,
                    created_by = "",
                    created_on = DateTime.Now,
                    credit_card_type = "",
                    credit_limit = 500,
                    postal_code = "",
                    email = "",
                    exp_date = DateTime.Now,
                    fax = "",
                    first_name = "",
                    last_name = "",
                    opening_balance = 0,
                    modified = DateTime.Now,
                    payment_term = 0,
                    phone = "",
                    reg_number = "",
                    reg_number1 = "",
                    reg_number2 = "",
                    remark = "",
                    state = ""

                };

                work.Accounts.Add(account);
                work.Complete();

            }
        }
    }

  
}
