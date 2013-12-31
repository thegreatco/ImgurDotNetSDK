using System.Threading.Tasks;

namespace ImgurDotNetSDK
{
    internal static partial class TaskExtensions
    {
        /// <summary>
        /// Run a task as void, allowing control to return immediately to the application.
        /// </summary>
        /// <param name="task"> The task to run. </param>
        public static async void ToVoid(this Task task)
        {
            await task;
        }
    }
}
