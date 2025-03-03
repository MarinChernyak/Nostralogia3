using System.Collections.Generic;

namespace Nostralogia3.Common
{

    public class ErrMessagesCollection
    {
        public enum Errors
        {
            NoErrors = 0,
            DataExisting,
            IndexArrBiggerSizeOfCollection,
            DB_Exception
        }
        protected void SettErrosCollection()
        {
            ErrMesasges.Add("No errors found");
            ErrMesasges.Add("This data is already Existing");
            ErrMesasges.Add("Index is bigger than a size of anarray");
            ErrMesasges.Add("Datbase exception. See log file for details");

        }
        protected List<string> ErrMesasges = new List<string>();
        public ErrMessagesCollection()
        {
            SettErrosCollection();
        }

        public string GetMessage(Errors err)
        {
            int index = (int)err;
            return ErrMesasges[index];           
        }
        public string GetMessage(int err)
        {
            if(err>= ErrMesasges.Count)
            {
                return ErrMesasges[(int)Errors.IndexArrBiggerSizeOfCollection];
            }            
            return ErrMesasges[err];
        }
    }
}
