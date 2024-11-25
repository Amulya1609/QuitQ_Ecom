using QuitQ_Ecom.DTOs;

namespace QuitQ_Ecom.Repository
{
    public interface IStore
    {
        Task<StoreDTO> AddStore(StoreDTO storeDTO);
        Task<List<StoreDTO>> GetAllStores();
        Task<StoreDTO> GetStoreById(int storeId);
        Task<StoreDTO> UpdateStore(int storeId, StoreDTO storeDTO);
        Task<bool> DeleteStore(int storeId);
        Task<List<ProductDTO>> GetProductsByStore(int storeId);
        Task<List<StoreDTO>> GetAllStoresOfUserByUserId(int userId);
    }
}
