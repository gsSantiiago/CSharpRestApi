using System;
using System.Threading.Tasks;

namespace CSharpRestApi.ViewModels
{
    public class RecyclerViewModel
    {
        public string Status { get; set; }
    }

    public class RecyclerTaskViewModel
    {
        private static Task _RecyclerTask;

        public static Task RecyclerTask
        {
            get
            {
                return _RecyclerTask;
            }
            set
            {
                _RecyclerTask = value;
            }
        }
    }
}
