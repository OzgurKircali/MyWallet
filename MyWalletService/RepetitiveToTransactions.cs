using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWalletService
{
    public class RepetitiveToTransactions
    {
        Context DbContext = new Context();


        public void Main()
        {


            foreach(RepetitiveTransaction item in DbContext.RepetitiveTransactions)
            {
                if(item.RepetitiveTransactionNextDate == DateTime.Now)
                {

                    Transaction TransactionModel = new Transaction();

                    TransactionModel.Id = item.Id;
                    TransactionModel.AutomaticOrManuelID = 2;
                    TransactionModel.CategoryID = item.CategoryID;
                    TransactionModel.TransactionAmount = item.RepetitiveTransactionAmount;
                    TransactionModel.TransactionDate = DateTime.Now;
                    TransactionModel.TransactionDescription = item.RepetitiveTransactionDescription;
                    TransactionModel.TransactionID = 1;
                    TransactionModel.TypeID = item.TypeID;

                    DbContext.Transactions.Add(TransactionModel);


                    if(item.PeriodTypeID == 1)
                    {
                        item.RepetitiveTransactionNextDate = DateTime.Now.AddDays(item.PeriodAmount);
                    }
                    if (item.PeriodTypeID == 2)
                    {
                        item.RepetitiveTransactionNextDate = DateTime.Now.AddDays(item.PeriodAmount*7);
                    }
                    if (item.PeriodTypeID == 3)
                    {
                        item.RepetitiveTransactionNextDate = DateTime.Now.AddMonths(item.PeriodAmount);
                    }
                    if (item.PeriodTypeID == 4)
                    {
                        item.RepetitiveTransactionNextDate = DateTime.Now.AddYears(item.PeriodAmount);
                    }
                    DbContext.SaveChanges();




                }
            }

        }


      


    }
}
