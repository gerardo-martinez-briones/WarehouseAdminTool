using MediatR;

namespace Core.Features.PurchaseOrderStatusLogs.Commands.CreatePurchaseOrderStatusLog;

public class CreatePurchaseOrderStatusLogCommand : IRequest<int>
{
    public int IdPurchaseOrderStatusLog { get; set; }
    public int IdPurchaseOrder { get; set; }
    public int IdStatus { get; set; }
    public int IdUser { get; set; }
    public string Comments { get; set; }
}
