namespace Core.Secure.Business.Domain.AggregatesModel.ScalableAggregate.BPAggregate.Interface;

public interface IBPRepository
{
    Task<VendorDetailResponse> GetVendorByIdAsync(Guid vendorId);
}