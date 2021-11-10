using System;
namespace DOTR.QLess.Domain.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
        public RecordNotFoundException(string name, string searchKey,string searchValue)
           : base($"Entity \"{name}\" with search key ({searchKey}), search value ({searchValue}) was not found.")
        {
        }
    }
}
