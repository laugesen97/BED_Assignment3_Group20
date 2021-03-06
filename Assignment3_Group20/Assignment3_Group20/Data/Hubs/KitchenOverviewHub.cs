using Microsoft.AspNetCore.SignalR;

namespace Assignment3_Group20.Data.Hubs;

public class KitchenOverviewHub : Hub<IKitchenOverview>
{
    public async Task Update()
    {
        await Clients.All.Update();
    }
}

//public class KitchenOverviewHub : Hub
//{
//    public async Task Update()
//    {
//        await Clients.All.SendAsync("Update");
//    }
//}