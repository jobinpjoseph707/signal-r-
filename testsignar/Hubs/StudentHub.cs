using Microsoft.AspNetCore.SignalR;

namespace testsignar.Hubs
{
    public class StudentHub : Hub
    {
        public async Task SendStudentCountUpdate(int count)
        {
            await Clients.All.SendAsync("ReceiveStudentCountUpdate", count);
        }
    }
}
