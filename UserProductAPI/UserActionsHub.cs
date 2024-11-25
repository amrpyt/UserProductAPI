using Microsoft.AspNetCore.SignalR;

public class UserActionsHub : Hub
{
    // دالة للإعلام عن إضافة مستخدم جديد
    public async Task NotifyUserAdded(string username)
    {
        await Clients.All.SendAsync("UserAdded", username);
    }

    // دالة للإعلام عن شراء منتج
    public async Task NotifyProductPurchased(string productName)
    {
        await Clients.All.SendAsync("ProductPurchased", productName);
    }
}
