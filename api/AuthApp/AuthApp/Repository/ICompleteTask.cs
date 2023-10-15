using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthApp.Repository
{
    interface ICompleteTask
    {
        Task CompleteAsync();
    }
}
