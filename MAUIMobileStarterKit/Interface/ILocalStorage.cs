using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Interface
{
    public interface ILocalStorage
    {
        Task<string> GetAsync(string key);
        void SetAsync(string key, string value);
    }
}
